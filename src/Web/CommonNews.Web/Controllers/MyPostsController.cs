namespace CommonNews.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Bytes2you.Validation;
    using Common.Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common.Contracts;
    using ViewModels.Pagination;
    using ViewModels.Post;
    using AutoMapper;
    [Authorize]
    public class MyPostsController : BaseController
    {
        private readonly IDataService<Post> postsService;
        private readonly IPaginationFactory paginationFactory;

        public MyPostsController(
            IDataService<Post> postsService,
            IPaginationFactory paginationFactory,
            IMapper mapper)
            : base(mapper)
        {
            Guard.WhenArgument(postsService, "UsersService").IsNull().Throw();
            Guard.WhenArgument(paginationFactory, "PaginationFactory").IsNull().Throw();

            this.postsService = postsService;
            this.paginationFactory = paginationFactory;
        }

        // GET: Admin/Users
        [HttpGet]
        [Authorize]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Index(int? page, PageViewModel<PostViewModel> pageViewModel)
        {
            var userId = this.User.Identity.GetUserId();
            var posts = this.postsService.GetAll().Where(x => x.Author.Id == userId)
                .Include(x => x.Author).Include(x => x.Category).AsEnumerable();

            var pagination = this.paginationFactory.CreatePagination(posts.Count(), page);

            pageViewModel.Items = this.Mapper.Map<IEnumerable<PostViewModel>>(posts)
                .Skip((pagination.CurrentPage - 1) * pagination.PageSize).Take(pagination.PageSize);

            pageViewModel.Pagination = pagination;

            return this.View("Index", pageViewModel);
        }
    }
}