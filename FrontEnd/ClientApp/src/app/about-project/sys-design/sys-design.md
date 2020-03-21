<mat-card>
  <mat-card-title class="cardtitle">System Design</mat-card-title>

<markdown ngPreserveWhitespaces>

The diagrams below show the interaction between software components.
 The ClientApp is the Angular Single Page Application that runs in the browser. The other components run on the server.

Each server component is a  separate Visual Studio project. WorkflowApp and WebApp are console applications.
 The others are C# libraries.

There are separate diagrams for the WebApp and ClientApp internals.

___
## System  Flowchart
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

The components in the above diagram are:

<table style="width:100%">
<tr><th colspan="2"> Applications</th></tr>
<tr><td>ClientApp</td><td>Angular SPA</td></tr>
<tr><td>WebApp</td><td>Asp.Net  web server process</td></tr>
<tr><td>WorkflowApp</td><td>Workflow server control process</td></tr>
<tr><th colspan="2"> Libraries</th></tr>
<tr><td>GetOnlineFiles</td><td>Retrieve online transcripts and recordings</td></tr>
<tr><td>ProcessRecording</td><td>Extract & transcribe audio. Create work segments.</td></tr>
<tr><td>ProcessTranscript</td><td>Transform raw transcripts</td></tr>
<tr><td>LoadDatabase</td><td>Populate database with data from completed transcript</td></tr>
<tr><td>OnlineAccess</td><td>Routines to retrieve files from remote sites</td></tr>
<tr><td>GoogleCloudAccess</td><td>Routines to access Google Cloud services</td></tr>
<tr><td>FileDataRepositories</td><td>Store & Get JSON work file data</td></tr>
<tr><td>DatabaseRepositories</td><td>Store & Get Model data from database</td></tr>
<tr><td>DatabaseAccess</td><td>Access database using Entity Framework</td></tr>
</table>

___
## ClientApp Flowchart
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

The structure of the ClientApp is best shown by its Angular Component structure

<table style="width:100%">
<tr><th colspan="2">Main App Components</th></tr>
<tr><td>Header</td><td>Header</td></tr>
<tr><td>Sidenav</td><td>Sidebar Navigation</td></tr>
<tr><td>(router-outlet)</td><td>Where other component will be placed</td></tr>
<tr><th colspan="2"> Documentation components</th></tr>
<tr><td>About</td><td>Returns Markdown pages in assets/docs</td></tr>
<tr><td>Overview/SysDesign</td><td>Doc pages that have their own components</td></tr>
<tr><th colspan="2"> Dashboard components</th></tr>
<tr><td>Dashboard</td><td>Container for dashboard components</td></tr>
<tr><td>Fixasr</td><td>Fix Auto Speech Recognition text</td></tr>
<tr><td>Addtags</td><td>Add tags to transcripts</td></tr>
<tr><td>ViewMeeting</td><td>View completed transcripts</td></tr>
<tr><td>Issues</td><td>View information on issues</td></tr>
<tr><td>Alerts</td><td>View and set information on alerts</td></tr>
<tr><td>Officials</td><td>View information on officials</td></tr>
<tr><th colspan="2"> Services</th></tr>
<tr><td>VirtualMeeting</td><td>Run virtual meeting</td></tr>
<tr><td>Chat</td><td>User chat component</td></tr>
</table>



___
## WebApp Flowchart
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

Each of the Web API's are small and call the repositories to put or get data from the database or filesystem.

<table style="width:100%">
<tr><th colspan="2"> Controllers</th></tr>
<tr><td>Fixasr</td><td>Save and get most recent version of transcript being proofread.</td></tr>
<tr><td>Addtags</td><td>Save and get most recent version of transcript being tagged.</td></tr>
<tr><td>Viewmeeting</td><td>Get latest completed trnascript.</td></tr>
<tr><td>Govbodies</td><td>Save and get registered government body data.</td></tr>
<tr><td>Meetings</td><td>Save and get meeting information.</td></tr>
<tr><td>Video</td><td>Get video of meeting.</td></tr>
<tr><td>Account</td><td>Process user registration and login.</td></tr>
<tr><td>Manage</td><td>Users can manage their profiles.</td></tr>
<tr><td>Admin</td><td>Administrator can manage users, policies and claims</td></tr>
<tr><th colspan="2"> Services</th></tr>
<tr><td>Email</td><td>Handle registration email confirmation.</td></tr>
<tr><td>Message</td><td>Handle registration confirmation via text message .</td></tr>
</table>

___
## Frameworks

The Front-end is written in Typescript using Angular (2+).
The web server and backend are in C# using [DotNet Core](https://github.com/dotnet/core)  and [Asp.Net Core](https://github.com/aspnet/home)

___
## Application Environment

ASP.NET Core references a particular environment variable, ASPNETCORE_ENVIRONMENT to describe the environment the application is currently running in. This variable can be set to any value you like, but three values are used by convention: Development, Staging, and Production.

This value is set in the project properties under the Debug tab. It is used often in the Views\Shared cshtml files.

___
## User Secrets

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


--------------------------------------------------------------
# Documentation

Originally this documentation was kept in the Github Wiki pages.
But it was decided to move the pages into the main project itself, for two reasons:
* You cannot do a Pull Request for changes on Github Wiki pages. This makes it difficult
for members of the community to change the documentation.
* The documentation will more likely stay in sync with the code if it is together with the
code in the same repository. A single PR for code changes can include the documentation 
changes associated with it.

The documentation is written in Markdown and located in Frontend/ClientApp/src/app/assets/docs. 

</markdown>

</mat-card>
