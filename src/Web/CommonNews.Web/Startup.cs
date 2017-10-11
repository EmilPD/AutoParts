using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommonNews.Web.Startup))]
namespace CommonNews.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
