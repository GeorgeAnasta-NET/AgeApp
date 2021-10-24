using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgeApp.Startup))]
namespace AgeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
