This project pre-processes transcript files obtained from original sources. 

If a government body does offer transcipts of it's meetings, they could be in many different formats.

* They may come as PDFs, plain text files or even as  scrapes of HTML screens.
* There will be various ways to indicate the start of spoken text and the name of the speaker.
* The file may or may not contain:
	* line numbers
	* page headers or footers
	* indications of the time elapsed from start of meeting
	* a list of the officials present

The code in this project needs to:
	* convert the file to a standard text file
	* remove unneeded text like page footers, headers and line numbers. 
Then it needs to parse the text to find:
	* meeting designations
	* date and time of start of meeting
	* list of officials present (if this is available)
	* start of meeting sections, for example "introductions", "committee reports", etc
	* the start of each spoken text by a new speaker
	* the name of the speaker 

The final output will be a standardized format which the next stage of the software can easily consume.


The current state of the code (as of 2016-03-11) just represents handling a single example: a PDF file from the Philadelphia City Council.
As we get more examples, we will need to see how this code can be generalized to find common sub-tasks.

Possible options for pre-processing transcripts include:

====== Option 1 =========

The developers of the Govmeeting project can continue to generalize the conversion library as we gain more
knowledge of each new transcript that we try to process. However it is unknown whether it would be possible 
to eventually have the code generalized enough that most new formats can be processed without 
changing the code.

====== Option 2 =========

* Write a public specification for the standardized format we expect.
* Write a plugin capability for adding conversion routines to the system.
* Allow a programmer in the community to write a conversion routine in whatever language he/she would like to use (Ruby, PHP, etc).
* Support the use of these languages on the server

======= Option 3 =========

Write a general conversion program that is based on "conversion definitions" which are input by a user in the community.
The conversion definitions might be regular expressions that define changes to the text (deletion, changes, additions, re-format, etc)
	

 