using GM.Application.AppCore.Common;
using GM.Application.AppCore.Interfaces;
using GM.Application.Configuration;
using GM.Infrastructure.FileDataRepositories.EditMeetings;
using GM.Infrastructure.FileDataRepositories.ViewMeetings;
using GM.Infrastructure.InfraCore.Data;
using GM.Utilities;
using GM.WebUI.WebApp.Services;
using GM.WebUI.WebApp.StartupCustomizations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System.IO;
using System.Net;
using System.Reflection;


namespace GM.WebUI.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment;
        private NLog.Logger logger;

        public Startup(IConfiguration _conf, IWebHostEnvironment _env,  NLog.Logger _logger)
        {
            Configuration = _conf;
            Environment = _env;
            logger = _logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            logger.Info($"ENV={Environment.EnvironmentName}");

            logger.Debug("AddControllers");
            services.AddControllers();

            logger.Debug("AddEndpointsApiExplorer");
            services.AddEndpointsApiExplorer();

            logger.Debug("AddSwaggerGen");
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Govmeeting webapp API"
                    // Description = "An ASP.NET Core Web API for managing ToDo items",
                    // TermsOfService = new Uri("https://example.com/terms"),
                    // Contact = new OpenApiContact
                    // {
                    //     Name = "Example Contact",
                    //     Url = new Uri("https://example.com/contact")
                    // },
                    // License = new OpenApiLicense
                    // {
                    //     Name = "Example License",
                    //     Url = new Uri("https://example.com/license")
                    // }
                });
            });

            logger.Debug("AddCors");
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            logger.Debug("ConfigureAppsettings");
            ConfigureAppsettings(services);

            logger.Debug("ConfigureDatabase");
            //ConfigureDatabase(services);
        }

        public void Configure(IApplicationBuilder app)
        {

            if (Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                logger.Debug("Is Development - UseSwagger & UseSwaggerUI");

                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                logger.Debug("Is Development - UseDeveloperExceptionPage & UseMigrationsEndPoint");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                logger.Debug("Is not Development - UseExceptionHandler & UseHsts");
            }

            app.UseHttpsRedirection();
            logger.Debug("UseHttpsRedirection");

            logger.Debug("UseCors");
            app.UseCors();

            logger.Debug("UseStaticFiles");
            app.UseStaticFiles();

            logger.Debug("UseRouting");
            app.UseRouting();

            logger.Debug("UseAuthorization");
            app.UseAuthorization();

            logger.Debug("UseEndpoints");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureDockerServices(IServiceCollection services)
        {
            services.AddDataProtection()
                .SetApplicationName("govmeeting")
                .PersistKeysToFileSystem(new DirectoryInfo(@"./"));
            ConfigureServices(services);
        }

        private void ConfigureAppsettings(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                // In development, some folders are siblings of the solution folder.
                if (Environment.IsDevelopment())
                {
                    myOptions.DatafilesPath = GMFileAccess.GetSolutionSiblingFolder(myOptions.DatafilesPath);
                    myOptions.TestdataPath = GMFileAccess.GetSolutionSiblingFolder(myOptions.TestdataPath);
                }    
                logger.Debug($"DatafilesPath: {myOptions.DatafilesPath}, TestdataPath: {myOptions.TestdataPath}");
            });
        }

        private void ConfigureDatabase(IServiceCollection services) {
            services.AddDatabaseDeveloperPageExceptionFilter();
            logger.Info("AddDatabaseDeveloperPageExceptionFilter");
            
            // We can choose to develop with a Postgres DB instead of the default IisExpress.
            // Note that if you switch, you need delete the Migrations folder in Infra_Core_Lib
            // and run "dotnet ef migrations --project ../../InfraCore_Lib Initial" from the WebApp folder.
            string dbType = Configuration["AppSettings:DatabaseType"];
            string connectionString = (dbType == "postgres") ?
                Configuration["AppSettings:PgConnectionString"] :
                Configuration["AppSettings:ConnectionString"];

            ConfigureDatabaseServices.Configure(services, Environment.EnvironmentName,
                dbType, connectionString);
            logger.Info($"Configure Database. Connection={connectionString}");

            // Hard code postgress - replace above code for degugging startup issues
            //string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Adm1nPa33;Database=Govmeeting2";
            //ConfigureDatabaseServices.Configure(services, Environment.EnvironmentName, "postgres", connectionString);
        }

    }


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace GM.WebUI.WebApp
// {


    public class XStartup
    {
        public XStartup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // NLog will set logger.Name to "GM.WebUI.WebApp.Startup"
        // This is the logger "name" that we can refer to in NLog.config
        NLog.Logger logger;
        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        // public void ConfigureDockerServices(IServiceCollection services)
        // {
        //     services.AddDataProtection()
        //         .SetApplicationName("govmeeting")
        //         .PersistKeysToFileSystem(new DirectoryInfo(@"./"));
        //     ConfigureServices(services);
        // }

        public void ConfigureServices(IServiceCollection services)
        {
            // // ConfigureLoggingService();
            // logger.Info("Configure Logging Service");
            // logger.Info($"ENV={Environment.EnvironmentName}");

            // ConfigureAppsettings(services);
            // logger.Info("Configure Appsettings");

            // // We can choose to develop with a Postgres DB instead of the default IisExpress.
            // // Note that if you switch, you need delete the Migrations folder in Infra_Core_Lib
            // // and run "dotnet ef migrations --project ../../InfraCore_Lib Initial" from the WebApp folder.
            // string dbType = Configuration["AppSettings:DatabaseType"];
            // string connectionString = (dbType == "postgres") ?
            //     Configuration["AppSettings:PgConnectionString"] :
            //     Configuration["AppSettings:ConnectionString"];

            // ConfigureDatabaseServices.Configure(services, Environment.EnvironmentName,
            //     dbType, connectionString);
            // logger.Info($"Configure Database. Connection={connectionString}");

            // // Hard code postgress - replace above code for degugging startup issues
            // //string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Adm1nPa33;Database=Govmeeting2";
            // //ConfigureDatabaseServices.Configure(services, Environment.EnvironmentName, "postgres", connectionString);

            // services.AddDatabaseDeveloperPageExceptionFilter();

//// LEFT OFF HERE WITH MERGING WITH NEW STARTUP

            services.AddHealthChecks();
            logger.Info("AddHealthChecks");

            //AUTH// StartupAuth.ConfigureIdentity(services, Configuration, logger);
            // logger.Info("ConfigureIdentity");

            services.AddControllersWithViews();
            logger.Info("Add services for Web API, MVC & Razor Views");

            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Govmeeting.api", Version = "v1" });
            // });
            // logger.Info("Add services for Swagger Document");

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
            services.AddTransient<IViewMeetingRepository, ViewMeetingRepository>();
            services.AddTransient<IEditMeetingRepository, EditMeetingRepository>();
            logger.Info("Add SeedDatabase, ViewMeetingRepository, EditMeetingRepository");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedDatabase seedDatabase)
        {
            logger.Info("Entering startup -> Configure");
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
                //app.UseDatabaseErrorPage();
                app.UseMigrationsEndPoint();
                logger.Info("Is Development - use dev exception page & database error page");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                logger.Info("Is not Development - use exception handler & HSTS");
            }

            app.UseHttpsRedirection();
            logger.Info("UseHttpsRedirection");

            app.UseStaticFiles();
            logger.Info("UseStaticFiles");

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
                logger.Info("If not dev, UseSpaStaticFiles");
            }

            app.UseRouting();
            logger.Info("UseRouting");

            // START OF ENDPOINT ZONE

            app.UseAuthentication();
            logger.Info("UseAuthentication");

            app.UseAuthorization();
            logger.Info("UseAuthorization");

            DebugCurrentEndpoint(app);
            logger.Info("DebugCurrentEndpoint");

            // END OF ENDPOINT ZONE

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"
                );
                logger.Info("endpoints.MapControllerRoute");

                endpoints.MapRazorPages();
                logger.Info("endpoints.MapRazorPages");
                //endpoints.MapHealthChecks("/health").RequireAuthorization();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                logger.Info("UseSwagger & UseSwaggerUI");
            }

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "clientapp";
                logger.Info("spa.Options.SourcePath");

                if (env.IsDevelopment())
                {
                    // spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    logger.Info("Is dev, spa.UseProxyToSpaDevelopmentServer");
                }
            });

            //seedDatabase.Seed();

        }

        // private void ConfigureAppsettings(IServiceCollection services)
        // {
        //     services.AddOptions();
        //     services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        //     services.Configure<AppSettings>(myOptions =>
        //     {
        //         logger.Info("Modify the configuration path options to be full paths.");
        //         // Modify the configuration path options to be full paths.
        //         myOptions.DatafilesPath = GetFullPathOnEitherDevOrProdSystem(myOptions.DatafilesPath);
        //         myOptions.TestdataPath = GetFullPathOnEitherDevOrProdSystem(myOptions.TestdataPath);
        //         logger.Info("DatafilesPath: {0}, TestdataPath: {2}",
        //             myOptions.DatafilesPath, myOptions.TestdataPath);
        //     });
        // }


        // Examine contents of endpoint of current request (for debugging)
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

        // /* GetFullPathOnEitherDevOrProdSystem is for creating/finding sibling folders to the project.
        // * These include: TESTDATA, DATAFILES, SECRETS.
        // * These folders must be outside the project folder so that they are not 
        // * included in the code repository.
        // * The names come from appsettings.json. In Development, this name is a
        // * sibling of the solution folder. But in production, it will normally be a rooted path.
        // * In production, we just return the path.
        // */
        // public string GetFullPathOnEitherDevOrProdSystem(string folder)
        // {
        //     if (Environment.IsDevelopment())
        //     {
        //         return GMFileAccess.GetSolutionSiblingFolder(folder);
        //     } else
        //     {
        //         return folder;
        //     }
        // }

    }
}
