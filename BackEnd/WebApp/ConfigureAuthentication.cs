using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

//using NLog;
//using NLog.Web;
using Microsoft.Extensions.Logging;
using GM.DatabaseAccess;
using GM.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace GM.WebApp
{
    public partial class Startup
    {
        // TODO - see: Migrate authentication and Identity to ASP.NET Core 2.0;  06/21/2019

        public void ConfigureAuthenticationServices(
            IServiceCollection services,
            NLog.Logger logger
            )
        {
            services.AddAuthentication()
            //.AddGoogle(options =>
            //{
            //    options.ClientId = Configuration["ExternalAuth:Google:ClientId"];
            //    options.ClientSecret = Configuration["ExternalAuth:Google:ClientSecret"];
            //});
            // https://docs.microsoft.com/en-us/dotnet/core/compatibility/2.2-3.1#authentication-google-deprecated-and-replaced
            .AddOpenIdConnect("Google", o =>
            {
                o.ClientId = Configuration["ExternalAuth:Google:ClientId"];
                o.ClientSecret = Configuration["ExternalAuth:Google:ClientSecret"];
                o.Authority = "https://accounts.google.com";
                o.ResponseType = OpenIdConnectResponseType.Code;
                o.CallbackPath = "/signin-google"; // Or register the default "/sigin-oidc"
                o.Scope.Add("email");
            });
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            logger.Info("Add Identity");

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // TODO - While upgrading to .NET SDK 2.0, I was getting an error seting these options, so
                // I commented them out. Error = "IdentityOptions does not contain a definition for Cookies"
                // Govmeeting: Set options for cookie expiration.
                //options.Cookies.ApplicationCookie.SlidingExpiration = true;
                //options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromHours(1);

                options.Password.RequiredLength = 8;
                        options.Lockout.MaxFailedAccessAttempts = 5;
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // amount of time they are locked out
                options.Lockout.AllowedForNewUsers = true;
                // TODO We should send the admin an email if someone is locked out.
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Govmeeting: Brock Allen suggest stronger hashing instead of the default.
            //services.Configure<PasswordHasherOptions>(options =>
            //{
            //    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
            //    options.IterationCount = 20000;
            //});

            logger.Info("Add Authorization");

            // https://docs.asp.net/en/latest/security/authorization/claims.html
            services.AddAuthorization(options =>
            {
                // In DbInitializer, the admin user and administrator role is created.
                // The password and email is read from appsettings.
                // The methods in Features/Admin/AdminController.cs require: Policy = "Administrator" 
                options.AddPolicy("Administrator", policy =>
                { policy.RequireClaim("role", "administrator"); });

                options.AddPolicy("Editor", policy =>
                { policy.RequireClaim("role", "editor"); });

                options.AddPolicy("Proofreader", policy =>
                { policy.RequireClaim("role", "proofreader"); });

                options.AddPolicy("PhillyEditor", policy =>
                {
                    policy.RequireClaim("role", "editor");
                    policy.RequireClaim("location", "Philadelphia");
                });
                options.AddPolicy("BbhEditor", policy =>
                {
                    policy.RequireClaim("role", "editor");
                    policy.RequireClaim("location", "Boothbay Harbor");
                });
            });

        }

    }
}

