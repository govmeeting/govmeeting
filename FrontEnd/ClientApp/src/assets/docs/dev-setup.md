## Clone the repository

* Install git

There are many options for this. The author uses: <a href="https://gitforwindows.org"> Git for Windows </a>


Then in a terminal window, execute:
```
    > git clone https://github.com/govmeeting/govmeeting.git
    > mkdir _SECRETS
```

The "_SECRETS" folder is for keys and passwords that are not stored in the public repository.

## All development environments

* Install <a href="https://nodejs.org/en/download/"> Node.js. </a>
* Install <a href="https://dotnet.microsoft.com/download"> .Net Core SDK. <a>

## Developing with VsCode

### Installation
* Install <a href="https://code.visualstudio.com/download"> Visual Studio Code <a>
* Open the root folder of Govmeeting in VsCode
* Install extensions:
  * “Debugger for Chrome” by Microsoft
  * "C# for Visual Studio Code" by Microsoft
  * "SQL Server (mssql)" by Microsoft
  * "Todo Tree" by Gruntfuggly - shows TODO lines in code (optional)

### Run in debug mode
* Open the debug panel.
* Set the launch configuration to the app(s) that you want to debug:
  * "WebApp & ClientApp" - debug both simultaneously
  * "WorkflowApp", "ClientApp" or "WebApp" - debug single app 
* Click the run icon.

### Run in non-debug mode
* Open a terminal panel

* Open a Chrome browser to: "locahost:4200"

## Developing with Visual Studio

* Install  the free <a href="https://visualstudio.microsoft.com/free-developer-offers/"> Visual Studio Community Edition. </a>
  During installation, select both the "ASP.NET" and the ".NET desktop" workloads.
* Install extensions:  (all by Mads Kristensen)
  * "NPM Task Runner"
  * "Command Task Runner"
  * "Markdown Editor"
* Open the solution file "govmeeting.sln"
* Set the start-up project to WebApp.
* In Task Runner Explorer for WebApp, execute "Run-ClientApp".
* Press F5 to start debugging.

WebApp will start running and a browser will open, displaying the ClientApp.

To run WorkflowApp, set it as the startup project and press F5.

NOTE: There is an issue with debugging ClientApp in Visual Studio. See:
 <a href="https://github.com/govmeeting/govmeeting/issues/80"> Github issue #80 <a>

## Standalone Development

Setup is divided into four parts: ClientApp, WebApp, WorkflowApp and Database.

If you want to work only on the Angular/Typescript ClientApp, you can just build and run ClientApp.
 It will use test data, instead of making API calls to WebApp.

If you want to work on the C# ASP.NET Core Web API, you can build and run WebApp.

If you want to work on the C# .NET Core app for transcipt processing, you can build and run WorkflowApp.

If you want WebApp and/or WorkflowApp to use the database for data, you need to install and build the database.

## Build and run ClientApp

* Install node

```
    > cd govmeeting/Frontend/ClientApp
    > npm install
    > npm start
```
Go to localhost:4200 in your browser. The client app will load. (as from govmeeting.org).

By default, ClientApp uses local test data.


## Build and run WebApp

* Install .Net Core

To tell ClientApp to call the Web API, instead of using test data, in ClientApp/app/src/app.module.ts,  change:
```
    let isAspServerRunning = false;
  to:
    let isAspServerRunning = true;
```
Then execute:
```
    > cd govmeeting/Frontend/ClientApp
    > npm start
    > cd ../../Backend/WebApp
    > dotnet build webapp.csproj
    > dotnet run bin/debug/dotnet2.0/webapp.dll
```
Go to localhost:5000 in your browser. The client app will load.

WebApp responds to Web API calls. But it proxies internal client requests to the dev server started with "npm start".

## Build and run WorkflowApp
```
    > cd govmeeting/Backend/WorkflowApp
    > dotnet build workflowapp.csproj
    > dotnet run bin/debug/dotnet2.0/workflowapp.dll
```

## Install database provider


### [stand-alone installation]

Go to <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads"> Sql Server Express. </a>
For Windows, download the "Express" specialized edition of SQL Server. During installation, choose "Custom" and select "LocalDb".

LocalDb is available also for MacOs and Linux. If you install it for either platform, please update this document and do a Pull Request. 

### Other options

EF Core supports <a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli"> other providers besides LocalDb </a> that you can use, including SqlLite. You will need to modify the DbContext setup in startup.cs -> 


##  Build database schema
```
    > cd govmeeting/Backend/WebApp
    > dotnet ef migrations add initial --project ..\Database\DatabaseAccess_Lib 
    > dotnet ef database update --project ..\Database\DatabaseAccess_Lib
```

All calls to the database are done through Entity Framework Core. EF uses the "code first" approach to build the database schema. It examines the C# classes in the data model and automatically creates the database tables and their relations.




# Documentation

Originally this documentation was kept in the Github Wiki pages.
But it was decided to move the pages into the main project itself, for two reasons:
* You cannot do a Pull Request for changes on Github Wiki pages. This makes it difficult
for members of the community to change the documentation.
* The documentation will more likely stay in sync with the code if it is together with the
code in the same repository. A single PR for code changes can include the documentation 
changes associated with it.

The documentation is written in Markdown and located in Frontend/ClientApp/src/app/assets/docs. 
 

 # Google Cloud Platform account

If you want call the Google Speech APIs locally from your own computer, you need a Google Cloud Platform (GCP) account. Google was providing developers with a free account which includes a credit. For this project, you will just be using the Speech API and not per-cost servies like App Engine or Compute engines. Therefore, you will most likely not even accrue charges that you would need your credit for.

  * Open an account with [Google Cloud Platform](https://cloud.google.com/free/)

  * Go to the [Google Cloud Dashboard](http://console.cloud.google.com) and create a project. 

  * Go to the [Google Developer's Console](http://console.developers.google.com) and enable the Speech & Cloud Storage APIs 


  * Generate a "service account" credential for this project. Click on Credentials in developer's console.


  * Give this account "Editor" permissions on the project. Click on the account. On the next page, click Permissions.


  * Download the credential JSON file.


  * Put the file in the `_SECRETS` folder that you created when you cloned the repo.

  * Rename the file `TranscribeAudio.json`.

NOTE: The above steps may have changed slightly. If so, please update this document.


## Test GCP setup

  * Set the startup project in Visual Studio to `govmeeting/Backend/WorkflowApp`. Press F5.


  * Copy (don't move) one of the sample MP4 files from testdata to Datafiles/INCOMING.

  The program will now recognize that a new file has appeared and start processing it.
  The MP4 file will be moved to "COMPLETED" when done. You will see the results in
  sufolders, which were created in the "Datafiles" directory.

# Google API Keys

You will need these keys if you want to use or work on certain features of the registration and login process.

* ReCaptcha keys are needed to use ReCaptcha during user registration. They can be obtained at the [Google reCaptcha]( https://developers.google.com/recaptcha/).
* OAuth 2.0 credentials are used to do external user login without the need for the user to created a personal account on the site. Visit the  [Google API Console](https://console.developers.google.com/) to obtain credentials such as a client ID and client secret.


Create a file named "appsettings.Development.json" in the "_SECRETS" folder. It should contain the keys that you just obtained:

    {
     "ExternalAuth": {
    	"Google": {
		     "ClientId": "your-client-Id",
		     "ClientSecret": "your-client-secret"
        }
      },
      "ReCaptcha:SiteKey": "your-site-key",
      "ReCaptcha:Secret": "your-secret"
    }

## Test reCaptcha

* Run the WebApp project.
* Click on "Register" in the upper right.
* The reCaptcha option should appear.

## Test Google Authentication

* Run the WebApp project.
* Click on "Login" in the upper right.
* Under "Use another service to log in", choose "Google".
