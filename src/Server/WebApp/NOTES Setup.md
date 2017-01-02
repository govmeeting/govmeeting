**The Build Environment**

ASP.NET Core gets the value of the build environment from the environment variable, ASPNETCORE_ENVIRONMENT.
(Note that "environment" has two meanings in the last sentence.)
ASPNETCORE_ENVIRONMENT is set for each "profile" in "Project Properties -> Debug -> Environment Variables".
These settings are persisted to the file, Properties/launchSettings.json.
    The profiles refer to how the app is hosted:
    IISExpress  - uses IIS Express functioning as a reverse proxy server for Kestrel
    WebApp      - executes the app directly relying on Kestrel for self-hosting.
Whetether to use IIS & Kestrel or something else is set in program.cs via extension methods on WebHostBuilder.
See: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments for more info.
See: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers for info on hosting options.


**Configuring servers in ASP.NET Core**

Below is documentation from https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers
 
public static int Main(string[] args)
{
    // Add command line configuration source to read command line parameters.
    var config = new ConfigurationBuilder()
        .AddCommandLine(args)
        .Build();

    Server = config["server"] ?? "Kestrel";

    var builder = new WebHostBuilder()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseConfiguration(config)
        .UseStartup<Startup>();

    // The default listening address is http://localhost:5000 if none is specified.
    // Replace "localhost" with "*" to listen to external requests.
    // You can use the --urls flag to change the listening address. Ex:
    // > dotnet run --urls http://*:8080;http://*:8081

    // Uncomment the following to configure URLs programmatically.
    // Since this is after UseConfiguraiton(config), this will clobber command line configuration.
    //builder.UseUrls("http://*:8080", "http://*:8081");

    // If this app isn't hosted by IIS, UseIISIntegration() no-ops.
    // It isn't possible to both listen to requests directly and from IIS using the same WebHost,
    // since this will clobber your UseUrls() configuration when hosted by IIS.
    // If UseIISIntegration() is called before UseUrls(), IIS hosting will fail.
    builder.UseIISIntegration();

    if (string.Equals(Server, "Kestrel", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Running demo with Kestrel.");

        builder.UseKestrel(options =>
        {
            if (config["threadCount"] != null)
            {
                options.ThreadCount = int.Parse(config["threadCount"]);
            }
        });
    }
    else if (string.Equals(Server, "WebListener", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Running demo with WebListener.");

        builder.UseWebListener(options =>
        {
            // AllowAnonymous is the default WebListner configuration
            options.Listener.AuthenticationManager.AuthenticationSchemes =
                AuthenticationSchemes.AllowAnonymous;
        });
    }
}


**Port 0 binding with Kestrel***

Kestrel supports dynamically binding to an unspecified, available port by specifying port number 0 in UseUrls,
e.g. builder.UseUrls("http://127.0.0.1:0").
The IServerAddressesFeature can be used to determine which available port Kestrel actually bound to.

public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
{
    loggerFactory.AddConsole(Configuration.GetSection("Logging"));

    var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();

    app.UseStaticFiles();

    app.Run(async (context) =>
    {
        await context.Response.WriteAsync($"Hosted by {Program.Server}\r\n\r\n");

        if (serverAddressesFeature != null)
        {
            await context.Response.WriteAsync($"Listening on the following addresses: {string.Join(", ", serverAddressesFeature.Addresses)}\r\n");
        }

        await context.Response.WriteAsync($"Request URL: {context.Request.GetDisplayUrl()}");
    });
}

*/
