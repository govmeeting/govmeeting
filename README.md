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


# Developer Setup 
These documentation pages can be found in FrontEnd/ClientApp/src/app/assets/docs. Please make corrections there and issue
a <a href="https://github.com/govmeeting/govmeeting"> pull request on Gitub. </a>

--------------------------------------------------------------
# Install tools and clone repository

* Install git.  <a href="https://gitforwindows.org"> Git for Windows </a>, <a href="https://git-scm.com/download/mac"> Git for Mac </a>
* Install <a href="https://nodejs.org/en/download/"> Node.js. </a>
* Install <a href="https://dotnet.microsoft.com/download"> .Net Core SDK. <a>

Open a console (teminal) window
* git clone https://github.com/govmeeting/govmeeting.git
* mkdir _SECRETS

The "_SECRETS" folder is for keys and passwords that are not stored in the public repository.

--------------------------------------------------------------
# Develop with VsCode

## Install VsCode
* Install <a href="https://code.visualstudio.com/download"> Visual Studio Code <a> and start it.
* Open extensions left side panel and install:
  * “Debugger for Chrome” by Microsoft
  * "C# for Visual Studio Code" by Microsoft
  * "SQL Server (mssql)" by Microsoft
  * "Todo Tree" by Gruntfuggly - shows TODO lines in code (optional)

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

The results can be found in Datafiles/PROCESSING. 

--------------------------------------------------------------
# Develop with Visual Studio

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
# Develop on other platforms

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


When you install and run ClientApp, you will find additional setup instructions on its Setup documentation page.

