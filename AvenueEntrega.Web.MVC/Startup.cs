using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvenueEntrega.Web.MVC.Startup))]
namespace AvenueEntrega.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
