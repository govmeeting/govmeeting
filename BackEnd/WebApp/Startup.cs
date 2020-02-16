using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;

using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using NLog.Extensions.Logging;

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
using Microsoft.EntityFrameworkCore.Design;
using WebApp.Data;

namespace GM.WebApp
{
    public partial class Startup

    {
        // https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-2

        StartupLogger _logger;
        string logfilesPath;

        // public Startup(IConfiguration configuration, ILogger<Startup> logger)
        public Startup(IConfiguration configuration)
        {
            // CurrentDirectoryHelpers.SetCurrentDirectory();

            Configuration = configuration;
            logfilesPath = GMFileAccess.GetFullPath(Configuration["AppSettings:LogfilesPath"]);
            _logger = new StartupLogger(logfilesPath);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // During Startup ConfigureServices, we need to use a separate logging method,
            // since we don't get the DI logger yet.
            // It is especially important in production to get these messages,
            // since it may be the only to know why the app won't start.

            _logger.LogTrace("In Startup ConfigureServices");


            // Set a variable in the gdc which is be used in NLog.config for the
            // base path of our app: ${gdc:item=appbasepath} 
            _logger.LogTrace("Set value in GDC for NLog");
            //var appBasePath = System.IO.Directory.GetCurrentDirectory();
            //GlobalDiagnosticsContext.Set("appbasepath", appBasePath);
            GlobalDiagnosticsContext.Set("logfilesPath", logfilesPath);


            _logger.LogTrace("Modify some AppSettings");
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                // Modify the configuration path options to be full paths.
                myOptions.LogfilesPath = GMFileAccess.GetFullPath(myOptions.LogfilesPath);
                myOptions.DatafilesPath = GMFileAccess.GetFullPath(myOptions.DatafilesPath);
                myOptions.TestfilesPath = GMFileAccess.GetFullPath(myOptions.TestfilesPath);
                Console.WriteLine("Datafile path = " + myOptions.DatafilesPath);
            });

            _logger.LogTrace("Add ApplicationDbContext");

            services.AddTransient<dBOperations>();

            // We will be able to access ApplicationDbContext in a controller with:
            //    public MyController(ApplicationDbContext context) { ... }
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            _logger.LogTrace("Add Add Authentication");
            //ConfigureAuthenticationServices(services);
            ConfigureAuthenticationServices(services, _logger);

            _logger.LogTrace("Add MVC");
            services.AddMvc()
				// The ContractResolver option is to prevent the case of Json field names 
				// being changed when retrieved by client.
                // https://codeopinion.com/asp-net-core-mvc-json-output-camelcase-pascalcase/
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddXmlSerializerFormatters();

            _logger.LogTrace("Add Feature Folders");
            // This enables the use of "Feature Folders".
            // https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureLocationExpander());
            });

            //_logger.LogTrace("Add SPA static files");
            //// In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "../../FrontEnd/ClientApp/dist";
            //    //configuration.RootPath = "ClientApp/dist";
            //});

            _logger.LogTrace("Add Application services");
            AddApplicationServices(services, _logger);

            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Here we configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IDbInitializer dbInitializer,
            ILoggerFactory loggerFactory,
            IOptions<AppSettings> config
            )
        {
            // This should work, but no messages get written.
            // Microsoft.Extensions.Logging.ILogger _logger = loggerFactory.CreateLogger<Startup>();
            // So we are using StartupLogger here also.

            _logger.LogTrace("Configure exception handler");
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
                    _logger.LogDebug("db.Database.Migrate() failed");
                }

            }

            _logger.LogTrace("Use static files & spa static files");
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            _logger.LogTrace("Configure datafiles PhysicalFileProvider");
            // Add a PhysicalFileProvider for the Datafiles folder. Until we have a way to serve video files to 
            // videogular via the API, we need to allow these to be accessed as static files.
            string datafilesPath = config.Value.DatafilesPath;
            _logger.LogTrace("datafilesPath=" + datafilesPath);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    datafilesPath),
                    RequestPath = "/datafiles"
            });

            _logger.LogTrace("Configure routes");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            _logger.LogTrace("Use SPA");
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                //spa.Options.SourcePath = "../../FrontEnd/ClientApp";
                //spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    //spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //// This sends all unhandled URLs to the static index.html page..
            //// The default HomeController/Index is already configured to send index.html.
            //// Can we remove the code below and handle this case in app.UseEndpoints?
            //app.Use(async (context, next) =>
            //{
            //    context.Request.Path = "/index.html";
            //    // I got a warning from FxCop to use ConfigureAwait instead of await:
            //    // "Calling ConfigureAwait(true) on the task has the same behavior as not explicitly 
            //    // calling ConfigureAwait. By explicitly calling this method, you're letting readers 
            //    // know you intentionally want to perform the continuation on the original synchronization context."
            //    // await next();
            //    await next().ConfigureAwait(true);
            //});

            //app.UseStaticFiles();

            _logger.LogTrace("Use Authenitication");
            app.UseAuthentication();

            _logger.LogTrace("Initialize database");
            //Run migrations and create seed data
            dbInitializer.Initialize().Wait();


            _logger.LogTrace("Copy test data to Datafiles folder");
            string testfilesPath = config.Value.TestfilesPath;
            InitializeFileTestData.CopyTestData(testfilesPath, datafilesPath);

        }

        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        //{
        //    public ApplicationDbContext CreateDbContext(string[] args)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        builder.UseSqlServer(connectionString);
        //        return new ApplicationDbContext(builder.Options);
        //    }
        //}

        private void AddApplicationServices(IServiceCollection services, StartupLogger _logger)
        {
            // Add repositories
            services.AddSingleton<IGovBodyRepository, GovBodyRepositoryStub>();     // use stub
            services.AddSingleton<IMeetingRepository, MeetingRepositoryStub>();     // use stub
            services.AddSingleton<IViewMeetingRepository, ViewMeetingRepository>();
            services.AddSingleton<IAddtagsRepository, AddtagsRepository>();
            services.AddSingleton<IFixasrRepository, FixasrRepository>();

            _logger.LogTrace("Add Application services");

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IDbInitializer, DbInitializer>();
            services.AddTransient<MeetingFolder>();

            services.AddScoped<ValidateReCaptchaAttribute>();
        }


    }
}
