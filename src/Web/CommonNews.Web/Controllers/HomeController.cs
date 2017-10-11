namespace CommonNews.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
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
