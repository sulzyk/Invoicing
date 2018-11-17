using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Invoicing.Web.Startup))]
namespace Invoicing.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
