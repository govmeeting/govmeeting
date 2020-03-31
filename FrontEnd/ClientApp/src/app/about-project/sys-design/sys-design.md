<mat-card>
  <mat-card-title class="cardtitle">System Design</mat-card-title>

<markdown ngPreserveWhitespaces>

The diagrams below show the interaction between software components.

 The ClientApp is an Angular (2+) /Typescript single page application that runs in the browser. 
 
The web server and other server components are in C# using [DotNet Core](https://github.com/dotnet/core)  and [Asp.Net Core](https://github.com/aspnet/home)

Each server component is a separate dotnet project. WorkflowApp and WebApp are console applications. The other components are C# libraries.

___
## System  Design
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
## ClientApp Design
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

The structure of the ClientApp is best shown by its Angular Component structure

<table style="width:100%">
<tr><th colspan="2">App Components</th></tr>
<tr><td>Header</td><td>Header</td></tr>
<tr><td>Sidenav</td><td>Sidebar Navigation</td></tr>
<tr><td>Dashboard</td><td>Container for dashboard components</td></tr>
<tr><td>Documentation</td><td>Container for documentation pages</td></tr>
<tr><th colspan="2"> Dashboard components</th></tr>
<tr><td>Fixasr</td><td>Fix Auto Speech Recognition text</td></tr>
<tr><td>Addtags</td><td>Add tags to transcripts</td></tr>
<tr><td>ViewMeeting</td><td>View completed transcripts</td></tr>
<tr><td>Issues</td><td>View information on issues</td></tr>
<tr><td>Alerts</td><td>View and set information on alerts</td></tr>
<tr><td>Officials</td><td>View information on officials</td></tr>
<tr><td>(Others))</td><td>Other components to be implemented</td></tr>
<tr><th colspan="2"> Services</th></tr>
<tr><td>VirtualMeeting</td><td>Run virtual meeting</td></tr>
<tr><td>Chat</td><td>User chat component</td></tr>
</table>

___
## WebApp Design
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
## WorkflowApp Design
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

The status of the workflow for a specific meeting is kept in its Meeting record in the database. Each of the workflow components operates independently. They are each called in turn to check for available work. Each component will query the database for meetings matching their criteria for available work. If work is found, they will perform it and update the meeting's status in the database. 

In order to build a robust system, that can recover from failures, we need to treat steps in the workflow as "transactions". A transaction either completes fully or not at all. If there are  unrecoverable failures during a processing step, the state for that meeting rolls back to the last valid state. 

Pseudo code is given below for the components

* RetreiveOnlineFiles
  * Check schedule(s) for meeting(s) to retrieve
  * For each file to be retreived
    * Create database record for new meeting
    * set status=receiving, approved=false
  * When file(s) received:
    * set status=received, approved=false
    * Send manager(s) message: "Received"
* TranscribeRecordings
  * For recordings with sourcetype=recording, status=received, approved=true
    * Create work folder
    * set status=transcribing, approved=false
    * Transcribe recording
    * set status=transcribed, approved=false
    * Send manager(s) message: "Transcribed"
* ProcessTranscripts
  * For transcripts with sourcetype=transcript, status=received, approved=true
    * Create work folder
    * set status=processing, approved=false
    * Process transcript
    * set status=processed, approved=false
    * Send manager(s) message: "Processed"
* ProofreadRecording
  * For recordings with status=transcribed/approved=true
    * Create work folder
    * set status=proofreading, approved=false
    * Manual proofreading will now take place
  * For recordings with status=proofreading, approved=false
    * Check if proofreading appears complete. If so:
      * set status=proofread, approved = false
      * send manager(s) message: "Proofread"
* AddTagsToTranscript
  * For recordings with status=proofread, approved=true
  OR for transcripts with status=processed, approved=true
    * Create work folder
    * set status=tagging, approved=false
    * Manual tagging will now take place
  * For transcripts with status=tagging, approved=false
    * Check if tagging appears complete. If so:
      * set status=tagged, approved = false
      * send manager(s) message: "Tagged"
* LoadTranscript
  * for meetings with status=tagged, approved=true
    * set status=loading, approved=false
    * load contents of meeting into database
    * set status=loaded, approved=false
    * Send manager(s) message: "Loaded"

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
