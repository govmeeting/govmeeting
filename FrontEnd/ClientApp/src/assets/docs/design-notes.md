# Modifying the Client Dashboard

## Add a new new card for new feature </h4>

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

# Workflow App

The  project "WorkflowApp" in folder "govmeeting/BackEnd/WorkflowApp" does all the auto-processing of recordings and transcripts.
It also co-ordinates manual processing with auto-processing.

When the project runs, it watches for new files to arrive into the folder "Datafiles/TO_PROCESS".

If the new file is a video,
it does speech recognition to produce a transcript. The transcript can be found in the "Datafiles/WORK" folder in a subfolder named after
the government agency whose meeting it is for. This transcript is
now ready to be proofread.

If the new file is text (.pdf or .txt), it processes it and
produces a JSON object that has the contents of the transcript in a structured format.
Separate fields in this object will contain spoken text, the name of the speaker, setion name, etc.

While processing it outputs trace files to the Datafiles/WORK folder. Each trace file contains the complete text of the transcript, after each particular fix is applied.
Therefore if the final fixed transcript contains strange or invalid text, it is easy to trace
back to where those errors were introduced.
