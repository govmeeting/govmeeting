using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

namespace WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()

                // JP: ### Conversion to ASP.NET Core ###
                // These changes were made to new template.
                .SetBasePath(env.ContentRootPath)
                //.AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)

                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            // JP: ### Conversion to ASP.NET Core ###
            // JP: The latest template for ASP.NET Core remove the calls to AddEntityFramework and AddSqlServer
            //services.AddEntityFramework()
            //    .AddSqlServer()
            services.AddDbContext<ApplicationDbContext>(options =>
                // options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
                // We use User Secrets to store this. We left the development string in appsettings.json, but it is not used.
                options.UseSqlServer(Configuration["Data_DefaultConnection_ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Govmeeting: Set options for cookie expiration.
                options.Cookies.ApplicationCookie.SlidingExpiration = true;
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromHours(1);
                // Govmeeting: Set option for password lehgth.
                options.Password.RequiredLength = 8;
                // Govmeeting: Set lockout options.
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // amount of time they are locked out
                options.Lockout.AllowedForNewUsers = true;
                // TODO: We should send the admin an email if someone is locked out.
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
                options.AddPolicy("SysAdmin", policy =>
                {
                    policy.RequireClaim("Administrator", "System");
                });

                // TODO We need policies that are more dynamic and flexible.
                // These will work temporarily.
                options.AddPolicy("PhillyEditor", policy =>
                {
                    policy.RequireClaim("Editor", "Philadelphia");
                });
                options.AddPolicy("BbhEditor", policy =>
                {
                    policy.RequireClaim("Editor", "Boothbay Harbor");
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
            services.AddMvc();

            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.ViewLocationExpanders.Add(new FeatureLocationExpander());
            //});


            // Add our repository type
            services.AddSingleton<IMeetingRepository, MeetingRepository>();
            services.AddSingleton<ITranscriptRepository, TranscriptRepository>();
            services.AddSingleton<IAddtagsRepository, AddtagsRepository>();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            // JP: ### Conversion to ASP.NET Core ###
            // Remove call to app.UseIISPlatformHandler(); This is handled by UseIIS in Main.
            // See: https://github.com/aspnet/Announcements/issues/164
            // app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseStaticFiles();

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

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            // Govmeeting: Add Google middleware authentication. We also added 
            // "Microsoft.AspNet.Authentication.Google" dependency in project.json and using statement above.
            // http://localhost:60366/signin-google
            app.UseGoogleAuthentication(new GoogleOptions
            {
                //ClientId = Configuration["ExternalAuth:Google:ClientId"],
                //ClientSecret = Configuration["ExternalAuth:Google:ClientSecret"],
                // We use the User Secrets store for this info.
                ClientId = Configuration["ExternalAuth_Google_ClientId"],
                ClientSecret = Configuration["ExternalAuth_Google_ClientSecret"],
                AuthenticationScheme = "Google",

                // JP: ### Conversion to ASP.NET Core ###
                //SignInScheme = new Microsoft.AspNet.Identity.IdentityCookieOptions().ExternalCookieAuthenticationScheme
                SignInScheme = new Microsoft.AspNetCore.Identity.IdentityCookieOptions().ExternalCookieAuthenticationScheme
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "API Addtags+Transcripts",
                    template: "{controller=Addtags}/{city}/{govEntity?}/{meetingDate?}");

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
                routes.MapRoute(
                    name: "spa-fallback",
                    template: "{*url}",
                    defaults: new { controller = "Home", action = "index" });

            });
        }

        // Entry point for the application.
        // JP: ### Conversion to ASP.NET Core ###
        // JP: It appears that the latest template created a "Main" entry point in "program.cs"
        //public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
