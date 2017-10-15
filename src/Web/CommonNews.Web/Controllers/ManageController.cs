namespace CommonNews.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Bytes2you.Validation;
    using Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager signInManager;

        private ApplicationUserManager userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            Guard.WhenArgument(userManager, "ApplicationUserManager").IsNull().Throw();
            Guard.WhenArgument(signInManager, "ApplicationSignInManager").IsNull().Throw();

            this.UserManager = userManager as ApplicationUserManager;
            this.SignInManager = signInManager as ApplicationSignInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

            private set
            {
                this.signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.userManager != null)
            {
                this.userManager.Dispose();
                this.userManager = null;
            }

            base.Dispose(disposing);
        }

        private bool HasPassword()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            return user?.PasswordHash != null;
        }
    }
}
