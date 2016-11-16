using IdentityManager.Configuration;
using Owin;
using asp452.Models;

namespace asp452
{
    public partial class Startup
    {
        public void ConfigureIdentityManager(IAppBuilder app)
        {
            app.Map("/idm", idm =>
            {
                // Brock Allen: "Since Owen and Katana do not define standard DI, we need to do our own.
                var factory = new IdentityManagerServiceFactory();
                factory.IdentityManagerService = new Registration<IdentityManager.IIdentityManagerService, ApplicationIdentityManagerService>();
                factory.Register(new Registration<ApplicationUserManager>());
                factory.Register(new Registration<ApplicationUserStore>());
                factory.Register(new Registration<ApplicationRoleManager>());
                factory.Register(new Registration<ApplicationRoleStore>());
                factory.Register(new Registration<ApplicationDbContext>());

                // ApplicationDbContext uses "DefaultConnection" as the connection string.
                // If we wanted to use something different, we would change the constructor for ApplicationDbContext
                // to use a parameter for the connection string. Then we would do this:
                //   factory.Register(new Registration<ApplicationDbContext>(resolver => new ApplicationDbContext("foo")));

                idm.UseIdentityManager(new IdentityManagerOptions
                {
                    Factory = factory
                });
            });

        }
    }
}