# Quick Notes

We will refer to the code repository folder as "REPOSITORY". This is where the .git folder is located.

### Build just the client app for production (not including server)

The bash script "build-publish.sh" in REPOSITORY will build and publish the release version.
Run this within the bash shell.

We are getting the following errors which can be ignored:
	dist\tmp\app\app.module.ts(40,22): error TS2339: Property 'APP_DATA' does not exist on type 'Window'.
	dist\tmp\app\fixasr\fixasr-utilities.ts(86,88): error TS2339: Property 'children' does not exist on type 'Node'.
	dist\tmp\app\fixasr\fixasr-utilities.ts(100,93): error TS2339: Property 'children' does not exist on type 'Node'.
	dist\tmp\app\fixasr\fixasr-utilities.ts(113,93): error TS2339: Property 'children' does not exist on type 'Node'.
	C:/GOVMEETING/_SOURCECODE/src/Client/BrowserApp/node_modules/videogular2/src/core/services/vg-api.d.ts(1,1): error TS2688: Cannot find type de             finition file for 'core-js'.
	C:/GOVMEETING/_SOURCECODE/src/Client/BrowserApp/node_modules/videogular2/src/core/vg-media/i-playable.d.ts(1,1): error TS2688: Cannot find typ             e definition file for 'core-js'.
Other errors that these need to be looked into.

### Publish to folder and test output

In Visual Studio, Right-click on WebApp and select Publish... --> Profile = PublishFolder --> Publish
The output should be in: REPOSITORY\src\Server\WebApp\bin\Release\PublishOutput

### Test the output

[ "Developer Command Prompt for Visual Studio 2017" is a separate utility installed with VS. 
   You can add screen icon to it. How do we open this in VS itself? ]
Open MSBuild Command Prompt in the publish output folder and execute:

    dotnet WebApp.dll

Open a browser to localhost:<port> where <port> is the port specified in the command window. Usually 5000.


# Details 

I created three publish profiles for WebApp within Visual Studio

* PublishFtp
* PublishFolder
* PublishWebdeploy


## User Secrets

During development, we have some configuration settings in the user secret store.
Specifically, we have the Google External Authorization secrets and the database connection string stored there.
We need to deploy these settings to production. We could set them as Environment variables on the server.
But ASP.NET Core has an easier way of dealing with secrets.

ConfigurationBuilder in startup.cs loads an optional file "appsettings.Production.json" if present. 
This file contains settings just used in Production. It can be stored outside the normal source code tree to avoid it being
 accidentally checked in during development. The file is copied to the published output folder during publishing.

The publish operation in Visual Studio gives us hooks where we can add customization.
For example if we create a publish profile named "ToFileSys",  two files will be created under Properties\PublishProfiles:
 * ToFileSys-publish.ps1  -  A powershell script which can be customized.
 * ToFileSys.pubxml  -  Properties that are passed to the PS script. This also can be customized.

During publishing, one of these hooks will copy the appsettings.Production.json file to the publish output directory.

During development there is an even simpler process. There is a "User Secret Store" where this information is stored.
ConfigurationBuilder in startup.cs does a call to AddUserSecrets() which adds this to the configuration information 
available to the process.


## Deploy to a local folder for testing

A Publish profile called "PublishFolder" was created in Visual Studio.

Connection  

	Publish Method = File System  
	Target location = .\bin\Release\PublishOutput  

Settings  

	Configuration = Release  
	Target Framework = .NETCoreApp,Version=v1.0  
	Target Runtime = Any  

### Build & publish client

Open a Bash shell and go to BrowserApp folder

    npm run build.prod

### Build & publish server

Right-click on WebApp and select Publish... --> Profile = PublishFolder --> Publish

### Copy files to the published folder

Copy appsettings.Production.json to the publish folder, as described in "User Secrets" above.

Copy the BrowserApp bundled CSS & JS files to the published output folder.

The following files are copied during publishing:

| Source file | Destination folder |  
| ----------- | ------------------ |  
| appsettings.Production.json | PublishOutput|  
| BrowserApp\dist\prod\css\main.css | PublishOutput\wwwroot\css |  
| BrowserApp\dist\prod\js\app.js | PublishOutput\wwwroot\js |  
| BrowserApp\dist\prod\js\shim.js | PublishOutput\wwwroot\js |  

### Test the deployment

Open MSBuild Command Prompt in the publish output folder and execute:

    dotnet WebApp.dll

   (The publish folder is REPOSITORY\src\Server\WebApp\bin\Release\PublishOutput)

Open a browser to localhost:<port> where <port> is the port specified in the command window. Usually 5000.



## Deploy to production with Ftp

A Publish profile called "PublishFtp" was created in Visual Studio with these settings.
This uses information from the hosting provider control panel:

Connection  

	Publish Method = FTP  
	Server = ftp://www.govmeeting.org  
	Site path = httpdocs (check "Passive Mode")  
	User name / password  
	Destination URL = http://www.govmeeting.org  

Settings  

	Configuration = Release  
	Target Framework = .NETCoreApp,Version=v1.0  
	Target Runtime = Any  
 
 


## Deploy to production with WebDeploy


### Links
https://www.iis.net/learn/publish/using-web-deploy/introduction-to-web-deploy


### Import the Publish Profile into Visual Studio

Get the Publish Profile from Plesk Control Panel
http://windowswebhostingreview.com/how-to-publish-using-web-deploy-with-plesk-control-panel/
https://technet.microsoft.com/en-us/library/dd568996(v=ws.10).aspx
http://windowswebhostingreview.com/how-to-publish-using-web-deploy-with-plesk-control-panel/

The following is the profile generated by ASPHostPortal for WebDeploy:

```
<?xml version="1.0"?>
<publishData>
  <publishProfile 
    profileName="govmeeting.org - Web Deploy"
    publishMethod="MSDeploy"
    publishUrl="govmeeting.org"
    msdeploySite="govmeeting.org"
    userName="user_name_on_account"
    destinationAppUrl="http://govmeeting.org"
    controlPanelLink="http://184.173.161.68"
  />
</publishData>
```

### Deploy the database


When the Web Deploy Publishing Settings are imported into Visual Studio, the database settings are not available.
In the Visual Studio Publish dialog, it says "No database found in the project", though it does have a database.
This may be because the Publish dialog does not yet handle ASP.NET Core apps, which store configuration differently.

Also support at AsPHostProtal said:
"If you are using ASP.NET Core, then you wont be able to use WebDeploy features.
 It is simply because .net Core hasnt been integrated with Plesk and we setup .net Core for you manually on the server."

 They said we could send them a backup file of the database from our local system to be restored on the server.
 But of course, we need an automatic way of deploying the initial database and future changes. 

 We will use Entity Framework Core migrations to deploy the database.
 In startup.cs, Database.Migrate() is called for the ApplicationDbContext.
 This occurs when the environment is set to "Production".

 ### Setting the environment

 ASP.NET Core uses the ASPNETCORE_ENVIRONMENT environment variable to determine the current environment.
 By default, if you run your application without setting this value, it will automatically default to the Production environment.

 In Windows environment variables can be set:

    1. At the command line (for future sessions): setx ASPNETCORE_ENVIRONMENT "Development"   
    2. With Powershell (for current session): $Env:ASPNETCORE_ENVIRONMENT = "Development" 
    3. In the windows control panel (for fture sessions).
    4. In Visual Studio's launchsettings.json for the desired profile:
         "environmentVariables": {"ASPNETCORE_ENVIRONMENT": "Development"}
    5. In the command aguments when the app is started:
      (startup.cs):   
        var config = new ConfigurationBuilder().AddCommandLine(args).Build();
      (program.cs):
        var host = new WebHostBuilder().UseConfiguration(config)    ...  

      When starting app:  dotnet run --environment "Staging"

      [ http://andrewlock.net/how-to-set-the-hosting-environment-in-asp-net-core/ ]

    6. If you are using IIS to host your application, it's possible to set the environment variables in your
       web.config file, but it is not the best practice:
```
      <aspNetCore processPath="%LAUNCHER_PATH%" arguments="%LAUNCHER_ARGS%"
        stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" forwardWindowsAuthToken="false">
        <environmentVariables>
            <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="QA" />
            <environmentVariable name="AnotherVariable" value="My Value" />
        </environmentVariables>
    </aspNetCore>
```

In OSX, .bash_profile can be edited to include:

    export ASPNETCORE_ENVIRONMENT=development  