namespace CommonNews.Web.Controllers
{
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using Bytes2you.Validation;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common.Contracts;
    using ViewModels.Post;

    public class PostsController : BaseController
    {
        private readonly IDataService<Post> postsService;
        private readonly IDataService<PostCategory> categoriesService;
        private readonly IDataService<ApplicationUser> usersService;

        public PostsController(
            IDataService<Post> postsService,
            IDataService<PostCategory> categoriesService,
            IDataService<ApplicationUser> usersService)
        {
            Guard.WhenArgument(postsService, "PostsService").IsNull().Throw();
            Guard.WhenArgument(categoriesService, "CategoriesService").IsNull().Throw();
            Guard.WhenArgument(usersService, "UsersService").IsNull().Throw();

            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.usersService = usersService;
        }

        // GET: Posts
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .ToList()
                .Select(x => this.Mapper.Map<PostViewModel>(x))
                .ToList();

            return this.View(posts);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            Post post = this.postsService.GetById(id);

            if (post == null)
            {
                return this.HttpNotFound();
            }

            var postViewModel = this.Mapper.Map<PostViewModel>(post);

            return this.View(postViewModel);
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            var categories = this.categoriesService.GetAll().ToList();
            var viewModel = new PostFormViewModel
            {
                Post = new PostViewModel(),
                Categories = categories
            };

            return this.View(viewModel);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        public ActionResult Edit(int id)
        {
            Post post = this.postsService.GetById(id);

            if (post == null)
            {
                return this.HttpNotFound();
            }

            var categories = this.categoriesService.GetAll().ToList();
            var postViewModel = this.Mapper.Map<PostViewModel>(post);
            var viewModel = new PostFormViewModel
            {
                Post = postViewModel,
                Categories = categories
            };

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
                return this.HttpNotFound();
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
