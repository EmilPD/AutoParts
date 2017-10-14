namespace CommonNews.Web.Identity
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>, IApplicationSignInManager
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)this.UserManager);
        }
    }
}
