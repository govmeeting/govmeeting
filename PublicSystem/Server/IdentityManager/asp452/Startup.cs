using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp452.Startup))]
namespace asp452
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureIdentityManager(app);
        }
    }
}
