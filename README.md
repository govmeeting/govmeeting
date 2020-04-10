# Govmeeting

Public Meetings are the heart and soul of democracy. They are where citizens present opposing views and come to consensus on decisions that affect us all. 

In the Athenian Assembly of 500 BC, a quorum of 6,000 of the 43,000 citizens was needed to conduct business. In the 10th century, the Icelandic Althing was held in a natural outdoor amphitheater and all citizens could attend.

Today it is rare to see more than a dozen attendees at a council meeting in a town of 30,000 people. Is this still democracy? 

Meetings are sometimes broadcast on TV and some newspapers report on some issues. But still, most people know very litte about most of what goes on. 

The purpose of Govmeeting is give all citizens quick and easy access to what their politicians and opportunities to affect their decisions.

## Functional overview

Govmeeting will automatically:

* Retrieve online transcripts or recordings of government meetings.
* Transcribe the recordings using speech-to-text
* Process the transcripts into a standard format. 
* Load a relational database with the information in the transcripts

At this point, point will be able to do:

Set preferences for receiving the following after each meeting:

* Full transcript of the meeting.
* Summary of issues discussed.
* Alerts on specific issues.
* Alerts when a specific official speaks.
* Alerts on new proposed legislation.


At any time, people can go online and:
* Browse current and past meetings.
* Search meetings for issues discussed.
* Search for what a specific official said on issues.
* Search for voting results on legislation


# Developer Setup
[ All these instructions were tested so far on Windows only. If you install elsewhere, or if there are errors or ommissions in this document, please edit the file FrontEnd/ClientApp/src/app/assets/docs/dev-setup.md and issue
a <a href="https://github.com/govmeeting/govmeeting"> pull request on Gitub </a> ]

--------------------------------------------------------------
# Requirements

* Install git. There are many options for this. EG: <a href="https://gitforwindows.org"> Git for Windows </a>
* Install <a href="https://nodejs.org/en/download/"> Node.js. </a>
* Install <a href="https://dotnet.microsoft.com/download"> .Net Core SDK. <a>

--------------------------------------------------------------
# Clone the repository

Execute:
* git clone https://github.com/govmeeting/govmeeting.git
* mkdir _SECRETS

The "_SECRETS" folder is for keys and passwords that are not stored in the public repository.

--------------------------------------------------------------
# Develop with VsCode

## Installation
* Install <a href="https://code.visualstudio.com/download"> Visual Studio Code <a>
* Open the Govmeeting folder in VsCode
* Install extensions:
  * “Debugger for Chrome” by Microsoft
  * "C# for Visual Studio Code" by Microsoft
  * "SQL Server (mssql)" by Microsoft
  * "Todo Tree" by Gruntfuggly - shows TODO lines in code (optional)

## Build & run ClientApp

In a terminal pane, execute:
 - cd FrontEnd/ClientApp
 - npm install
 - npm start

## Debug ClientApp & WebApp together
* Run: npm start
* Open the debug panel.
* Set launch configuration "WebApp & ClientApp"
* Press F5

WebApp responds to Web API calls. But it proxies internal client requests to the dev server started with "npm start".

## Debug ClientApp standalone
* In app.module.ts, change "isAspServerRunning" from true to false.
* Run: npm start
* Open the debug panel.
* Set launch configuration "ClientApp"
* Press F5

## Debug WorkflowApp
* Open the debug panel.
* Set launch configuration "WorkflowApp"
* Press F5

## Notes

We dont run "npm start" from the launch configuration ""WebApp & ClientApp" so that we can start or stop either one independently.


--------------------------------------------------------------
# Develop with Visual Studio

* Install  the free <a href="https://visualstudio.microsoft.com/free-developer-offers/"> Visual Studio Community Edition. </a>
*  During installation, select both the "ASP.NET" and the ".NET desktop" workloads.
* Install extensions:  (all by Mads Kristensen)
  * "NPM Task Runner"
  * "Command Task Runner"
  * "Markdown Editor"
* Open the solution file "govmeeting.sln"

## Build & start ClientApp
* Open terminal pane and execute:
 - cd FrontEnd/ClientApp
 - npm start
* OR in Task Runner Explorer (ClientApp) run "start"

## Debug ClientApp & WebApp together
* (do above: "Build & start ClientApp")
* Set startup project to "WebApp"
* Click F5
* WebApp will run and a browser will open, displaying the ClientApp.

NOTE: There is an issue with setting breakpoints in the Angular ClientApp in Visual Studio. See: <a href="https://github.com/govmeeting/govmeeting/issues/80"> Github issue #80 <a>

## Debug WorkflowApp
* Open the debug panel.
* Set startup project to "WorkflowApp"
* Click F5

## Notes - see notes for Visual Studio Code


--------------------------------------------------------------
# Develop - other platforms

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


Additional setup instructions can be found in the repository.
You can view it when you run the ClientApp.
World
