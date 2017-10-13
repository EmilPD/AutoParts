namespace CommonNews.Web.Areas.Admin.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UsersViewModel : IMapBothWays<ApplicationUser>
    {
        public virtual string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string UserName { get; set; }
    }
}
