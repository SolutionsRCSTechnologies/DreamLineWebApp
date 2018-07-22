using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DreamLineWebApp.Startup))]
namespace DreamLineWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
