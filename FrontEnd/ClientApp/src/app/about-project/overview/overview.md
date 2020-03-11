<mat-card>
  <mat-card-title class="cardtitle">Overview</mat-card-title>

<markdown ngPreserveWhitespaces>

  If we want to get involved in our local government, the best place to start is attending the public meetings. For it is here that:
* New legislation is introduced.
* Bills are voted on.
* Formal department and committee reports are presented.
* Issues are discussed and debated.
* Public comment is given.


The debate and public comment can be the most instructive of all. Instead of reading all 500 pages of a new bill ourselves, it can be sufficient to hear the comments from those who have. 

Those in favor of the bill will present their most important reasons for favoring it.
And those opposed will present their most important reasons for opposing it.

## Current Access

If we can't spend hours attending or watching meetings, getting access to this information is usually difficult. Only a few large cities make transcripts available. 
And even these are often difficult to obtain and use.

Here is a sample page from a Philadelphia transcript.
It's 154 pages of double-spaced lines, 10-words-per-line. It's in PDF format, making it unusable on small screens, since the size can't be adjusted.

</markdown>

  Click: <button (click)="ToggleTranscript()"> {{showhidetranscript}} Sample Transcript </button>
<img [hidden]="!CheckShowTranscript()" (click)="ToggleTranscript()" src="/assets/images/Philly transcript page.png" width="900" alt="Philadelphia transcript page">

<markdown ngPreserveWhitespaces>

There is no table of contents. And the index is possibly usable by a legal researcher, but not the average person. 

</markdown>

Click:
  <button (click)="ToggleIndex()"> {{showhideindex}} Sample Index </button>
<img [hidden]="!CheckShowIndex()" (click)="ToggleIndex()" src="/assets/images/Philly transcript index.png" width="900" alt="Philadelphia transcript index">

<markdown ngPreserveWhitespaces>


New York City is the largest city in the U.S. It produces transcripts of city council meetings. But trying to get them is not easy.
Their website states that you need to go in person to the city clerk's office and pay $1 per page or $20 for an electronic copy.

## Desired Access

Govmeeting will obtain or generate transcipts of government meetings, extract the information and populate a relational database. We will then be able to do the following:

### Browse information

* Browse a meeting by issue, category, person speaking, related bill, etc.
* Browse all topics discussed in the past year.
* See what legislation was voted on and what the votes were.
* Browse all public commentary on specific issues.
* See which officials attended the meetings and see what they said.

### Search for information

* Search all past meetings for discussion on a specific issues.
* Search for everthing that a specific official said on an issue.
* Search for when specific bills were either discussed or acted upon.
* Search for anything on a specific category of issues
(public safety, zoning, animal control, etc)


### Sign up for email or text alerts

*  Automatically receive a summary or full transcript of each meeting.
*  Learn when any specific issue is discussed.
*  Learn when any category of issues is discussed.
*  Learn when any new legislature is proposed.
*  Be notified whenever any search criteria that you set up returns results.


### Use graphical and statistical tools

* Graphically see the types of issues discussed over time.
* Graphically see the amount of time spent on issues, bills, etc.
* Compare issues for number of alerts on them, etc.
* Compare attendence and involvement of elected officials.


### Comparisons with other communities

* Compare types of issues that are discussed across different communities.
* Compare how similar issues are handled.
* Compare meeting structures and time allotment.
* Compare procedures for public comment. 


</markdown>

</mat-card>

