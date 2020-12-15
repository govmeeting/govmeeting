using GM.DatabaseAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

/* This file is the start of work to move the DI code from WebApp to Infrastructure.
 */

//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;


namespace GM.DatabaseAccess
{
    public static class DependencyInjection
    {
        // This is from: https://alexcodetuts.com/2020/02/05/asp-net-core-3-1-clean-architecture-invoice-management-app-part-1/

        //public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(
        //            configuration.GetConnectionString("DefaultConnection"),
        //            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //    services.AddDefaultIdentity<ApplicationUser>()
        //        .AddEntityFrameworkStores<ApplicationDbContext>();

        //    services.AddIdentityServer()
        //        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        //    services.AddAuthentication()
        //        .AddIdentityServerJwt();

        //    return services;
        //}

        //public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddAuthentication()
        //    //.AddGoogle(options =>
        //    //{
        //    //    options.ClientId = Configuration["ExternalAuth:Google:ClientId"];
        //    //    options.ClientSecret = Configuration["ExternalAuth:Google:ClientSecret"];
        //    //});
        //    // https://docs.microsoft.com/en-us/dotnet/core/compatibility/2.2-3.1#authentication-google-deprecated-and-replaced

        //    .AddOpenIdConnect("Google", o =>
        //    {
        //        o.ClientId = Configuration["ExternalAuth:Google:ClientId"];
        //        o.ClientSecret = Configuration["ExternalAuth:Google:ClientSecret"];
        //        o.Authority = "https://accounts.google.com";
        //        o.ResponseType = OpenIdConnectResponseType.Code;
        //        o.CallbackPath = "/signin-google"; // Or register the default "/sigin-oidc"
        //        o.Scope.Add("email");
        //    });
        //    return services;
        //}


        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
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

            return services;

            //// Govmeeting: Brock Allen suggest stronger hashing instead of the default.
            ////services.Configure<PasswordHasherOptions>(options =>
            ////{
            ////    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
            ////    options.IterationCount = 20000;
            ////});
        }


    }

}
