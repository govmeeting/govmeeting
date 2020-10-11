using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Logging;
using NLog;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.WebApp.StartupCustomizations;
//using GM.DatabaseRepositories;
using GM.DatabaseAccess;
using GM.FileDataRepositories;
using GM.WebApp.Services;
using GM.Utilities;
using Microsoft.Extensions.Hosting;
//using GM.DatabaseRepositories_Stub;
using GM.DatabaseAccess_Stub;

namespace GM.WebApp
{
    public partial class Startup
    {
        // https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-2
        // https://github.com/NLog/NLog/wiki/Configuration-file#log-levels
        NLog.Logger logger;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //####################################
            // Set a variable in the gdc which is be used in NLog.config for the
            // base path of our app: ${gdc:item=appbasepath} 
            string logfilesPath = GMFileAccess.GetFullPath(Configuration["AppSettings:LogfilesPath"]);
            GlobalDiagnosticsContext.Set("logfilesPath", logfilesPath);

            //####################################
            // Create an instance of NLog.Logger manually here since it is not available
            // from dependency injection yet.
            logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            logger.Info("Just set value in GDC for NLog and created NLog.Logger instance");

            //####################################
            logger.Info("Configure AppSettings options");
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                logger.Info("Modify the configuration path options to be full paths.");
                logger.Info("LogfilesPath = " + myOptions.LogfilesPath);
                logger.Info("DatafilesPath = " + myOptions.DatafilesPath);
                logger.Info("TestdataPath = " + myOptions.TestdataPath);

                logger.Info("Start modifying.");
                // Modify the configuration path options to be full paths.
                myOptions.LogfilesPath = GMFileAccess.GetFullPath(myOptions.LogfilesPath);
                myOptions.DatafilesPath = GMFileAccess.GetProjectSiblingFolder(myOptions.DatafilesPath);
                myOptions.TestdataPath = GMFileAccess.GetProjectSiblingFolder(myOptions.TestdataPath);
                logger.Info("Done modifying.");
            });

            //####################################
            logger.Info("Add ApplicationDbContext");
            services.AddTransient<DBOperations>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["AppSettings:ConnectionString"]
                    //sqlServerOptions => sqlServerOptions.MigrationsAssembly("DatabaseAccess_Lib")
                    //sqlServerOptions => sqlServerOptions.MigrationsAssembly("WebApp")
                    ));

            //####################################
            logger.Info("Add Add Authentication");
            ConfigureAuthenticationServices(services, logger);

            //####################################
            logger.Info("Add Razor pages");
            services.AddRazorPages();

            //services.AddMvc()
            //    // The ContractResolver option is to prevent the case of Json field names 
            //    // being changed when retrieved by client.
            //    // https://codeopinion.com/asp-net-core-mvc-json-output-camelcase-pascalcase/
            //    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
            //    .AddXmlSerializerFormatters();

            //####################################
            logger.Info("Enable Feature Folders");
            // https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureLocationExpander());
            });

            //logger.Info("Add SPA static files");
            //// In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "../../frontend/clientapp/dist";
            //    //configuration.RootPath = "ClientApp/dist";
            //});

            //####################################
            logger.Info("Add Application services");
            bool UseDatabaseStubs = (Configuration["AppSettings:UseDatabaseStubs"] == "True");
            AddApplicationServices(services, logger, UseDatabaseStubs);


            //####################################
            logger.Info("Add Configuration services");
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            //IHostingEnvironment env,
            IDbInitializer dbInitializer,
            //ILoggerFactory loggerFactory,
            IOptions<AppSettings> config
            )
        {
            string datafilesPath = config.Value.DatafilesPath;

            // for testing
            logger.Info("2 + 2 is " + dbInitializer.GetFour());

            logger.Info("Environment is " + env.EnvironmentName);
            logger.Info("WebRootPath is " + env.WebRootPath);

            //####################################
            logger.Info("Configure exception handler");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //####################################
            logger.Info("Configure DefaultFiles & StaticFiles");
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-3.1
            app.UseDefaultFiles();
            app.UseStaticFiles();

            //####################################
            logger.Info("Configure datafiles PhysicalFileProvider. Path = " + datafilesPath);
            // Add a PhysicalFileProvider for the DATAFILES folder. Until we have a way to serve video files to 
            // videogular via the API, we need to allow these to be accessed as static files.
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    datafilesPath),
                RequestPath = "/datafiles"
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});
            // https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-3.1&tabs=visual-studio

            //####################################
            logger.Info("Configure routing");
            app.UseRouting();

            //####################################
            // UseAuthentication must come between UseRouting & UseEndpoints
            // so that route information is available for authentication decisions
            // and before accessing the endpoints.
            logger.Info("Use Authenitication & Authorization");
            app.UseAuthentication();
            app.UseAuthorization();

            //####################################
            logger.Info("Configure Endpoint routing");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //Fix controller endpoints.This give err in HomeController / Index about "no file provider"
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //####################################
            // Use during debugging to check the route metadata.
            //app.Use(async (context, next) =>
            //{
            //    var endPoint = context.GetEndpoint();
            //    var routes = context.Request.RouteValues;
            //});

            //####################################
            logger.Info("Proxy calls to a separate dev server during development");
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                //spa.Options.SourcePath = "../../frontend/clientapp";
                //spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    //spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //// OLD CODE - Is this relevant?
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

            //####################################
            logger.Info("Initialize database");
            //Run migrations and create seed data
            bool migrateDatabase = false;
            dbInitializer.Initialize(migrateDatabase).Wait();


            //####################################
            logger.Info("Copy test data to DATAFILES folder");
            if (!Directory.Exists(datafilesPath))
            {
                Directory.CreateDirectory(datafilesPath);
                Directory.CreateDirectory(datafilesPath + "/RECEIVED");
                Directory.CreateDirectory(datafilesPath + "/PROCESSING");
                Directory.CreateDirectory(datafilesPath + "/COMPLETED");
            }
            string testfilesPath = config.Value.TestdataPath;
            InitializeFileTestData.CopyTestData(testfilesPath, datafilesPath);
        }


        private void AddApplicationServices(IServiceCollection services, NLog.Logger logger, bool UseDatabaseStubs)
        {
            logger.Info("Add database repositories");

            if (UseDatabaseStubs)
            {
                services.AddSingleton<IDBOperations, DBOperationsStub>();
            }
            else
            {
                services.AddSingleton<IDBOperations, DBOperations>();
            }

            logger.Info("Add file data repositories");

            services.AddSingleton<IViewMeetingRepository, ViewMeetingRepository>();

            logger.Info("Add email and sms");

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            logger.Info("Add DbInitializer");

            //services.AddTransient<IDbInitializer, DbInitializer>();
            services.AddTransient<IDbInitializer, DbInitializer_Stub>();

            logger.Info("Add MeetingFolder");

            //services.AddTransient<MeetingFolder>();

            logger.Info("Add ValidateReCaptchaAttribute");

            services.AddScoped<ValidateReCaptchaAttribute>();
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
    }
}
