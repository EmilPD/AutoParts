namespace CommonNews.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
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
            IDataService<ApplicationUser> usersService,
            IMapper mapper)
            : base(mapper)
        {
            Guard.WhenArgument(postsService, "PostsService").IsNull().Throw();
            Guard.WhenArgument(commentsService, "CommentsService").IsNull().Throw();
            Guard.WhenArgument(usersService, "UsersService").IsNull().Throw();

            this.postsService = postsService;
            this.commentsService = commentsService;
            this.usersService = usersService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(int id, CommentViewModel commentViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var user = this.usersService.GetById(userId);
                var commentPost = this.postsService.GetById(id);

                var newComment = this.Mapper.Map<Comment>(commentViewModel);
                newComment.Author = user;
                newComment.Post = commentPost;

                this.commentsService.Add(newComment);

                return this.RedirectToAction("Details", "Posts", new { id = id });
            }

            return this.RedirectToAction("Details", "Posts", new { id = id });
        }
    }
}
