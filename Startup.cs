using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GFS.Startup))]
namespace GFS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
