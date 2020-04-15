# Handle new Transcripts

Some cities produce transcripts of meetings. This allows us to skip transcribing the meeting ourselves. But it presents a different problem. Transcripts will not be in a standard format.

Our software will need to:
* Extract the information.
* Add tags that allow the information to be easily used.

Information normally in a transcript, which we want to extract are:
* Meeting information: Time, place, whether it is a special meeting. 
* Officials in attendance
* Section headings
* Each Speaker's Name and what they said. 

If no section headings are present, the software should be smart enough to determine where common sections start:
* Role call
* Invocation
* Committee Reports
* Introduction of Bills
* Resolutions
* Public Comment

We will need to see how well we can also extract voting results on bills and resolutions. Sometimes, the results are indicated by such phrases as "The ayes have it". Other times, a formal vote is taken where each official's name is read aloud and the person reponds with "aye" or "nay".

Superfluous information needs to be removed. For example: repeating headers or footers, line numbers and page numbers.


It is hoped that general code can be written that can extract information from new transcript that it has never. However,
until then, new code will need to be written to handle specific cases. 

Since it is normally only larger cities that produce transcripts:
* Most of the time we will be dealing with recordings of meetings.
* In a larger city, there are more likely computer programmers available capable of writing such code.

We could build a plug-in mechanism that would allow modules to be added that perform the extraction. We could allow the plugins to be written in many different languages: Python, Java, PHP, Ruby - in additon to the languages that the system is currently written in: Typescript and C#.

Currently the software only handles one case, Philadelphia, PA USA.
The project library "Backend\ProcessMeetings\ProcessTranscripts_lib" contains code for processing transcripts.

The class "Specific_Philadelphia_PA_USA" calls some general purpose routines to process transcripts for Philadelphia.

There is a stub class "Specific_Austin_TX_USA" meant for process an Austin, TX transcript. Perhaps somone would want to take a stab at completing this code. There is a test transcript in the Testdata folder.
But it is probably best to get the latest from their website: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm"> Austin, TX City Council </a>



# Modifying the Client Dashboard

## Add a card for new feature </h4>

*  At a terminal prompt, move to the folder: FrontEnd/ClientApp
*  Enter: ng generate component your-feature
*  Add your functionality to the files in : FrontEnd/ClientApp/src/app/your-feature
*  Insert a new gm-small-card or gm-large-card element in app/dash-main/dash-main.html.
*  Modify the icon, iconcolor, title, etc of the card element.
* If you need access to the name of the currently selected location and agency in your controller:
  * Add the location and agency input attributes to your feature element
  * Add location and agency @Input properties in your controller.

(See the other samples in dash-main.html)

## Re-arrange cards

1. Open the file: FrontEnd/ClientApp/src/app/dash-main/dash-main.html.
2. Change the card positions by
  changing the position of the gm-small-card or gm-large-card elements in this file.

# Logging

The log files for WebApp and WorkflowApp are in the folder "logs" at the root of the solution.
"nlog-all-(date).log" contains all the log messages including system.
"The file "nlog-own-(date).log" contains only the application messages.

At the top of many of the component files in ClientApp, a const "NoLog" is defined.
Change its value from true to false to turn on console logging for only that component.

