using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(CommonNews.Web.App_Start.Startup))]

namespace CommonNews.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
