using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourMVC.Startup))]
namespace TourMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
