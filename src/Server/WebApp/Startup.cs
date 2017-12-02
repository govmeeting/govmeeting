using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using WebApp.StartupCustomizations;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Here we will create a service for handling the configuration settings that were stored in
            // "Configuration" in the Startup() method. This has two advantages:
            // 1. We will be able to access the configuration settings from controllers using Dependency Injection.
            // 2. The configuration setting can be strongly typed objects of any type and not just strings.

            // Adds services required for using options.
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration
            // https://weblog.west-wind.com/posts/2016/may/23/strongly-typed-configuration-settings-in-aspnet-core
            services.AddOptions();
            // Register the IConfiguration instance which DatafilesOptions binds against.
            services.Configure<DatafilesOptions>(Configuration.GetSection("Datafiles"));

            // Registers the following lambda used to configure options.
            services.Configure<DatafilesOptions>(myOptions =>
            {
                // Combine the current directory path with the relative path in the configuration.
                myOptions.DatafilesPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), myOptions.DatafilesPath);
                Console.WriteLine("Datafile path = " + myOptions.DatafilesPath);
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            // In development, we get this value from appsettings.json. In production, the value
            // in appsettings.production.json overrides this value.

            services.AddAuthentication()
            .AddGoogle(options => {
                options.ClientId = Configuration["ExternalAuth:Google:ClientId"];
                options.ClientSecret = Configuration["ExternalAuth:Google:ClientSecret"];
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Govmeeting: Set options for cookie expiration.
                // Todo-g - While upgrading to .NET SDK 2.0, I was getting an error on the next two line so
                // I commented them out. Error = "IdentityOptions does not contain a definition for Cookies"
                //options.Cookies.ApplicationCookie.SlidingExpiration = true;
                //options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromHours(1);

                // Govmeeting: Set option for password length.
                options.Password.RequiredLength = 8;
                // Govmeeting: Set lockout options.
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // amount of time they are locked out
                options.Lockout.AllowedForNewUsers = true;
                // Todo-g We should send the admin an email if someone is locked out.
                // Govmeeting: Require email confirmation
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


            // https://docs.asp.net/en/latest/security/authorization/claims.html
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy =>
                {
                    policy.RequireClaim("role", "administrator");
                });

                options.AddPolicy("Editor", policy =>
                {
                    policy.RequireClaim("role", "editor");
                });

                options.AddPolicy("Proofreader", policy =>
                {
                    policy.RequireClaim("role", "proofreader");
                });

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

                //options.AddPolicy("DevInterns", policy =>
                //{
                //    policy.AddRequirements(new StatusRequirement("development", "intern"));

                //    // ..or using an extension method
                //    //policy.RequireStatus("development", "intern");
                //});

                /* Other way of doing the above without an external class:
                // inline policies
                options.AddPolicy("SalesOnly", policy =>
                {
                    policy.RequireClaim("department", "sales");
                });
                options.AddPolicy("SalesSenior", policy =>
                {
                    policy.RequireClaim("department", "sales");
                    policy.RequireClaim("status", "senior");
                });
                */
            });

            // Add framework services.
            services.AddMvc()
                .AddXmlSerializerFormatters();

            // This enables the use of "Feature Folders".
            // https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureLocationExpander());
            });


            // Add our repository type
            services.AddSingleton<IMeetingRepository, MeetingRepository>();
            services.AddSingleton<IAddtagsRepository, AddtagsRepository>();
            services.AddSingleton<IFixasrRepository, FixasrRepository>();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            //ILoggerFactory loggerFactory,
            ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) // added for call to DbInitializer
        {
            // Logging configuration is now part of the "WebHost.CreateDefaultBuilder(args)" call in Program.cs
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                // Using migrations with asp.net core: https://dzone.com/articles/how-to-use-migration-with-entity-framework-core 
                try
                {
                    // Todo-g - We should be able to replace all the code below with:
                    //          db.Database.Migrate();
                    // if we add another argument to the Configure() argument list:
                    //          public void Configure( ...... , ApplicationDbContext db)
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                // Add a PhysicalFileProvider for the BrowserApp folder.
                string s = Directory.GetCurrentDirectory();     // directory of ...PublicSystem\Server\WebApp\wwwroot
                int i = s.LastIndexOf("\\");        // go back 1st of three backslashes
                i = s.LastIndexOf("\\", i - 1);     // second backslash

                // JP: ### Conversion to ASP.NET Core ###
                // JP: GetCurrentDIrectory no longer gets ...PublicSystem\Server\WebApp\wwwroot but it gets ...PublicSystem\Server\WebApp
                // JP: Why is this?
                // i = s.LastIndexOf("\\", i - 1);     // third backslash

                string browserAppPath = s.Substring(0, i) + @"\Client\BrowserApp";  // ...PublicSystem\Client\BrowserApp 
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(browserAppPath),
                    RequestPath = new PathString("/ba")
                });
            }

            app.UseAuthentication();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                /* The following is for Angular SPA routes. When someone does a browser refresh or uses a 
                 * bookmark that's a deep link into the SPA, a request is sent to the server, instead
                 * of being handled by the SPA. The server does not find a controller for this route
                 * and returns a 404, Not Found. This map route redirects the request immediately to
                 * the index page of the Home controller. This returns the page containing the SPA. Once
                 * the SPA is running, it sees the URL that is being requested and handles it properly.
                 */
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            // Create seed data
            DbInitializer.Initialize(context, userManager, roleManager, Configuration).Wait();
            //DbInitializer.Initialize(app).Wait();
        }
    }
}
