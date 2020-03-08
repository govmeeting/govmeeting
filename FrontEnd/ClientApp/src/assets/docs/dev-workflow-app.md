
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

## Improve speech Recognition


The more accurate the speech recognition, the less manual proofreading must be done.
The software use the Google Speech API. Multi-speaker conversational speech is challanging.
But the accuracy of the engine keeps improving.

There are means that we can use to improve the accuracy.

* We do not need to transcribe in real time. We can pre-process the audo to clirify it, remove extraneous sounds, etc.

*  There are a number of techniques that Google provides to increase accuracy:
  speech adaptation, custom dictionaries, phrase collections, etc.

