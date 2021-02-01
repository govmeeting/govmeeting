<!-- Do not edit README.md. This file is built by Utilities/PsScripts/Build-ProjectReadme.ps1 -->

# Overview 

![Build frontend](https://github.com/govmeeting/govmeeting/workflows/Build%20frontend/badge.svg)
![Build Backend](https://github.com/govmeeting/govmeeting/workflows/Build%20Backend/badge.svg)<!-- START OF README SECTION -->

<!-- Note the controller for this page is app/about-project/overview/overview.ts -->

Public Meetings are the heart and soul of democracy. They are where citizens present opposing views and come to consensus on decisions that affect us all.

In the Athenian Assembly of 500 BC, a quorum of 6,000 of the 43,000 citizens was needed to conduct business. In the 10th century, the Icelandic Althing was held in a natural outdoor amphitheater and all citizens could attend.

Today it is rare to see more than a dozen attendees at a council meeting in a town of 30,000 people. Is this still democracy?

Meetings are sometimes broadcast on TV, but few watch them. Some newspapers report on some issues. But few people know most of what transacts during these meetings.

There are many fine people who enter public office in order to improve their communities. But the current opaque system makes it too easy for others to use the office to benefit themselves.

The purpose of Govmeeting is engage more people and provide more openness into the democratic process.

## Features

Govmeeting will automatically:

- Retrieve online transcripts or recordings of government meetings.
- Transcribe the recordings using speech-to-text
- Process the transcripts into a standard format.
- Load a relational database with the information in the transcripts

People will then be able to:

### Elect to receive after each meeting:

- A full transcript of the meeting.
- A summary of issues discussed.
- Alerts on specific issues.
- Alerts when a specific official speaks.
- Alerts on new proposed legislation.

### Go online and:

- Browse current and past meetings.
- Search meetings for issues discussed.
- Search for what a specific official said on issues.
- Search for voting results on legislation
- See statistics, graphs and charts on issues, legislature, etc.

<!-- 
<a href="https://www.govmeeting.org/overview#continue">Overview Continued</a>
 -->

<img src="images/mr-t-mrt-36834265-320-254-24kb.png" alt="Photo of Mr.T">
<!--This also works: ![Photo of Mr.T](images/mr-t-mrt-36834265-320-254-24kb.png) -->

Enough with the jibber-jabber, fool!
Show me how it works!

Well, the work is in progress. But click here for:  [Demos of some working code](https://govmeeting.org/dashboard) and more documentation.

<h4>
<div  style="float:left;">  
 Information or help: &nbsp; &nbsp;  <a href="https://join.slack.com/t/govmeeting/shared_invite/zt-gbuwp0tf-kqIOAeXqOTgzoauhSsqtNg"> Govmeeting Slack <img src="images/logo_slack25p.png"> </a> &nbsp; &nbsp; &nbsp;  </div>
 <div> <img style="vertical-align:middle; pointer-events: none; cursor: none;" src="images/GovmeetingEmail - crop 75p.png" alt="Govmeeting Email"> </div>
 <div style="clear: left;"/>
</h4><br/>

# Developer Setup 
<a name="Contents"></a>

# Contents

- <a href="#QuickStart"> Quick Start (no IDE) </a>
- <a href="#DevelopVsCode"> Develop with VsCode </a>
- <a href="#DevelopVS"> Develop with Visual Studio </a>
- <a href="#Database"> Database </a>
- <a href="#GoogleCloud"> Google Cloud Platform </a>
- <a href="#GoogleApi"> Google API Keys </a>

---

<a name="QuickStart"></a>

# Quick Start (no IDE) <br/>

<a href="#QuickStart"> [Contents] </a>

## Clone project

- Install git: <a href="https://gitforwindows.org"> Git for Windows </a>, <a href="https://git-scm.com/download/mac"> Git for Mac </a>
- git clone https://github.com/govmeeting/govmeeting.git

But if you may contribute, it's better to fork and clone your fork.

## Build / Run ClientApp

This is the Anglar front end app.

- Install <a href="https://nodejs.org/en/download/"> Node.js. </a>
- &gt; cd govmeeting/src/WebUI/WebApp/clientapp
- &gt; npm install
- &gt; npm start
- Open brower to localhost:4200.

## Run ClientApp tests

- &gt; cd govmeeting/src/WebUI/WebApp/clientapp
- &gt; npm run test:once &nbsp; &nbsp; &nbsp; ( run once )
- &gt; npm run test &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ( run in watch mode )

## Build all .NET projects

- Install <a href="https://dotnet.microsoft.com/download"> .Net Core SDK. </a>
- &gt; cd govmeeting
- &gt; dotnet build

## Run .NET tests

- &gt; cd govmeeting/src/WebUI/WebApp/clientapp
- &gt; dotnet test &nbsp; &nbsp; &nbsp; &nbsp; (ignore warnings about iTextSharp & NLog.Web)

## Run WebApp

This is the .NET Web API server.

- Leave Angular client running, but close browser.
- &gt; cd govmeeting/src/WebUI/WebApp
- &gt; dotnet run
- Browser will automatically open to localhost:5000.

## Run Workflow App

This standalone performs batch jobs such as downloading, processing and transcribing meeting recordings.

- &gt; cd govmeeting/src/Workflow/WorkflowApp
- &gt; dotnet run

---

<a name="DevelopVsCode"></a>

# Developing with Visual Studio Code <br/>

<a href="#Contents"> [Contents] </a>

## Install VsCode

- Install <a href="https://code.visualstudio.com/download"> Visual Studio Code </a> and start it.
- Install these extensions using the extensions panel on the left:
  - “Debugger for Chrome” by Microsoft
  - "C# for Visual Studio Code" by Microsoft
  - "SQL Server (mssql)" by Microsoft
  - "Todo Tree" by Gruntfuggly - shows TODO lines in code (optional)
  - "Powershell" by Microsoft - for debugging Powershell build scripts (optional)

## Build / Run ClientApp

This is the Anglar front end SPA.

- Open the project folder in VsCode
- Open a terminal pane
- &gt; cd src/WebUI/WebApp/clientapp
- &gt; npm install
- &gt; npm start
- Open a browser to localhost:4200

## Debug ClientApp

- &gt; npm start
- In the debug panel, set launch configuration "clientApp standalone"
- Press F5 (debug) or Ctrl-F5 (run without debugging)
- This will open a browser automatically.

## Build .NET projects

- Install <a href="https://dotnet.microsoft.com/download"> .Net Core SDK. </a>
- Select: View Menu -> Command Palette (Ctrl-shift-P) -> "Tasks: Run Task" ->
- Select: "build-dotnet" &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; (to build all projects)
- or Select: "build-webapp" &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; (to build webapp)
- or Select: "build-workflowapp" &nbsp; &nbsp; &nbsp; (to build workflowapp)

## Run / Debug WebApp

This is the .NET Web API server.

- In the debug panel, set launch configuration "WebApp"
- Press F5 (debug) or Ctrl-F5 (run without debugging)

## Run / Debug WebApp and ClientApp together

- "Run Angular App" as described above
- In the debug panel, set launch configuration "WebApp & ClientApp"
- Press F5 (debug) or Ctrl-F5 (run without debugging)
- A browser will automatically open and display the SPA at localhost:5000

## Run / Debug WorkflowApp

This standalone performs batch jobs such as downloading, processing and transcribing meeting recordings.

- In the debug panel, set launch configuration "WorkflowApp"
- Press F5 (debug) or Ctrl-F5 (without debugging)

## Notes

- The first time that the .NET projects are built, the NuGet packages are installed. If errors occur, re-run the build. NuGet packages are installed aysnchronously and there is a known race condition bug.
- The Angular App has a setting for whether it should call the Web API server or use stub data instead. The default is to stub data. To change this setting, change "isAspServerRunning" from false to true in src/WebUI/WebApp\clientapp\src\app\app.module.ts
- During development, ClientApp is served by webpack-dev-server. WebApp uses the Kestrel server for API calls. Kestrel proxies all non-API requests to webpack-dev-server.

---

<a name="DevelopVS"></a>

# Develop with Visual Studio <br/>

<a href="#Contents"> [Contents] </a>

- Install the free <a href="https://visualstudio.microsoft.com/free-developer-offers/"> Visual Studio Community Edition. </a>
- During installation, select both the "ASP.NET" and the ".NET desktop" workloads.
- Install extensions: (all by Mads Kristensen)
  - "NPM Task Runner"
  - "Command Task Runner"
  - "Markdown Editor"
- Open the solution file "govmeeting.sln"

## Run clientapp & WebApp

- Download the sub-folders from <a href="https://drive.google.com/drive/folders/1_I8AEnMNoPud7XZ_zIYfyGbvy96b-PyN?usp=sharing"> Google Drive. </a> Put them in a sibling folder to the project named "TESTDATA"
- In src/WebUI/WebApp/clientapp/app.module.ts, change "isAspServerRunning" from false to true.
- In Task Runner Explorer
  - Select: clientapp
  - run "install"
  - run "start"
- Set startup project to "WebApp"
- Press F5 (debug) or Ctrl-F5 (run without debugging)
- WebApp will run and a browser will open, displaying the clientapp.

NOTE: There is an issue with setting breakpoints in the Angular clientapp in Visual Studio. See: <a href="https://github.com/govmeeting/govmeeting/issues/80"> Github issue #80 </a>

## Run WorkflowApp

- Download the test files from Google Drive (see above)
- Open the debug panel.
- Set startup project to "WorkflowApp"
- Press F5 (debug) or Ctrl-F5 (run without debugging)

Note: See notes for WorkflowApp under "Visual Studio Code"

---

## Run WorkflowApp

Execute:

- cd src/Workflow/WorkflowApp
- dotnet build workflowapp.csproj
- dotnet run bin/debug/dotnet2.0/workflowapp.dll

Note: See notes for WorkflowApp under "Visual Studio Code"

<!-- END OF README SECTION -->

---

# Run WorkflowApp

- Install <a href="https://www.ffmpeg.org"> FFmpeg. </a>. This is for processing audio & video files.
- Download the test files from <a href="https://drive.google.com/drive/folders/1_I8AEnMNoPud7XZ_zIYfyGbvy96b-PyN?usp=sharing"> Google Drive. </a>
- In the debug panel, set launch configuration "WorkflowApp"
- Press F5 (debug) or Ctrl-F5 (run without debugging)

## Notes

When WorkflowApp first starts, it creates a folder "DATAFILES" and within it the following 3 sub-folders:

The following setting within appsettings.json tells it to copy test files to DATAFILES. The test files include a sample PDF transcript and an MP4 recording of meeetings.

        "InitializeWithTestData": true,

WorkflowApp pre-processes the transcript and produces a JSON file with the extracted data. If you have set up a <a href="#GoogleCloud">Google Cloud account, </a> it will transcribe the MP4 recording. You will find the results of both in the DATAFILES folder.

You will note that the initial MP4 transcript and its transcription are split into 3-minute work segments. This is to allow multiple volunteers to work simultaneously on proofreading the transcription.

## Process new recordings

Besides the test files on Google Drive, you can process your own recordings of meetings:

- Obtain a recording in mp4 format of a government meeting.
- Name the file as follows: "country_state_county_municipality_agency_language-code_date.mp4".
- For example: "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4".
- Put the file in "DATAFILES"
- In src/Workflow/WorkflowApp/appsettings.json, set the following properites:
  - "InitializeWithTestData": false
  - "RequireManagerApproval": false
- Run WorkflowApp.

If you have an Google Account set up, it will transcribe the recording.

## Process new transcripts

The goal is to eventually write code smart enough to process all transcript formats. But for now we need to add custom code for new formats. If your city, town, etc, produces transcripts of their meetings, it would be of great help if you contribute the code to handle those. Please see <a href="https://github.com/govmeeting/govmeeting/issues/93"> Github Issue #93 </a>

---

<a name="Database"></a>

# Database <br/>

<a href="#Contents"> [Contents] </a>

You may not need to install and setup the database in order to do development. There are test stubs that substitute for calling database. See "Test Stubs" below.

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

The database is built via the "code first" feature of Entity Framework Core. It examines the C# classes in the data model and automatically creates all tables and relations. There are two steps: (1) Create the "migrations" code for doing the update and (2) execute the update.

- cd src/WebUI/WebApp
- dotnet ef migrations add initial --project ..\Database\DatabaseAccess_Lib
- dotnet ef database update --project ..\Database\DatabaseAccess_Lib

## Explore the created database

### In VsCode

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

- Press ctrl-alt-D or press the Sql Server icon on left margin.
- Open the GMProfile connection to view & work with database objects.
- Open "Tables". You should see all tables created when you
  built the schema above. This includes the AspNetxxxx tables
  for authorizaton and the tables for the Govmeeting data model.

### In Visual Studio

- Go to menu item: View -> SQL Server Object Explorer.
- Expand SQL Server -> (localdb)\MSSQLLocalDb -> Databases -> Govmeeting
- Open "Tables". You should see all tables created when you
  built the schema above. This includes the AspNetxxxx tables
  for authorizaton and the tables for the Govmeeting data model.

### Other platforms

There is the cross-platform and open source <a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha"> SQL Operations Studio,</a> "a data management tool that enables working with SQL Server, Azure SQL DB and SQL DW from Windows, macOS and Linux." You can download <a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha"> SQL Operations Studio free here.</a>

If you use this, or another tool, for exploring SQL Server databases, please update these instructions.

## Test Stubs

The code to store/retrieve transcript data in the database is not yet written. Therefore DatabaseRepositories_Lib uses static test data instead. In WebApp/appsettings.json, the property "UseDatabaseStubs" is set to "true", telling it to call the stub routines.

However the user registration and login code in WebApp does use the database. It accesses the Asp.Net user authentication tables. WebApp authenticates API calls from clientapp based on the current logged in user.

You can use the "NOAUTH" pre-processor value in WebApp to bypass authentication. Use one of these methods:

- In FixasrController.cs or AddtagsController.cs, un-comment the "#if NOAUTH" line at the top of the file.
- To disable it for all controllers, add this to WebApp.csproj:

```
    <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'>
    <DefineConstants>NOAUTH</DefineConstants>
    </PropertyGroup>
```

- In Visual Studio, go to WebApp property pages -> Build ->
  and enter NOAUTH in the "Conditional Compiliation Symbols" box.

---

<a name="GoogleCloud"></a>

# Google Cloud Platform <br/>

<a href="#Contents"> [Contents] </a>

To use the Google Speech APIs for speech-to-text conversion, you need a Google Cloud Platform (GCP) account. For most development work in Govmeeting, you can use use existing test data. But if you want transcribe new recordings, you will a GCP. The Google API is able to transcribe recordings in more than 120 languages and variants.

Google provides developers with a free account which includes a credit (currently $300). The current cost of using the Speech API is free for up 60 minutes of conversion per month. After that, the cost for the "enhanced model" (which is what we need) is $0.009 per 15 seconds. (\$2.16 per hour)

- Open an account with [Google Cloud Platform](https://cloud.google.com/free/)

- Go to the [Google Cloud Dashboard](http://console.cloud.google.com) and create a project.

- Go to the [Google Developer's Console](http://console.developers.google.com) and enable the Speech & Cloud Storage APIs

- Generate a "service account" credential for this project. Click on Credentials in developer's console.

- Give this account "Editor" permissions on the project. Click on the account. On the next page, click Permissions.

- Download the credential JSON file.

- Create a `SECRETS` folder as sibling to the cloned project folder

- Put the credential file in SECRETS and rename it `TranscribeAudio.json`.

## Test Speech to Text transcription

- Set the startup project in Visual Studio to `src/Workflow/WorkflowApp`. Press F5.

- Copy (don't move) one of the sample MP4 files from testdata to DATAFILES/RECEIVED.

The program will now recognize that a new file has appeared and start processing it.
The MP4 file will be moved to "COMPLETED" when done. You will see the results in
sufolders, which were created in the "DATAFILES" directory.

In appsettings.json, there is a property "MaxRecordingSize". It is currently
set to "180". This causes the transcription routine in ProcessRecording_Lib to process only the first 180 seconds of the recording.

---

<a name="GoogleApi"></a>

# Google API Keys <br/>

<a href="#Contents"> [Contents] </a>

You will need these keys if you want to use or work on certain features of the registration and login process.

- ReCaptcha keys are needed to use ReCaptcha during user registration. They can be obtained at the [Google reCaptcha](https://developers.google.com/recaptcha/).
- OAuth 2.0 credentials are used to do external user login without the need for the user to created a personal account on the site. Visit the [Google API Console](https://console.developers.google.com/) to obtain credentials such as a client ID and client secret.

Create a `SECRETS` folder as sibling to the cloned project folder. Create a file in it named "appsettings.Development.json", with the following format.

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

Edit it to contain the keys that you just obtained:

---

## Test reCaptcha

- Run the WebApp project.
- Click on "Register" in the upper right.
- The reCaptcha option should appear.

---

## Test Google Authentication

- Run the WebApp project.
- Click on "Login" in the upper right.
- Under "Use another service to log in", choose "Google".

<a href="https://www.govmeeting.org/about?id=setup#continue">Setup Continued</a>

