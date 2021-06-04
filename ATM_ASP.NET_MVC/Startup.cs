using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATM_ASP.NET_MVC.Startup))]
namespace ATM_ASP.NET_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
