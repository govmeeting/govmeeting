# Govmeeting

Meetings are the heart and soul of democracy. They are where people  present opposing opinions on important issues and formally make final decisions. 

In the Athenian Assembly of 500 BC, a quorum of 6,000 of the 43,000 citizens was needed to conduct business. In the 10th century, the Icelandic Althing was held in a natural outdoor amphitheater and all citizens could attend.

Today it is rare to see more than a dozen attendees at a council meeting in a town of 30,000 people. Is this still democracy?

Some public meetings are broadcast on local TV.  But a very small percent of people actually watch. Local newspaper report on some issues. But they choose what to report and a small percentage read their local paper.

The few attending a meeting, including some council members, may strongly oppose a decision. But it is too easy for the council majority to totally ignore them. They know that less than one percent of the voters will ever hear what they said.

The purpose of this project is to preserve those discussions and make them easily available to all. It uses a combination of intelligent software and community volunteer effort.

Disillusion with government starts at the local level. Fixing this requires a grassroots effort at that level.

## Functional overview

Shortly after a government meeting takes place, you will be able to:
* Receive a summary of issues discussed via text message or email.
* Optionally receive a full transcript of the meeting via email.

At any time, you can go online and:
* Sign up to receive text alert or emails whenever a specific issue is discussed.
* Use a more powerful tool to browse a specific meeting.
* Search all past meetings for issues discussed.
* See all that was said in the past on any specific issues.
* See what any specific official said on any specific issue in all past meetings. This is especially helpful at election time.

For a detailed functional design, see: [Functional Design](https://github.com/govmeeting/govmeeting/wiki/functional-design)

<img src="images/mr-t-mrt-36834265-320-254-24kb.png" alt="Photo of Mr.T">
<!--This also works: ![Photo of Mr.T](images/mr-t-mrt-36834265-320-254-24kb.png) -->

 “Enough with the jibber-jabber, fool!
 Show me how it works!”

Well, the work is in progress. But here you can find some [Demos of working code](http://govmeeting.org).

## Technical overview

* Client application in Typescript and Angular(5).
* Server in C# and ASP.NET Core 2.0.
* Google Cloud and Speech API for voice recognition
* SQL database uses Entity Framework Core, code-first object model.

The "Core"version of ASP.NET Core and Entity Framework is open-source and runs on Windows, Mac and Linux.

For a detailed system design, see: [System Design](https://github.com/govmeeting/govmeeting/wiki/system-design)

## Quickstart

* Clone the repo: `git clone https://github.com/govmeeting/govmeeting.git`
or download zip file:`https://github.com/govmeeting/govmeeting/archive/master.zip`

If you only want to develop the front-end Angular / Typeacript code, there are stub routines for the Asp.Net WebApi calls, see [Develop Angular FrontEnd Only](#develop-angular-frontend-only).

To develop both the Angular front-end and the Asp.Net backend, you can use either Visual Studio or Visual Studio Code.

### Develop Angular front-end and/or Asp.Net server

The front-end is what you see at [govmeeting.org](govmeeting.org).

#### In Visual Studio

  * Open solution "govmeeting.sln"
  * Set startup project to `Web_App`. Press F5.
    You will need to wait for Nuget and NPM packages to be downloaded
    and all projects to be built. Your browser should open and display the front-end.


#### In Visual Studio Code

* Install Chrome

Install the following VS Code extensions:
* "Debugger for Chrome" by Microsoft
* "C# for Visual Studio Code" by Microsoft

Open the repository folder in VS Code.

In the debug panel, set the launch configuration to "Web_App & Chrome". Press F5. This configuration enables debugging both Typescript & C# in the same session. See: https://github.com/Microsoft/vscode-recipes/tree/master/Angular-SpaTemplates

#### Develop Angular FrontEnd Only

Open the "src/ClientApp" folder in your favorite editor (Sublime, VSCode, etc).

Change the following line in the file "src/ClientApp/src/app/app.module.ts" to use stub routines in place of the Asp.Net backend.

    const _isAspServerRunning = true;
to

    const _isAspServerRunning = false;

In the folder "src/ClientApp", run the following command:

    npm serve --open


### Develop Backend / Google Cloud Process

"Workflow_App" is a separate process which runs on the backend. It retrieves online recordings and transcripts of meetings. It call the Google Speech API to transcribe recordings. To use Google Cloud services, you need to first:  [Create a GCP project](https://github.com/govmeeting/govmeeting/wiki). Then:

#### In Visual Studio:
* Set startup project to `WorkFlow_App`. Press F5.

#### In VSCode
* Set the Launch Configuration to `WorkflowApp`. Press F5.

The first time that WorkflowApp is run, it will copy test data 

* Copy (don't move) either the either sample MP4 recording or PDF transcript files from testdata to Datafiles/RECEIVED.

The program will recognize that a new file has appeared and start processing it.
The results will appear in a new subdirectory in the Datafiles folder.







## Contacts
[![Join the chat at https://gitter.im/govmeeting/govmeeting](https://badges.gitter.im/govmeeting/govmeeting.svg)](https://gitter.im/govmeeting/govmeeting?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

<info@govmeeting.org>

