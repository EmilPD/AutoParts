namespace CommonNews.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.UI;
    using Bytes2you.Validation;
    using Common;
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
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Server, VaryByParam = "*")]
        public ActionResult Index()
        {
            var posts = this.postsService
                .Get(GlobalConstants.PostsCountOnHomePage)
                .Include(x => x.Author)
                .Include(x => x.Category)
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
