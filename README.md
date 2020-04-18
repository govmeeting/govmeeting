<!-- Note the controller for this page is app/about-project/overview/overview.ts -->

<mat-card>
  <mat-card-title class="cardtitle">Overview</mat-card-title>

<markdown ngPreserveWhitespaces>

Public Meetings are the heart and soul of democracy. They are where citizens present opposing views and come to consensus on decisions that affect us all. 

In the Athenian Assembly of 500 BC, a quorum of 6,000 of the 43,000 citizens was needed to conduct business. In the 10th century, the Icelandic Althing was held in a natural outdoor amphitheater and all citizens could attend.

Today it is rare to see more than a dozen attendees at a council meeting in a town of 30,000 people. Is this still democracy? 

Meetings are sometimes broadcast on TV and some newspapers report on some issues. But still, most people know very litte about most of what goes on. 

The purpose of Govmeeting is give all citizens quick and easy access to what their politicians are doing and opportunities to affect their decisions.

## Features

Govmeeting will automatically:

* Retrieve online transcripts or recordings of government meetings.
* Transcribe the recordings using speech-to-text
* Process the transcripts into a standard format. 
* Load a relational database with the information in the transcripts

People will then be able to:

### Elect to receive after each meeting:

* A full transcript of the meeting.
* A summary of issues discussed.
* Alerts on specific issues.
* Alerts when a specific official speaks.
* Alerts on new proposed legislation.

### Go online and:

* Browse current and past meetings.
* Search meetings for issues discussed.
* Search for what a specific official said on issues.
* Search for voting results on legislation
* See statistics, graphs and charts on issues, legislature, etc.

<!-- 
<a href="http://www.govmeeting.org/overview#continue">Overview Continued</a>
 -->

<img src="images/mr-t-mrt-36834265-320-254-24kb.png" alt="Photo of Mr.T">
<!--This also works: ![Photo of Mr.T](images/mr-t-mrt-36834265-320-254-24kb.png) -->

Enough with the jibber-jabber, fool!
Show me how it works!

Well, the work is in progress. But here you can find [Demos of some working parts](http://govmeeting.org/dashboard) and more documentation.



# Developer Setup 
<a name="Contents"></a>
# Contents
* <a href="about?id=setup#InstallTools"> Install tools and clone repository </a>
* <a href="about?id=setup#DevelopVsCode"> Develop with VsCode </a>
* <a href="about?id=setup#DevelopVS"> Develop with Visual Studio </a>
* <a href="about?id=setup#DevelopOther"> Develop on other platforms </a>
* <a href="about?id=setup#Database"> Database </a>
* <a href="about?id=setup#GoogleCloud"> Google Cloud Platform account </a>
* <a href="about?id=setup#GoogleApi"> Google API Keys </a>

These documentation pages can be found in FrontEnd/ClientApp/src/app/assets/docs. Please make corrections there and issue
a <a href="https://github.com/govmeeting/govmeeting"> pull request on Gitub. </a>

--------------------------------------------------------------
<a name="InstallTools"></a>

# Install tools and clone repository <br/>
<a href="about?id=setup#Contents"> [Contents] </a>

* Install git.  <a href="https://gitforwindows.org"> Git for Windows </a>, <a href="https://git-scm.com/download/mac"> Git for Mac </a>
* Install <a href="https://nodejs.org/en/download/"> Node.js. </a>
* Install <a href="https://dotnet.microsoft.com/download"> .Net Core SDK. <a>

Open a console (teminal) window
* git clone https://github.com/govmeeting/govmeeting.git
* mkdir _SECRETS

The "_SECRETS" folder is for keys and passwords that are not stored in the public repository.

--------------------------------------------------------------
<a name="DevelopVsCode"></a>

# Develop with VsCode <br/>
<a href="about?id=setup#Contents"> [Contents] </a>

## Install VsCode
* Install <a href="https://code.visualstudio.com/download"> Visual Studio Code <a> and start it.
* Open extensions left side panel and install:
  * “Debugger for Chrome” by Microsoft
  * "C# for Visual Studio Code" by Microsoft
  * "SQL Server (mssql)" by Microsoft
  * "Todo Tree" by Gruntfuggly - shows TODO lines in code (optional)
  * "Powershell" by Microsoft - for debugging Powershell build scripts (optional)

## Debug/Run ClientApp & WebApp

* Open the Govmeeting folder in VsCode
* Open a terminal pane in VsCode
 * cd FrontEnd/ClientApp
 * npm install
 * npm start
* In debug panel, set launch configuration "WebApp & ClientApp-W"
* Press F5 (debug) or Ctrl-F5 (run without debugging)

The ClientApp will open in a browser.

* Click any of the "About" menu items to see the documentation.
* Click the location menu item "Boothbay Harbor". You will see the dashboard open for this location.

To verify that ClientApp is calling the WebApp API to retrieve data.

* Click "Proofread Transcript". You will see a video pane and transcribed text. Click the video play button.
* Click "Add Tags to Transcript". You will see a transcript of a meeting to be tagged.
* Click "View Latest Meeting". You will see a completed transcript for viewing.

Most of the other dashboard cards do not call WebApp but return test data.

ClientApp is served by the webpack-dev-server started with "npm start". 
WebApp uses the Kestrel server included in Asp.Net Core. The Kestrel server responds to Web API calls. But it proxies internal ClientApp requests to the webpack-dev-server.


## Debug/Run ClientApp standalone

* In app.module.ts, change "isAspServerRunning" from true to false.
 *  npm start
* In debug panel, set launch configuration "ClientApp"
* Press F5 (debug) or Ctrl-F5 (run without debugging)

When "isAspServerRunning" is set to false, stub services are used, instead of calling the WebApp API. This is useful for when we are only modifying code in ClientApp.

## Debug/Run WorkflowApp
* In debug panel, set launch configuration "WorkflowApp"
* Press F5 (debug) or Ctrl-F5 (run without debugging)

When the WorkflowApp starts it:
* Copies some test files into the Datafles/RECEIVED folder: a transcript PDF file and a recording MP4 file.
* Processes the transcript PDF file and creates a JSON file ready to be tagged.
* Process the recording MP4 file by transcribing it in the cloud and creates a JSON file ready to be proofread.

The results can be found in Datafiles/PROCESSING. However, you will first need to  setup a <a href="about?id=setup#GoogleCloud">Google Cloud account </a>, for the recording to be transcribed.

--------------------------------------------------------------
<a name="DevelopVS"></a>

# Develop with Visual Studio <br/>
<a href="about?id=setup#Contents"> [Contents] </a>

* Install  the free <a href="https://visualstudio.microsoft.com/free-developer-offers/"> Visual Studio Community Edition. </a>
*  During installation, select both the "ASP.NET" and the ".NET desktop" workloads.
* Install extensions:  (all by Mads Kristensen)
  * "NPM Task Runner"
  * "Command Task Runner"
  * "Markdown Editor"
* Open the solution file "govmeeting.sln"

## Debug/Run ClientApp & WebApp
* In Task Runner Explorer (ClientApp):
  * run "install"
  * run "start"
* Set startup project to "WebApp"
* Press F5 (debug) or Ctrl-F5 (run without debugging)
* WebApp will run and a browser will open, displaying the ClientApp.

NOTE: There is an issue with setting breakpoints in the Angular ClientApp in Visual Studio. See: <a href="https://github.com/govmeeting/govmeeting/issues/80"> Github issue #80 <a>

## Debug WorkflowApp
* Open the debug panel.
* Set startup project to "WorkflowApp"
* Press F5 (debug) or Ctrl-F5 (run without debugging)

Note: See notes for WorkflowApp under "Visual Studio Code"


--------------------------------------------------------------
<a name="DevelopOther"></a>

# Develop on other platforms <br/>
<a href="about?id=setup#Contents"> [Contents] </a>

In your profile, set the environment variable, ASPNETCORE_ENVIRONMENT, to "Development". This is used by WebApp and WorkflowApp.

## Build and run ClientApp

Execute:
- cd Frontend/ClientApp
- npm install
- npm start

Go to localhost:4200 in your browser. The client app will load.
Some features will not work until WebApp is running.

## Build and run WebApp with ClientApp

Execute:
* (do above: "Build & start ClientApp")
* cd ../../Backend/WebApp
* dotnet build webapp.csproj
* dotnet run bin/debug/dotnet2.2/webapp.dll

Go to localhost:5000 in your browser. The client app will load.

## Build and run ClientApp standalone

* In app.module.ts, change "isAspServerRunning" from true to false.
* (do above: "Build & start ClientApp")

## Build and run WorkflowApp

Execute:
* cd Backend/WorkflowApp
* dotnet build workflowapp.csproj
* dotnet run bin/debug/dotnet2.0/workflowapp.dll

Note: See notes for WorkflowApp under "Visual Studio Code"

<!-- END OF README SECTION -->

--------------------------------------------------------------

<a name="Database"></a>

# Database <br/>
<a href="about?id=setup#Contents"> [Contents] </a>

You may not need to install and setup the database. There are test stubs that substitute for calling database. See "Test Stubs" below.
 
## Install Provider

If you are using Visual Studio or Visual Studio Code, the Sql Server Express LocalDb provider is already installed. Otherwise do "LocalDb Provider Installation" below.

### LocalDb Provider Installation

Go to <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads"> Sql Server Express. </a>
For Windows, download the "Express" specialized edition of SQL Server. During installation, choose "Custom" and select "LocalDb".

LocalDb is available also for MacOs and Linux. If you install it for either platform, please update this document with the steps and do a Pull Request. 

### Other Providers

Besides LocalSb, EF Core supports <a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli"> other providers, </a> which you can use for development, including SqlLite. You will need to modify the DbContext setup in startup.cs and the connection string in
 appsettings.json. 


## Build Database Schema

The database is built via the "code first" feature of Entity Framework Core.  It examines the C# classes in the data model and automatically creates all tables and relations. There are two steps: (1) Create the "migrations" code for doing the update and (2) execute the update.

* cd Backend/WebApp
* dotnet ef migrations add initial --project ..\Database\DatabaseAccess_Lib 
* dotnet ef database update --project ..\Database\DatabaseAccess_Lib


## Explore the created database

###  In VsCode

Add the following to your user settings.json in VsCode:
```
    "mssql.connections": [
        {
          "server": "(localdb)\\mssqllocaldb",
          "database": "Govmeeting",
          "authenticationType": "Integrated",
          "profileName": "GMProfile",
          "password": ""
        }
      ],    

```
* Press ctrl-alt-D or press the Sql Server icon on left margin.
* Open the GMProfile connection to view & work with database objects.
* Open "Tables". You should see all tables created when you
built the schema above. This includes the AspNetxxxx tables 
for authorizaton and the tables for the Govmeeting data model.

### In Visual Studio

* Go to menu item: View -> SQL Server Object Explorer.
* Expand SQL Server -> (localdb)\MSSQLLocalDb -> Databases -> Govmeeting
* Open "Tables". You should see all tables created when you
built the schema above. This includes the AspNetxxxx tables 
for authorizaton and the tables for the Govmeeting data model.

### Other platforms

There is the cross-platform and open source <a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha"> SQL Operations Studio,</a> "a data management tool that enables working with SQL Server, Azure SQL DB and SQL DW from Windows, macOS and Linux." You can download <a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha"> SQL Operations Studio free here.</a> 

If you use this, or another tool, for exploring SQL Server databases, please update these instructions.

## Test Stubs

The code to store/retrieve transcript data in the database is not yet written. Therefore DatabaseRepositories_Lib uses static test data instead. In WebApp/appsettings.json, the property "UseDatabaseStubs" is set to "true", telling it to call the stub routines. 

However the user registration and login code in WebApp does use the database. It accesses the Asp.Net user authentication tables. WebApp authenticates API calls from ClientApp based on the current logged in user.

You can use the "NOAUTH" pre-processor value in WebApp to bypass authentication. Use one of these methods:
* In FixasrController.cs or AddtagsController.cs, un-comment the "#if NOAUTH" line at the top of the file.
* To disable it for all controllers, add this to WebApp.csproj:
```
    <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'>
    <DefineConstants>NOAUTH</DefineConstants>
    </PropertyGroup>
```
* In Visual Studio, go to WebApp property pages -> Build ->
and enter NOAUTH in the "Conditional Compiliation Symbols" box.

--------------------------------------------------------------
<a name="GoogleCloud"></a>

# Google Cloud Platform account <br/>
<a href="about?id=setup#Contents"> [Contents] </a>

To use the Google Speech APIs for speech-to-text conversion, you need a Google Cloud Platform (GCP) account. For most development work in Govmeeting, you will not need this. You can use existing test data.
To process new input, you will a GCP. The API recognizes more than 120 languages and variants.

Google provides developers with a free account which includes a credit (currently $300). The current cost of using the Speech API is free for up 60 minutes of conversion per month. After that, the cost for the "enhanced model" (which is what we need) is $0.009 per 15 seconds. ($2.16 per hour)

  * Open an account with [Google Cloud Platform](https://cloud.google.com/free/)

  * Go to the [Google Cloud Dashboard](http://console.cloud.google.com) and create a project. 

  * Go to the [Google Developer's Console](http://console.developers.google.com) and enable the Speech & Cloud Storage APIs 

  * Generate a "service account" credential for this project. Click on Credentials in developer's console.

  * Give this account "Editor" permissions on the project. Click on the account. On the next page, click Permissions.


  * Download the credential JSON file.

  * Put the file in the `_SECRETS` folder that you created when you cloned the repo.

  * Rename the file `TranscribeAudio.json`.

NOTE: The above steps may have changed slightly. If so, please update this document.

## Test Speech to Text transcription

  * Set the startup project in Visual Studio to `Backend/WorkflowApp`. Press F5.

  * Copy (don't move) one of the sample MP4 files from testdata to Datafiles/RECEIVED.

  The program will now recognize that a new file has appeared and start processing it.
  The MP4 file will be moved to "COMPLETED" when done. You will see the results in
  sufolders, which were created in the "Datafiles" directory.

  In appsettings.json, there is a property "RecordingSizeForDevelopment". It is currently
  set to "180". This causes the transcription routine in ProcessRecording_Lib to process only the first 180 seconds of the recording.

--------------------------------------------------------------
<a name="GoogleApi"></a>

# Google API Keys <br/>
<a href="about?id=setup#Contents"> [Contents] </a>

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

--------------------------------------------------------------
## Test reCaptcha

* Run the WebApp project.
* Click on "Register" in the upper right.
* The reCaptcha option should appear.

--------------------------------------------------------------

## Test Google Authentication

* Run the WebApp project.
* Click on "Login" in the upper right.
* Under "Use another service to log in", choose "Google".

