<!-- Note the controller for this page is app/about-project/overview/overview.ts -->

<mat-card>
  <mat-card-title class="cardtitle">Overview</mat-card-title>

<markdown ngPreserveWhitespaces>

Public Meetings are the heart and soul of democracy. They are where citizens present opposing views and come to consensus on decisions that affect us all. 

In the Athenian Assembly of 500 BC, a quorum of 6,000 of the 43,000 citizens was needed to conduct business. In the 10th century, the Icelandic Althing was held in a natural outdoor amphitheater and all citizens could attend.

Today it is rare to see more than a dozen attendees at a council meeting in a town of 30,000 people. Is this still democracy? 

Meetings are sometimes broadcast on TV and some newspapers report on some issues. But still, most people know very litte about most of what goes on. 

The purpose of Govmeeting is give all citizens quick and easy access to what their politicians are doing and opportunities to affect their decisions.

## Features

Govmeeting will automatically:

* Retrieve online transcripts or recordings of government meetings.
* Transcribe the recordings using speech-to-text
* Process the transcripts into a standard format. 
* Load a relational database with the information in the transcripts

People will then be able to:

### Elect to receive after each meeting:

* A full transcript of the meeting.
* A summary of issues discussed.
* Alerts on specific issues.
* Alerts when a specific official speaks.
* Alerts on new proposed legislation.

### Go online and:

* Browse current and past meetings.
* Search meetings for issues discussed.
* Search for what a specific official said on issues.
* Search for voting results on legislation
* See statistics, graphs and charts on issues, legislature, etc.

<!-- END OF README SECTION -->

<a name="continued"></a>

## Problems with current access

Getting access to this kind of information is difficult today. Only a few large cities make transcripts of their meetings available. 
And these are often difficult to obtain and use.


Philadelphia is the 6th largest city in the U.S. Here is a sample page from a Council transcript.
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


New York City is the largest city in the U.S. It also produces transcripts of city council meetings. But trying to get them is not easy. You need to file a request and pay $1 per page or $20 for an electronic copy of each meeting.

## The Focus 

The tools for democarcy haven't changed much in 2,000 years. But with today's technolgy, we may finally be able to create the tools we need.

Most other "Open Government" projects rely on government supplied data. Govmeeting takes the opposite approach.
It will use government data if available. But if government can't or won't supply the data, it provides a way for citizens to create the data themselves.

Govmeeting's initial focus is on tools that work the best at the local level. Lessons learned there can help us build tools for the regional, state and country level.

Disillusion with democracy starts at the local level. Fixing this requires a grassroots effort at that level.

Govmeeting is  an  <a href="https://github.com/govmeeting/govmeeting"> open source project on Github. </a>

</markdown>

</mat-card>

