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
            //var categories = this.categoriesService.GetAll().ToList();
            //var viewModel = new PostFormViewModel
            //{
            //    Post = new Post(),
            //    Categories = categories
            //};

            return this.View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var user = this.usersService.GetById(userId);
                var categoryId = int.Parse(this.Request["Post.Category"]);
                var category = this.categoriesService.GetById(categoryId);

                post.Author = user;
                post.Category = category;

                if (post.ImageUrl == null)
                {
                    post.ImageUrl = "/Content/images/default.jpg";
                }

                this.postsService.Add(post);

                return this.RedirectToAction("Index");
            }

            return this.View(post);
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

            return this.View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,ImageUrl,CreatedOn")] Post post)
        {
            if (this.ModelState.IsValid)
            {
                this.postsService.Update(post);

                return this.RedirectToAction("Index");
            }

            return this.View(post);
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
