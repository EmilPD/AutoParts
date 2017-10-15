namespace CommonNews.Web.Identity
{
    using Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}
