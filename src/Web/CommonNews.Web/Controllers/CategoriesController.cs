namespace CommonNews.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Bytes2you.Validation;
    using Data.Models;
    using Services.Data.Common.Contracts;
    using ViewModels.Category;
    using ViewModels.Post;

    public class CategoriesController : BaseController
    {
        private readonly IDataService<PostCategory> categoriesService;

        public CategoriesController(IDataService<PostCategory> categoriesService)
        {
            Guard.WhenArgument(categoriesService, "CategoriesService").IsNull().Throw();

            this.categoriesService = categoriesService;
        }

        // GET: Categories
        public ActionResult Index(string categoryName)
        {
            var category = this.categoriesService
                .GetAll()
                .Include(x => x.Posts)
                .Where(x => x.Name.ToLower() == categoryName.ToLower())
                .FirstOrDefault();

            var postsInCategory = this.Mapper
                .Map<ICollection<PostViewModel>>(category.Posts.Where(x => x.IsDeleted == false)
                .ToList());

            var viewModel = new CategoryViewModel
            {
                Name = category.Name,
                Posts = postsInCategory
            };

            return this.View(viewModel);
        }
    }
}
