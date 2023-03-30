using GM.Application.AppCore.Common;
using GM.Application.AppCore.Interfaces;
using GM.Application.Configuration;
using GM.Infrastructure.FileDataRepositories.EditMeetings;
using GM.Infrastructure.FileDataRepositories.ViewMeetings;
using GM.Infrastructure.InfraCore.Data;
using GM.Infrastructure.InfraCore.Identity;
using GM.Utilities;
using GM.WebUI.WebApp.Services;
using GM.WebUI.WebApp.StartupCustomizations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NLog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;

namespace GM.WebUI.WebApp
{
    public static class StartupAuth
    {
        public static void ConfigureIdentity(IServiceCollection services, IConfiguration Configuration, NLog.Logger logger)
        {
            StartupAuth.ConfigureAuthentication(services, Configuration);
            logger.Info("Configure Authentication");

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            logger.Info("Clear JWT ClaimTypeMap");

            StartupAuth.ConfigureIdentity(services);
            logger.Info("Configure Identity");

            StartupAuth.ConfigureAuthorization(services);
            logger.Info("Add Authorization");
        }

        private static void ConfigureAuthentication(IServiceCollection services, IConfiguration Configuration)
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

            //AUTH// services.AddTransient<ISeedAuth, SeedAuth>();

        }

        private static void ConfigureIdentity(IServiceCollection services)
        {
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

            //// Govmeeting: Brock Allen suggest stronger hashing instead of the default.
            ////services.Configure<PasswordHasherOptions>(options =>
            ////{
            ////    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
            ////    options.IterationCount = 20000;
            ////});
        }

        private static void ConfigureAuthorization(IServiceCollection services)
        {
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

                // Add some sample claims for our test data

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