using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ikhon.GBWeb.UI.Web.Startup))]
namespace Ikhon.GBWeb.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
