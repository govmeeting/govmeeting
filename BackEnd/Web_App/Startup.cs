using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;

using NLog;
using NLog.Web;

using System.IO;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;

using GM.Configuration;
using GM.WebApp.StartupCustomizations;
using GM.DatabaseRepositories;
using GM.DatabaseAccess;
using GM.FileDataRepositories;
using GM.WebApp.Services;

namespace GM.WebApp
{
    public class Startup

    {
        readonly NLog.Logger _logger;

        //public Startup(IConfiguration configuration, ILogger<Startup> logger)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Set a variable in the gdc which is be used in NLog.config for the
            // base path of our app: ${gdc:item=appbasepath} 
            var appBasePath = System.IO.Directory.GetCurrentDirectory();
            GlobalDiagnosticsContext.Set("appbasepath", appBasePath);

            _logger.Trace("GM: In ConfigureServices");

            _logger.Info("GM: Add AppSettings");
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                // Modify the DataFilesPath option to be the full path.
                //myOptions.DatafilesPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), myOptions.DatafilesPath);
                myOptions.DatafilesPath = GMFileAccess.GetFullPath(myOptions.DatafilesPath);
                myOptions.TestfilesPath = GMFileAccess.GetFullPath(myOptions.TestfilesPath);
                Console.WriteLine("Datafile path = " + myOptions.DatafilesPath);
            });

            _logger.Trace("GM: Add ApplicationDbContext");
            // We will be able to access ApplicationDbContext in a controller with:
            //    public MyController(ApplicationDbContext context) { ... }
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            _logger.Trace("GM: Add Add Authentication");
            ConfigureAuthenticationServices(services);


            _logger.Trace("GM: Add MVC");
            services.AddMvc()
				// The ContractResolver option is to prevent the case of Json field names 
				// being changed when retrieved by client.
                // https://codeopinion.com/asp-net-core-mvc-json-output-camelcase-pascalcase/
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddXmlSerializerFormatters();

            _logger.Trace("GM: Add Feature Folders");
            // This enables the use of "Feature Folders".
            // https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureLocationExpander());
            });

            _logger.Trace("GM: Add SPA static files");
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                //configuration.RootPath = "../../Frontend/ClientApp/dist";
                configuration.RootPath = "ClientApp/dist";
            });

            _logger.Trace("GM: Add Application services");
            AddApplicationServices(services);

            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Here we configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IDbInitializer dbInitializer,
            //ILoggerFactory loggerFactory,
            IOptions<AppSettings> config
            )
        {
            _logger.Trace("GM: Configure exception handler Identity");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                try
                {
                    // db.Database.Migrate();
                }
                catch {
                    _logger.Debug("db.Database.Migrate() failed");
                }

            }

            _logger.Trace("GM: Configure static file paths");
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            _logger.Trace("GM: Configure datafiles PhysicalFileProvider");
            // Add a PhysicalFileProvider for the Datafiles folder. Until we have a way to serve video files to 
            // videogular via the API, we need to allow these to be accessed as static files.
            string datafilesPath = config.Value.DatafilesPath;
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    datafilesPath),
                    RequestPath = "/datafiles"
            });

            _logger.Trace("GM: Configure routes");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            _logger.Trace("GM: Configure SPA");
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                //spa.Options.SourcePath = "../../Frontend/ClientApp";
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            _logger.Trace("GM: Configure Authenitication");
            app.UseAuthentication();

            _logger.Trace("GM: Initialize database");
            //Create seed data
            dbInitializer.Initialize().Wait();


            _logger.Trace("GM: Copy test data to Datafiles folder");
            string testfilesPath = config.Value.TestfilesPath;
            CopyTestData(testfilesPath, datafilesPath);

        }

        private void ConfigureAuthenticationServices(IServiceCollection services)
        {
            services.AddAuthentication()
            .AddGoogle(options => {
                options.ClientId = Configuration["ExternalAuth:Google:ClientId"];
                options.ClientSecret = Configuration["ExternalAuth:Google:ClientSecret"];
            });

            _logger.Trace("GM: Add Identity");

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Govmeeting: Set options for cookie expiration.
                // Todo-g - While upgrading to .NET SDK 2.0, I was getting an error on the next two line so
                // I commented them out. Error = "IdentityOptions does not contain a definition for Cookies"
                //options.Cookies.ApplicationCookie.SlidingExpiration = true;
                //options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromHours(1);

                options.Password.RequiredLength = 8;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // amount of time they are locked out
                options.Lockout.AllowedForNewUsers = true;
                // Todo-g We should send the admin an email if someone is locked out.
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

            _logger.Trace("GM: Add Authorization");

            // https://docs.asp.net/en/latest/security/authorization/claims.html
            services.AddAuthorization(options =>
            {
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

        private void AddApplicationServices(IServiceCollection services)
        {
            // Add repositories
            services.AddSingleton<IGovBodyRepository, GovBodyRepositoryStub>();     // use stub
            services.AddSingleton<IMeetingRepository, MeetingRepositoryStub>();     // use stub
            services.AddSingleton<IViewMeetingRepository, ViewMeetingRepository>();
            services.AddSingleton<IAddtagsRepository, AddtagsRepository>();
            services.AddSingleton<IFixasrRepository, FixasrRepository>();

            _logger.Trace("GM: Add Application services");

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IDbInitializer, DbInitializer>();
            services.AddTransient<MeetingFolder>();

            services.AddScoped<ValidateReCaptchaAttribute>();
        }


        // Copy sample test data from the "testdata" folder to the "Datafiles" folder.
        private void CopyTestData(string testfilesPath, string datafilesPath)
        {
            string[] dirs = new string[]
            {
                // This data is for a meeting that we transcribed from an .mp4 file and we are currently
                // on the step of fixing the transcription. When you run Web_App and click on "Fixasr",
                // this is the data that you will see.
                //@"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-02-15",     // For Fixasr
                @"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-01-09",     // For Fixasr

                // This data is for a meeting for which we retrieved a PDF of the transcript and already
                // did the preprocessing. We are now on the step of adding tags. When you run Web_App
                // and click on "Addtags", this is the data that you will see.
                @"USA_PA_Philadelphia_Philadelphia_CityCouncil_en\2014-09-25",       // For Addtags

                // This data is for a meeting that was transcribed, fixed and tags added. We can now view the completed
                // transcript. When you run Web_App and click on "ViewMeeting", this is the data that you will see.
                @"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2014-09-08",     // For ViewMeeting
            };

            foreach (string dir in dirs)
            {
                string source = testfilesPath + "\\" + dir;
                string destination = datafilesPath + "\\" + dir;
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                    GMFileAccess.CopyContents(source, destination);
                }
            }
        }
    }
}
