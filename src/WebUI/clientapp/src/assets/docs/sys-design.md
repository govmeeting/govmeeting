<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card>
  <mat-card-title class="cardtitle">Design</mat-card-title>

<markdown ngPreserveWhitespaces>

The diagrams below show the interaction between software components.

- clientapp is an Angular Typescript single page application that runs in the browser. It provides the user interface.

- WebApp is an [Asp.Net Core](https://github.com/aspnet/home) C# application that runs on the server. It responds to WebApi calls.

- WorkflowApp is a [DotNet Core](https://github.com/dotnet/core) C# application that runs on the server. It does batch processing of recordings and Transcripts. It could also be converted to a library that runs as part of the WebApp process.

- The other server components are DotNet Core C# libraries. They are used by both WebApp & WorkflowApp.

---

## System Design

</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

The components in the above diagram are:

<table style="width:100%">
<tr><th colspan="2"> Applications</th></tr>
<tr><td>clientapp</td><td>Angular SPA</td></tr>
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

---

## clientapp Design

</markdown>
<img src="assets/images/Flowchartclientapp.png">
<markdown ngPreserveWhitespaces>

The structure of the clientapp is best shown by its Angular Component structure

<table style="width:100%">
<tr><th colspan="2">App Components</th></tr>
<tr><td>Header</td><td>Header</td></tr>
<tr><td>Sidenav</td><td>Sidebar Navigation</td></tr>
<tr><td>Dashboard</td><td>Container for dashboard components</td></tr>
<tr><td>Documentation</td><td>Container for documentation pages</td></tr>
<tr><th colspan="2"> Dashboard components</th></tr>
<tr><td>Fixasr</td><td>Fix Auto Speech Recognition text</td></tr>
<tr><td>Addtags</td><td>Add tags to transcripts</td></tr>
<tr><td>ViewTranscript</td><td>View completed transcripts</td></tr>
<tr><td>Issues</td><td>View information on issues</td></tr>
<tr><td>Alerts</td><td>View and set information on alerts</td></tr>
<tr><td>Officials</td><td>View information on officials</td></tr>
<tr><td>(Others))</td><td>Other components to be implemented</td></tr>
<tr><th colspan="2"> Services</th></tr>
<tr><td>VirtualMeeting</td><td>Run virtual meeting</td></tr>
<tr><td>Chat</td><td>User chat component</td></tr>
</table>

---

## WebApp Design

</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

Each of the Web API's are small and call the repositories to put or get data from the database or filesystem.

<table style="width:100%">
<tr><th colspan="2"> Controllers</th></tr>
<tr><td>Fixasr</td><td>Save and get most recent version of transcript being proofread.</td></tr>
<tr><td>Addtags</td><td>Save and get most recent version of transcript being tagged.</td></tr>
<tr><td>Viewtranscript</td><td>Get latest completed trnascript.</td></tr>
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

---

## WorkflowApp Design

</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

The status of the workflow for a specific meeting is kept in its Meeting record in the database. Each of the workflow components operates independently. They are each called in turn to check for available work. Each component will query the database for meetings matching their criteria for available work. If work is found, they will perform it and update the meeting's status in the database.

In order to build a robust system, that can recover from failures, we will need to treat steps in the workflow as "transactions". A transaction either completes fully or not at all. If there are unrecoverable failures during a processing step, the state for that meeting rolls back to the last valid state. The code does not currently implement transactions. ( Gitub issue to follow )

Pseudo code is given below for the components

<ul>
<li> RetreiveOnlineFiles</li>
  <ul>
  <li> For all government entities in the system</li>
    <ul>
    <li> Check schedule(s) for meeting(s) to retrieve</li>
    <li> Retrieve either recording or transcript file</li>
    <li> Create work folder and move recording to folder</li>
    <li> Create database record</li> 
    <li> set status=received, approved=false</li>
    <li> Send manager(s) message: "Received"</li>
    </ul>
  <li> Files may also be placed in the Received folder by user upload.</li>
  </ul>
<li> TranscribeRecordings</li>
  <ul>
  <li> For recordings with sourcetype=recording, status=received, approved=true</li>
    <ul>
    <li> set status=transcribing, approved=false</li>
    <li> Transcribe recording</li>
    <li> set status=transcribed, approved=false</li>
    <li> Send manager(s) message: "Transcribed"</li>
    </ul>
  </ul>
<li> ProcessTranscripts</li>
  <ul>
  <li> For transcripts with sourcetype=transcript, status=received, approved=true</li>
    <ul>
    <li> Create work folder</li>
    <li> set status=processing, approved=false</li>
    <li> Process transcript</li>
    <li> set status=processed, approved=false</li>
    <li> Send manager(s) message: "Processed"</li>
    </ul>
  </ul>
<li> EditRecordingTranscription </li>
  <ul>
  <li> For recordings with status=transcribed/approved=true</li>
    <ul>
    <li> Create work folder</li>
    <li> set status=proofreading, approved=false</li>
    <li> Manual proofreading will now take place</li>
    </ul>
  <li> For recordings with status=proofreading</li>
    <ul>
    <li> Check if proofreading appears complete. If so:</li>
    <li> set status=proofread, approved = false</li>
    <li> send manager(s) message: "Proofread"</li>
    </ul>
  </ul>
<li> AddTagsToTranscript</li>
  <ul>
  <li> For recordings with status=proofread, approved=true
      OR for transcripts with status=processed, approved=true</li>
    <ul>
    <li> Create work folder</li>
    <li> set status=tagging, approved=false</li>
    <li> Manual tagging will now take place</li>
    </ul>
  </ul>
  <ul>
  <li> For transcripts with status=tagging</li>
    <ul>
    <li> Check if tagging appears complete. If so:</li>
    <li> set status=tagged, approved = false</li>
    <li> send manager(s) message: "Tagged"</li>
    </ul>
  </ul>
<li> LoadTranscript</li>
  <ul>
  <li> For meetings with status=tagged, approved=true
    <ul>
    <li> set status=loading, approved=false</li>
    <li> load contents of meeting into database</li>
    <li> set status=loaded, approved=false</li>
    <li> Send manager(s) message: "Loaded"</li>
    </ul>
  </ul>
</ul>

---

## User Secrets

User secrets that should not be in the code repository are kept in the "SECRETS" folder. It contains the following information:

- ClientId and ClientSecret for the Google external authorization service.
- SiteKey and Secret for the Google ReCaptcha service.
- Credentials for the Google Cloud Platform.
- Database connection string.
- Admin username and password.

The SECRETS folder may contain four files.

- appsettings.Development.json
- appsettings.Production.json
- appsettings.Staging.json
- TranscribeAudio.json

TranscribeAudio.json contains the Google Cloud Platform credentials. Each of other three files may contain settings for each of the other secrets. appsettings.Production.json should contain all of the setting for production. Whatever settings are in these file will overide those that are in Server/WebApp/app.settings.json. This file is inlcluded in the repository.

If you want your local machine to have access to the Google services, you need to create a local folder "../SECRETS in relation to where the repository is located. Then, for example, you can add a file "appsettings.Development.json" to it, which contains keys that you obtain from Google. See: [Google API Keys](home#google-api-keys)

---

# Documentation

Originally this documentation was kept in the Github Wiki pages.
But it was decided to move the pages into the main project itself, for two reasons:

- You cannot do a Pull Request for changes on Github Wiki pages. This makes it difficult
  for members of the community to change the documentation.
- The documentation will more likely stay in sync with the code if it is together with the
  code in the same repository. A single PR for code changes can include the documentation
  changes associated with it.

The documentation is written in Markdown and located in frontend/clientapp/src/app/assets/docs.

</markdown>

</mat-card>
