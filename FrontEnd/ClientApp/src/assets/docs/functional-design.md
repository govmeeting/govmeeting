# Overview

There are a few local government bodies, which provide transcripts of meetings. But they are rare -- usually only in larger cities. Also the transcripts can be difficult to find or use. They may require first downloading a file. They almost never have a table of contents. They never have clickable links for navigation.

Many smaller towns and cities record and/or broadcast their meetings. But not many people have time to watch these. Some few upload recordings to a site like Youtube. But watching an entire meeting to find something important to you is time consuming. The information is much more accessible, in the form of a easily searchable transcript.

Many communities provide neither transcripts nor recordings. They may provide meting minutes. But minutes only contain a list of the topics discussed and decisions made. They do not contain the full debate that preceded the decisions. They do not contain the opposing views that were  expressed.

Below is a compont flow of the system, followed by details on each component.

# Flowchart

Some of the blocks below are in green. These means that they include a manual step. Govmeeting involves a combination of automated processing and volunteer effort.

Continuing improvement in the software can make the manual steps as minimal as possible.

But democracy also needs to be something people participate in. The manual steps can help to bring people together in their community to achieve a common goal.


[[https://github.com/govmeeting/govmeeting/blob/master/images/FlowchartFunctional.png|alt=flowchart]]

transcripts and/or recordings and retrieve them for processing.

As new government entities are added, this software will need to be tweaked. Pages on which the data is found can greatly vary and will need some custumization. Once enough individual cases are properly handled, the software can be improved to start to handle new variants automatically.

We can help the speech API by providing a custom dictionary of "hints" for terms we expect to find in common meeting dialogue.

Many people don't realize much closed-captioning text is not produced by a machine, but by a human. Specially trained people operate a system where they press keys that correspond to phonetic sounds. They are able to do this at real-time, at the same speed as the spoken text.




# Govmeeting.org

The site "govmeeting.org" will provide a instance of the software that any municipality can use freely to host and process their transcripts. Local volunteers can register their own municipality to have their transcripts processed and hosted here.

But also any person or municipality can  elect to run this open-source software on their own hosts.

Currently "govmeeting.org" is run on a low-cost shared host. Hopefully, as many municipalities elect to use this site, it will need to be run on a cloud service like AWS or Azure, in order to dynamically increase capacity.

