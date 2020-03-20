[ All these instructions were tested so far on Windows only. If you install elsewhere, or if there are errors or ommissions in this document, please edit the file FrontEnd/ClientApp/src/app/assets/docs/dev-setup.md and issue
a <a href="https://github.com/govmeeting/govmeeting"> pull request on Gitub </a> ]

---
## Requirements

* Install git. There are many options for this. EG: <a href="https://gitforwindows.org"> Git for Windows </a>
* Install <a href="https://nodejs.org/en/download/"> Node.js. </a>
* Install <a href="https://dotnet.microsoft.com/download"> .Net Core SDK. <a>

---
## Clone the repository

Execute:
* git clone https://github.com/govmeeting/govmeeting.git
* mkdir _SECRETS

The "_SECRETS" folder is for keys and passwords that are not stored in the public repository.

---
## Develop with VsCode

### Installation
* Install <a href="https://code.visualstudio.com/download"> Visual Studio Code <a>
* Open the Govmeeting folder in VsCode
* Install extensions:
  * “Debugger for Chrome” by Microsoft
  * "C# for Visual Studio Code" by Microsoft
  * "SQL Server (mssql)" by Microsoft
  * "Todo Tree" by Gruntfuggly - shows TODO lines in code (optional)

### Build & start ClientApp
* In a terminal pane, execute:
 - cd FrontEnd/ClientApp
 - npm start

### Debug ClientApp & WebApp together
* (do above: "Build & start ClientApp")
* Open the debug panel.
* Set launch configuration "WebApp & ClientApp"
* Press F5

WebApp responds to Web API calls. But it proxies internal client requests to the dev server started with "npm start".

### Debug ClientApp standalone
* In app.module.ts, change "isAspServerRunning" from true to false.
* (do above: "Build & start ClientApp")
* Open the debug panel.
* Set launch configuration "ClientApp"
* Press F5

### Debug WorkflowApp
* Open the debug panel.
* Set launch configuration "WorkflowApp"
* Press F5

### Notes
* You can also press Shift-F5 to run without debug.
* We could change the "WebApp & ClientApp" configuration
 so that we don't need to manually run "npm start" first.
 But there is an advantage to not doing this. ClientApp
gets live updates when we change code. But WebApp does not.
Forcing the ClientApp server to start & stop, whenever WebApp starts & stops, would slow down development.


---
## Develop with Visual Studio

* Install  the free <a href="https://visualstudio.microsoft.com/free-developer-offers/"> Visual Studio Community Edition. </a>
*  During installation, select both the "ASP.NET" and the ".NET desktop" workloads.
* Install extensions:  (all by Mads Kristensen)
  * "NPM Task Runner"
  * "Command Task Runner"
  * "Markdown Editor"
* Open the solution file "govmeeting.sln"

### Build & start ClientApp
* Open terminal pane and execute:
 - cd FrontEnd/ClientApp
 - npm start
* OR in Task Runner Explorer (WebApp) run "Run-ClientApp"
* OR in Task Runner Explorer (ClientApp) run "start"

### Debug ClientApp & WebApp together
* (do above: "Build & start ClientApp")
* Set startup project to "WebApp"
* Click F5
* WebApp will run and a browser will open, displaying the ClientApp.

NOTE: There is an issue with setting breakpoints in the Angular ClientApp in Visual Studio. See: <a href="https://github.com/govmeeting/govmeeting/issues/80"> Github issue #80 <a>

### Debug WorkflowApp
* Open the debug panel.
* Set startup project to "WorkflowApp"
* Click F5

### Notes - see notes for Visual Studio Code


---
## Develop - outside an IDE

### Build and run ClientApp

Execute:
- cd Frontend/ClientApp
- npm install
- npm start

Go to localhost:4200 in your browser. The client app will load.
Some features will not work until WebApp is running.

### Build and run WebApp with ClientApp

Execute:
* (do above: "Build & start ClientApp")
* cd ../../Backend/WebApp
* dotnet build webapp.csproj
* dotnet run bin/debug/dotnet2.2/webapp.dll

Go to localhost:5000 in your browser. The client app will load.

### Build and run ClientApp standalone

* In app.module.ts, change "isAspServerRunning" from true to false.
* (do above: "Build & start ClientApp")

### Build and run WorkflowApp

Execute:
* cd Backend/WorkflowApp
* dotnet build workflowapp.csproj
* dotnet run bin/debug/dotnet2.0/workflowapp.dll

---
## Create database 

If you are using Visual Studio or Visual Studio Code, the Sql Server Express LocalDb provider is already installed. Otherwise do 
"LocalDb Provider Installation" below.

### LocalDb Provider Installation

Go to <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads"> Sql Server Express. </a>
For Windows, download the "Express" specialized edition of SQL Server. During installation, choose "Custom" and select "LocalDb".

LocalDb is available also for MacOs and Linux. If you install it for either platform, please update this document with the steps and do a Pull Request. 

### Other Providers

Besides LocalSb, EF Core supports <a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli"> other providers, </a> which you can use for development, including SqlLite. You will need to modify the DbContext setup in startup.cs and the connection string in
 appsettings.json. 


##  Build database schema
* cd Backend/WebApp
* dotnet ef migrations add initial --project ..\Database\DatabaseAccess_Lib 
* dotnet ef database update --project ..\Database\DatabaseAccess_Lib

All calls to the database are done through Entity Framework Core. EF uses the "code first" approach to build the database schema. It examines the C# classes in the data model and automatically creates the database tables and their relations.

---
# Documentation

Originally this documentation was kept in the Github Wiki pages.
But it was decided to move the pages into the main project itself, for two reasons:
* You cannot do a Pull Request for changes on Github Wiki pages. This makes it difficult
for members of the community to change the documentation.
* The documentation will more likely stay in sync with the code if it is together with the
code in the same repository. A single PR for code changes can include the documentation 
changes associated with it.

The documentation is written in Markdown and located in Frontend/ClientApp/src/app/assets/docs. 
 
---
 # Google Cloud Platform account

To work with the Google Speech APIs locally from your own computer, you need a Google Cloud Platform (GCP) account. Google was providing developers with a free account which includes a credit. For this project, you will only9 be using the Speech API and not per-cost servies like App Engine or Compute engines. Therefore, you will most likely not even accrue charges that you would need your credit for.

  * Open an account with [Google Cloud Platform](https://cloud.google.com/free/)

  * Go to the [Google Cloud Dashboard](http://console.cloud.google.com) and create a project. 

  * Go to the [Google Developer's Console](http://console.developers.google.com) and enable the Speech & Cloud Storage APIs 


  * Generate a "service account" credential for this project. Click on Credentials in developer's console.


  * Give this account "Editor" permissions on the project. Click on the account. On the next page, click Permissions.


  * Download the credential JSON file.


  * Put the file in the `_SECRETS` folder that you created when you cloned the repo.

  * Rename the file `TranscribeAudio.json`.

NOTE: The above steps may have changed slightly. If so, please update this document.

---
## Test GCP setup

  * Set the startup project in Visual Studio to `Backend/WorkflowApp`. Press F5.


  * Copy (don't move) one of the sample MP4 files from testdata to Datafiles/INCOMING.

  The program will now recognize that a new file has appeared and start processing it.
  The MP4 file will be moved to "COMPLETED" when done. You will see the results in
  sufolders, which were created in the "Datafiles" directory.

---
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

---
## Test reCaptcha

* Run the WebApp project.
* Click on "Register" in the upper right.
* The reCaptcha option should appear.

---
## Test Google Authentication

* Run the WebApp project.
* Click on "Login" in the upper right.
* Under "Use another service to log in", choose "Google".
