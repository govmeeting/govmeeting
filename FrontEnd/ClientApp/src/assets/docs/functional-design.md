# Overview

There are a few local government bodies, which provide transcripts of meetings. But they are rare -- usually only in larger cities. Also the transcripts can be difficult to find or use. They may require first downloading a file. They almost never have a table of contents. They never have clickable links for navigation.

Many smaller towns and cities record and/or broadcast their meetings. But not many people have time to watch these. Some few upload recordings to a site like Youtube. But watching an entire meeting to find something important to you is time consuming. The information is much more accessible, in the form of a easily searchable transcript.

Many communities provide neither transcripts nor recordings. They may provide meting minutes. But minutes only contain a list of the topics discussed and decisions made. They do not contain the full debate that preceded the decisions. They do not contain the opposing views that were  expressed.

The goal of this project to provide easily accessible transcripts for each of the above three cases.
* If there are existing transcripts, it will process these and make them more easily assessible.
* If there are recordings, it will create transcripts using a combination of auto voice recognition and volunteer effort.
* If there are neither, it will provide tools that volunteers can use to record meetings themselves.

Below is a compont flow of the system, followed by details on each component.

# Flowchart

Some of the blocks below are in green. These means that they include a manual step. Govmeeting involves a combination of automated processing and volunteer effort.

Continuing improvement in the software can make the manual steps as minimal as possible.

But democracy also needs to be something people participate in. The manual steps can help to bring people together in their community to achieve a common goal.


[[https://github.com/govmeeting/govmeeting/blob/master/images/FlowchartFunctional.png|alt=flowchart]]

## Register users and government entities

When a user registers, they can also register their local government entity. They can provide information about its meetings -- whether there are public transcripts, public broadcasts or recordings. They can provide web URLs where such transcripts or recordings can be found.

This information will be used by Govmeeting software to include this government entity in its processing.

If only recordings are available, we will need to also obtain a list of the names of officers who can be at a meeting. Transcripts normally contain this infomation.

## Auto retrieve transcripts and/or recordings

Govmeeting will automatically watch for the appearance of newly added transcripts and/or recordings and retrieve them for processing.

As new government entities are added, this software will need to be tweaked. Pages on which the data is found can greatly vary and will need some custumization. Once enough individual cases are properly handled, the software can be improved to start to handle new variants automatically.

## Manual upload transcripts and/or recordings

Some government entities require a citizen to indiviually request a transcript or recording. In this case, Govmeeting will provide a way for users to upload this data.

Many government entities do not provide either transcripts nor recordings. There will be a smartphone app which users can install to facilitate personally recording a meeting. This app will automatically upload it to govmeeting.org (or whatever site the Govmeeting software is running on)

## Voice recognition creates transcript

Software will automatically generate a first-draft transcript from the recording. we will be using the Google Speech API. We can help the speech API by providing a custom dictionary of "hints" for terms we expect to find in common meeting dialogue.

Many people don't realize much closed-captioning text is not produced by a machine, but by a human. Specially trained people operate a system where they press keys that correspond to phonetic sounds. They are able to do this at real-time, at the same speed as the spoken text.

We are using a completely different approach. We generate a first pass transcription which is then corrected by a person.


## Proofread voice recognition

We will create an application that enables a volunteer to correct the first-draft transcription. This will display the video and the transcription side-by-side and allow the user to edit the mistakes.

The proofreader will neeed to indicate breaks shere the speaker changes.  The editor can then choose from a list, which speaker is talking. The first time they speak, they invariably identify themselves.

Speech-to-text technology is rapidly improving. This manual task will continually become less and less as the technology improves. Eventually it will be smart enough to detect when a speaker changes and perhaps who that speaker is.

## Auto pre-process transcripts

The format of a transcript that are retrieved can vary. It could be text extracted from an HTML page or a PDF files. The means by which the attendees are listed can vary as can the w

Software can automatically extract some information from the transcript. Printed transripts will have the speaker names. They may also have section names and  timestamps.

## Add extra information

There are certain pieces of necessary information that may need to be added:
* The name of the person speaking
* Indicator of the start of each section of the meeting. For example: Role call, reading prior minutes, etc.
* Tags to indicate the topic being discussed.

If we are using a transcript that was provided by the government, much of this information may already be present. But if we are using a transcribed recording, it will not be there.

We will write software that attempts to add some of this information automatically, for example, the meeting section indicators.
We will provide an application that enables volunteers to add missing information and/or correct that which was added automatically.

## Process transcript

Software will automatically process the completed transcripts and populate a database with the extracted information.

## Access to the information

There will be a public system where anyone can access this information. For example:
* Search all past meetings for issues discussed.
* See all that was said in the past on any specific issue.
* See what any specific official said on any specific issue in all past meetings. This is especially helpful at election time.
* Learn how other communities are dealing with similar issues.

## User Alerts

People sign up for alerts, via email or text messages. For example an alert can be sent when:
* A specific topic is discussed at a future meeting.
* A specific official says something on a specific issue.
* Anything is discussed on a specific subject (public safety, zoning, etc)


# Govmeeting.org

The site "govmeeting.org" will provide a instance of the software that any municipality can use freely to host and process their transcripts. Local volunteers can register their own municipality to have their transcripts processed and hosted here.

But also any person or municipality can  elect to run this open-source software on their own hosts.

Currently "govmeeting.org" is run on a low-cost shared host. Hopefully, as many municipalities elect to use this site, it will need to be run on a cloud service like AWS or Azure, in order to dynamically increase capacity.

