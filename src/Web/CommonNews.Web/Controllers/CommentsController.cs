namespace CommonNews.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using Bytes2you.Validation;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common.Contracts;
    using ViewModels.Comment;

    public class CommentsController : BaseController
    {
        private readonly IDataService<Post> postsService;
        private readonly IDataService<Comment> commentsService;
        private readonly IDataService<ApplicationUser> usersService;

        public CommentsController(
            IDataService<Post> postsService,
            IDataService<Comment> commentsService,
            IDataService<ApplicationUser> usersService)
        {
            Guard.WhenArgument(postsService, "PostsService").IsNull().Throw();
            Guard.WhenArgument(commentsService, "CommentsService").IsNull().Throw();
            Guard.WhenArgument(usersService, "UsersService").IsNull().Throw();

            this.postsService = postsService;
            this.commentsService = commentsService;
            this.usersService = usersService;
        }

        //public ActionResult All(int id)
        //{
        //    var comments = this.commentsService
        //        .GetAll()
        //        .Where(c => c.Post.Id == id && !c.IsDeleted)
        //        .OrderByDescending(c => c.CreatedOn)
        //        .ToList()
        //        .Select(x => this.Mapper.Map<CommentViewModel>(x))
        //        .ToList();

        //    return this.PartialView(comments);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(int id, CommentViewModel commentViewModel)
        {
            //if (this.ModelState.IsValid)
            //{
                var userId = this.User.Identity.GetUserId();
                var user = this.usersService.GetById(userId);
                var commentPost = this.postsService.GetById(id);

                var newComment = new Comment
                {
                    Content = commentViewModel.Content,
                    Post = commentPost,
                    Author = user
                };

                this.commentsService.Add(newComment);

                return this.PartialView("_CommentDetail", commentViewModel);
            //}

            return this.View("_CreateComment", commentViewModel);
        }
    }
}
