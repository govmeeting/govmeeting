# Start Debugging

* Configured to use Firefox?
* Hit F12 in browser to bring up tools.
* Go to Console to see any loading errors.

* Launch with debug (F5 or IIS Express button) or non-debug (ctrl-F5)

* Using non-debug mode allows you to make code changes, save the file, refresh the browser, and see the code changes.
 Many developers prefer this for quickly launching the app and viewing changes.

 * Running dotnet commands
   Right-click "project.json" file (or other top level file) and select "Open Command Prompt)

* Test Secrets Manager tool: In command window enter: dotnet user-secrets -h

# The Build Environment

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


# Configuring servers in ASP.NET Core

See documentation at https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers