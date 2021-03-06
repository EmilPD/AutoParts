﻿namespace CommonNews.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Bytes2you.Validation;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common.Contracts;
    using ViewModels.Comment;
    using ViewModels.Post;

    public class PostsController : BaseController
    {
        private readonly IDataService<Post> postsService;
        private readonly IDataService<PostCategory> categoriesService;
        private readonly IDataService<ApplicationUser> usersService;
        private readonly IDataService<Comment> commentsService;

        public PostsController(
            IDataService<Post> postsService,
            IDataService<PostCategory> categoriesService,
            IDataService<ApplicationUser> usersService,
            IDataService<Comment> commentsService,
            IMapper mapper)
            : base(mapper)
        {
            Guard.WhenArgument(postsService, "PostsService").IsNull().Throw();
            Guard.WhenArgument(categoriesService, "CategoriesService").IsNull().Throw();
            Guard.WhenArgument(usersService, "UsersService").IsNull().Throw();
            Guard.WhenArgument(commentsService, "CommentsService").IsNull().Throw();

            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.usersService = usersService;
            this.commentsService = commentsService;
        }

        // GET: Posts
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .ToList()
                .Select(x => this.Mapper.Map<PostViewModel>(x))
                .ToList();

            return this.View(posts);
        }

        // GET: Posts/Details/5
        [OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Details(int id)
        {
            Post post = this.postsService
                .GetAll()
                .Where(x => x.Id == id)
                .Include(x => x.Comments)
                .Include(x => x.Author)
                .Include(x => x.Category)
                .FirstOrDefault();

            if (post == null)
            {
                return this.HttpNotFound("Page not found!");
            }

            var comments = this.commentsService
                .GetAll()
                .Where(x => x.Post.Id == id)
                .Include(x => x.Author)
                .ToList();

            var commentsInPost = this.Mapper
                .Map<ICollection<CommentViewModel>>(comments);

            var postViewModel = this.Mapper.Map<PostViewModel>(post);

            var viewModel = new PostWithCommentsViewModel
            {
                Post = postViewModel,
                Comments = commentsInPost
            };

            return this.View(viewModel);
        }

        // GET: Posts/Create
        [Authorize]
        [OutputCache(Duration = 86000, VaryByParam = "none")]
        public ActionResult Create()
        {
            var categories = this.categoriesService.GetAll().ToList();
            var viewModel = new PostFormViewModel
            {
                Post = new PostViewModel(),
                Categories = categories
            };

            if (viewModel == null)
            {
                return this.HttpNotFound("Page not found!");
            }

            return this.View(viewModel);
        }

        // POST: Posts/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostFormViewModel postFormViewModel)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.usersService.GetById(userId);
            var categoryId = int.Parse(this.Request["Post.Category"]);
            var category = this.categoriesService.GetById(categoryId);

            postFormViewModel.Post.Category = category;

            if (postFormViewModel.Post.ImageUrl == null)
            {
                postFormViewModel.Post.ImageUrl = "/Content/images/default.jpg";
            }

            var newPost = this.Mapper.Map<Post>(postFormViewModel.Post);
            newPost.Author = user;

            this.postsService.Add(newPost);

            return this.RedirectToAction("Index");
        }

        // GET: Posts/Edit/5
        [Authorize]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Edit(int id)
        {
            Post post = this.postsService
                .GetAll()
                .Where(x => x.Id == id)
                .Include(x => x.Author)
                .Include(x => x.Category)
                .FirstOrDefault();

            if (post == null)
            {
                return this.HttpNotFound("Page not found!");
            }

            var categories = this.categoriesService.GetAll().ToList();
            var postViewModel = this.Mapper.Map<PostViewModel>(post);
            var viewModel = new PostFormViewModel
            {
                Post = postViewModel,
                Categories = categories
            };

            if (viewModel == null)
            {
                return this.HttpNotFound("Page not found!");
            }

            return this.View(viewModel);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostFormViewModel postFormViewModel)
        {
            var postInDbId = postFormViewModel.Post.Id;
            var postInDb = this.postsService.GetById(postInDbId);

            var categoryId = int.Parse(this.Request["Post.Category.Id"]);
            var category = this.categoriesService.GetById(categoryId);
            postFormViewModel.Post.Category = category;

            if (postFormViewModel.Post.ImageUrl == null)
            {
                postFormViewModel.Post.ImageUrl = "/Content/images/default.jpg";
            }

            postFormViewModel.Post.PostedOn = postInDb.CreatedOn;

            var editPost = this.Mapper.Map(postFormViewModel.Post, postInDb);
            this.postsService.Update(editPost);

            return this.RedirectToAction("Index");
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Post post = this.postsService.GetById(id);

            if (post == null)
            {
                return this.HttpNotFound("Page not found!");
            }

            var postViewModel = this.Mapper.Map<PostViewModel>(post);

            return this.View(postViewModel);
        }

        // POST: Posts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.postsService.Delete(id);

            return this.RedirectToAction("Index");
        }
    }
}
