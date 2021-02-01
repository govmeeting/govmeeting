using GM.Application.AppCore.Common;
using GM.Application.AppCore.Interfaces;
using GM.Application.Configuration;
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
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        NLog.Logger logger;
        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        public void ConfigureDockerServices(IServiceCollection services)
        {
            services.AddDataProtection()
                .SetApplicationName("govmeeting")
                .PersistKeysToFileSystem(new DirectoryInfo(@"./"));
            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureLoggingService();
            logger.Info("Configure Logging Service");

            ConfigureAppsettings(services);
            logger.Info("Configure Appsettings");

            ConfigureDatabaseServices.Configure(services, Environment.EnvironmentName,
                Configuration["AppSettings:DatabaseType"], Configuration["AppSettings:ConnectionString"]);
            logger.Info("Configure Database");

            services.AddHealthChecks();
            logger.Info("AddHealthChecks");

            ConfigureAuthentication(services);
            logger.Info("Configure Authentication");

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            logger.Info("Clear JWT ClaimTypeMap");

            ConfigureIdentity(services);
            logger.Info("Configure Identity");

            ConfigureAuthorization(services);
            logger.Info("Add Authorization");

            services.AddControllersWithViews();
            logger.Info("Add services for Web API, MVC & Razor Views");

            //services.AddOpenApiDocument();
            services.AddSwaggerDocument();
            logger.Info("Add services for Swagger Document");

            services.AddRazorPages();
            logger.Info("Add services for Razor Pages");

            services.Configure<RazorViewEngineOptions>(options => options.ViewLocationExpanders.Add(new FeatureLocationExpander()));
            logger.Info("Enable Feature Folders");
            // https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/

            // Angular files will be served from this directory in production. 
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "clientapp/dist");
            logger.Info("AddSpaStaticFiles");

            // get the current user for auditing
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            services.AddCQR(executingAssembly);
            logger.Info("Configure CQR Services");

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            logger.Info("Add email and sms");

            services.AddScoped<ValidateReCaptchaAttribute>();
            logger.Info("Add ValidateReCaptchaAttribute");

            services.AddTransient<ISeedDatabase, SeedDatabase>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedDatabase seedDatabase)
        {
            /*  NOTE: 
             *  For Visual Studio, the URL's used during development are in
             *      (WebApp) Project -> Properties -> Debug. Currently:
             *      "App URL" = "http:/localhost:36029"
             *      "Enable SSL" is checked. "https:/localhost:44333/"
             *  For "dotnet run", the dev URL's are in WebApp\Properties\launchSettings.json,
             *    Currently for IISExpress:
             *      "applicationUrl": "http://localhost:36029",
             *      "sslPort": 44333
             *  For VsCode, the dev URL's are in clientapp/.vscode/launch.json. Currently:
             *      "url": "http:/localhost:4200"
             */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            // START OF ENDPOINT ZONE

            app.UseAuthentication();
            app.UseAuthorization();

            DebugCurrentEndpoint(app);

            // END OF ENDPOINT ZONE

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHealthChecks("/health").RequireAuthorization();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "clientapp";

                if (env.IsDevelopment())
                {
                    // spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            seedDatabase.Seed();

        }

        private void ConfigureLoggingService()
        {
            // Set a variable in the gdc which is be used in NLog.config for the
            // base path of our app: ${gdc:item=appbasepath} 
            string logfilesPath = GMFileAccess.GetSolutionSiblingFolder(Configuration["Logging:LogfilesPath"]);
            //string logfilesPath = GMFileAccess.GetFullPath(Configuration["AppSettings:LogfilesPath"]);
            GlobalDiagnosticsContext.Set("logfilesPath", logfilesPath);

            // Create an instance of NLog.Logger manually here since it is not available
            // from dependency injection yet.
            logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
        }


        //public IServiceCollection AddCQR(this IServiceCollection services)
        //{
        //    services.AddMediatR(Assembly.GetExecutingAssembly());
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //    return services;
        //}

        private void ConfigureAppsettings(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                logger.Info("Modify the configuration path options to be full paths.");
                // Modify the configuration path options to be full paths.
                myOptions.DatafilesPath = GMFileAccess.GetSolutionSiblingFolder(myOptions.DatafilesPath);
                myOptions.TestdataPath = GMFileAccess.GetSolutionSiblingFolder(myOptions.TestdataPath);
                logger.Info("DatafilesPath: {0}, TestdataPath: {2}",
                    myOptions.DatafilesPath, myOptions.TestdataPath);
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
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
        }

        private void ConfigureIdentity(IServiceCollection services)
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

        private void ConfigureAuthorization(IServiceCollection services)
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


        // Examine contents of endpoint for current request (for debugging)
        private void DebugCurrentEndpoint(IApplicationBuilder app)
        {
            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint == null)
                {
                    return next(context);
                }

                var route = (endpoint is RouteEndpoint routeEndpoint) ? routeEndpoint.RoutePattern : null;
                var metadata = endpoint.Metadata;

                return next(context);
            });
        }


    }
}
