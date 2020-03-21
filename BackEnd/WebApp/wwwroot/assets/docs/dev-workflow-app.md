
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
But the accuracy is constantly improving.

Many people don't realize much closed-captioning text is not produced by a machine, but by a human. Specially trained people operate a system where they press keys that correspond to phonetic sounds. They are able to do this at real-time, at the same speed as the spoken text.


We do not need to transcribe in real time. Therefore  there are many ways to improve the accuracy.

We can pre-process the audio, to:
* Clarify the audo
* Remove extraneous sounds
* Normalize the volume

There are a number of Google API techniques available:
* speech adaptation
* custom dictionaries
* phrase collections

We can create a "feedback loop" over time. As users correct errors during proofreading, we can use these 
corrections to add to the list of words or phrases that are commonly mis-interprted.

We can add words or phrases commonly used in government to the dictionaries and collections.

We can add names of officials, of local places and other proper names to the dictionaries.

## Existing Transcripts

As new government entities are added, this software will need to be tweaked. Pages on which the data is found can greatly vary and will need some custumization. Once enough individual cases are properly handled, the software can be improved to start to handle new variants automatically.
