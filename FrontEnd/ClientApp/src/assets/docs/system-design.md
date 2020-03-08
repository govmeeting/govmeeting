# System Flowcharts

The diagrams below show the interaction between software components. The ClientApp is the Angular Single Page Application that runs in the browser. The other components run on the server.

Each server component is a  separate Visual Studio project. Workflow_App and Web_App are console applications . The others are C# libraries.

There are separate diagrams for the Web_app and ClientApp internals.

[[https://github.com/govmeeting/govmeeting/blob/master/images/FlowchartSystem.png|alt=System flowchart]]

The components in the above diagram are:

```
* ClientApp            - Angular SPA
* Web_App              - Asp.Net  web server process
* Workflow_App         - Workflow control process
* GetOnlineFiles       - Retrieve online transcripts and recordings
* ProcessRecording     - Extract & transcribe audio. Create work segments.
* ProcessTranscript    - Transform raw transcripts 
* LoadDatabase         - Populate database with data from completed transcript
* OnlineAccess         - Routines to retrieve files from remote sites.
* GoogleCloudAccess    - Routines to access Google Cloud services
* FileDataRepositories - Store & Get JSON work file data
* DatabaseRepositories - Store & Get Model data from database
* DatabaseAccess       - Access database using Entity Framework
```

### ClientApp Flowchart

[[https://github.com/govmeeting/govmeeting/blob/master/images/FlowchartClientApp.png|alt=ClientApp flowchart]]
```
* appmodule               - tell Angular how to construct and bootstrap the app
* app-routing & navmenu   - Angular component router and  navigation bar
* home                    - default first page
* volunteer               - first page for registered user
* fixasr                  - page to fix Auto Speech Recognition text
* video                   - component to play video file for fixasr
* addtags                 - page to add tag metadata to transcript
* register                - page to register a government body
* viewmeeting             - public page to view a completed transcript
* searchmeeting           - public page to search meeting databae
* setalerts               - public page to set alerts on future meeting events
* gmshared and models     - shared components and data models
```

### WebApp Flowchart

[[https://github.com/govmeeting/govmeeting/blob/master/images/FlowchartWebApp.png|alt=WebApp flowchart]]

```
* Home Controller         - Home controller serves page with root Angular tag
* Account Controller      - Process user registration and login
* Manage Controller       - Users can manage their profiles
* Admin Controller        - Administrator can manage users, policies and claims
* Web API Controllers     - Each of these are small and merely get or put data to the
                            database or filesystem.
* Email Service           - Handle registration email confirmation
* Message Service         - Handle registration confirmation via text message 
```

# Frameworks

The Front-end is written in Typescript using Angular (2+).
The web server and backend are in C# using [DotNet Core](https://github.com/dotnet/core)  and [Asp.Net Core](https://github.com/aspnet/home)

The current framework of the Angular app uses the Microsoft [Angular SPAtemplate](https://docs.microsoft.com/en-us/aspnet/core/spa/angular?tabs=visual-studio). Prior to this we used [Mgechev/angular-seed](https://github.com/mgechev/angular-seed) and then later [Angular CLI](https://cli.angular.io/). You can see the steps here that were used to first [Migrate to CLI](https://stackoverflow.com/a/47229442/1978840) and later [Migrate to SPATemplate](https://stackoverflow.com/questions/46665314/migrating-an-existing-angular4-cli-to-net-core-2-angular-template-project/47256341#47256341).d

The Typescript/Angular2 projects can be developed independent of the ASP.NET server. The Angular ClientApp in located at Server/WebApp/ClientApp. The calls to the ASP.NET web api can be replaced with stubs. See the notes in the [providers] section of ClientApp/src/app.module.shared.ts.

# Angular and Asp.Net

The Angular app gets loaded by Asp.Net as follows:

Features\Shared\_Layout.cshtml renders the contents of the Asp.Net pages.

    <div class="container body-content">
        @RenderBody()
    </div>

The Home page, Features\Home\index.cshtml, renders the Angular app and includes the packed Angular Javascript files.

	<app-root >Loading...</app-root>
	<script src="~/dist/vendor.js" asp-append-version="true"></script>
	<script src="~/dist/main-client.js" asp-append-version="true"></script>

# Angular app startup

The Angular app is started in the normal way. The file paths below are all relative to the WebApp folder.

webpack.config.js defines the Angular entry point.

    entry: { 'main-client': './ClientApp/boot.browser.ts' }

ClientApp\boot.browser.ts defines the Angular module to bootstrap.

	const modulePromise = platformBrowserDynamic().bootstrapModule(AppModule);

ClientApp\app\app.module.browser.ts defines the root component.

	bootstrap: [ AppComponent ],

ClientApp\app\app.component.ts defines the root selector and templateUrl.

    templateUrl: './app.component.html',
    ...
	selector: 'app-root',


ClientApp\app\app.component.html displays the navbar and router outlet elements.

	<gm-navbar></gm-navbar>
    <router-outlet></router-outlet>


# Application Environment

ASP.NET Core references a particular environment variable, ASPNETCORE_ENVIRONMENT to describe the environment the application is currently running in. This variable can be set to any value you like, but three values are used by convention: Development, Staging, and Production.

This value is set in the project properties under the Debug tab. It is used often in the Views\Shared cshtml files.

# User Secrets

When you clone the govmeeting repository from Github, you get everything except the "_SECRETS" folder. This folder resides outside the repository. It contains the following "secret" information:

* ClientId and ClientSecret for the Google external authorization service.
* SiteKey and Secret for the Google ReCaptcha service.
* Credentials for the Google Cloud Platform.
* Database connection string.
* Admin username and password.

The _SECRETS folder may contain four files.

* appsettings.Development.json
* appsettings.Production.json
* appsettings.Staging.json
* TranscribeAudio.json

TranscribeAudio.json contains the Google Cloud Platform credentials. Each of other three files may contain settings for each of the other secrets. appsettings.Production.json should contain all of the setting for production. Whatever settings are in these file will overide those that are in Server/WebApp/app.settings.json. This file is inlcluded in the repository.

If you want your local machine to have access to the Google services, you need to create a local folder "../_SECRETS in relation to where the repository is located. Then, for example, you can add a file "appsettings.Development.json" to it, which contains keys that you obtain from Google. See: [Google API Keys](home#google-api-keys)

# Folder Structure

```
├── ExternalLibraries          <- external libraries (except Nuget)
├── images                     <- image files
├── packages                   <- Nuget packages
└── src                        <- source code of the application
|    ├── ClientApp               <- Angular Frontend App
|    |    ├── app                 <- source
|    |    |   ├── about     	   <- About page
|    |    |   ├── addtags   	   <- Feature for adding tags to transcript
|    |    |   ├── app-routing      <- routing module
|    |    |   ├── fixasr    	   <- Feature for fixing auto speech recognition text
|    |    |   ├── home      	   <- Homepage
|    |    |   ├── meeting   	   <- Feature for viewing  a meeting transcript
|    |    |   ├── navmenu   	   <- Navigation menu
|    |    |   ├── shared    	   <- shared services, directives and components
|    |    |   ├── test             <- test module that comes with Angular release
|    |    |   ├── temppages        <- temp pages used only during development
|    |    |   ├── video            <- show a video
|    |    |   └── volunteer        <- volunteer collaboration page
|    |    ├── assets              <- static assets
|    ├── Configuration_Lib            <- Shared configuration
|    ├── DatabaseAccess_Lib           <- Class library project for database access
|    ├── DatabaseModel_Lib            <- Code-first C# model classes for E.F.
|    ├── DatabaseRepositories_Lib     <- Repositories level access to database
|    ├── FileDataModel_Lib            <- Formats of the JSON work files
|    ├── FileDataRepositories_Lib     <- Repositories level access to files
|    ├── LoadDatabase_Lib             <- load a completed transcript file into database
|    ├── ProcessRecording_Lib         <- process recording: extract audio, transcribe, etc
|    ├── ProcessTranscript_Lib        <- process transcripts: Standardize and save as JSON
|    ├── Web_App                      <- Web Server
|    |    ├── Data                   <- DbContext & Migrations
|    |    ├── Features               <- (We organize asp.net code by feature.)
|    |    │    ├── Account            <- Handle Register & Login
|    |    │    ├── Addtags            <- Server API for adding tags to transcript
|    |    │    ├── Fixasr             <- Server API for fixing auto speech recognition text
|    |    │    ├── Admin              <- Administer users and user claims
|    |    │    ├── Home               <- Home page
|    |    │    ├── Manage             <- Users management of their accounts
|    |    │    ├── Meetings           <- Server API for viewing meeting transcript
|    |    │    ├── Shared             <- partial page layouts and other shared code
|    |    │    └── Video              <- controller for serving videos
|    |    ├── node_modules            <- ClientApp node modules
|    |    ├── Properties              <- launch settings
|    |    ├── Services                <- our shared services
|    |    ├── StartupCustomizations   <- (Here we specify our use of Features.)
|    |    └── wwwroot                 <- static content
|    └── WorkFlow_App           <- workflow control of entire application
└── utilities
     ├── Deploy_App                <- Devops tool for deploying
     └── KeepWebsiteAlive_App      <- Simple utility to ping govmeeting.org
```