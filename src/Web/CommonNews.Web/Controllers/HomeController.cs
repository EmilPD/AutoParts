namespace CommonNews.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Bytes2you.Validation;
    using Data.Models;
    using Services.Data;
    using Services.Data.Common.Contracts;
    using ViewModels.Home;
    using ViewModels.Post;

    public class HomeController : BaseController
    {
        private readonly IDataService<Post> postsService;

        public HomeController(DataService<Post> postsService)
        {
            Guard.WhenArgument(postsService, "PostsService").IsNull().Throw();

            this.postsService = postsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            int count = 2;

            var posts = this.postsService
                .Get(count)
                .ToList()
                .Select(x => this.Mapper.Map<PostViewModel>(x))
                .ToList();

            var viewModel = new HomeViewModel()
            {
                Posts = posts
            };

            return this.View(viewModel);
        }
    }
}
