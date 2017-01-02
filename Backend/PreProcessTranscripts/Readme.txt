This solution folder is for projects to pre-process transcript files obtained from original sources. 

If a government body does offer transcipts of it's meetings, they could be in many different formats.

* They may come as PDFs, plain text files or even as  scrapes of HTML screens.
* There will be various ways to indicate the start of spoken text and the name of the speaker.
* The file may or may not contain:
	* line numbers
	* page headers or footers
	* indications of the time elapsed from start of meeting
	* a list of the officials present

The code in these projects need to:
	* convert the file to a standard text file
	* remove unneeded text like page footers, headers and line numbers. 
Then it needs to parse the text to find:
	* meeting designations
	* date and time of start of meeting
	* list of officials present (if this is available)
	* start of meeting periods, for example "introductions", "committee reports", etc
	* the start of spoken text
	* the name of the speaker 

The final output will be a standardized format which the next stage of the software can easily consume.


The current state of the code (as of 2016-03-11) just represents handling a single example: a PDF file from the Philadelphia City Council.
As we get more examples, we will need to see how this code can be generalized to find common sub-tasks.