Below is a functional description of the main pieces of the software.

## Individual Registration

- During registration, users specify their home location (town, city, village, postal code, etc).
- Based on their location, the system determines the governing entities to which they belong. (country, state, county, town/city etc)

## Government Body Registration

- A user can register any of the governing entities to which they belong.
- Information entered will include:
  - Website URL
  - Names of governing officials
  - URL's where transcripts or meeting recordings can be found
- Other users for this location will see data already entered. They can vote on the accuracy of any data items and enter alternate values.
- Votes will accumulate for each data value. The values with the most votes become the official values.
  <a href="https://github.com/govmeeting/govmeeting/issues/62">Github issue #62</a>

## Import Recordings or Transcripts

- The system will download existing online recordings or transcripts on a regular schedule from the locations specified in the Government Body Registration.
- Users also have the option to upload recordings or transcripts.
- Many places neither provide transcripts nor recordings of their meetings.
  Govmeeting will provide a smartphome app that users can use to
  personally record and upload a meeting recording.
  <a href="https://github.com/govmeeting/govmeeting/issues/18">Github issue #18</a>

## Pre-process Existing Transcripts

- Convert transcripts to plain text. Often existing transcripts are in other formats like PDF. These are converted to plain text so that it is more easily processed.
- Extract information such as speaker and section names.

## Transcribe Recordings Using Speech Recognition

- Convert recordings to the primary web video formats (mp4, ogg and webm.) This make them more accessable on all types of devices.
- Extract and merge audio tracks if more than one.
- Upload the audio file to Google Cloud storage to prepare for transcription.
- Call the asynchronous Google Speech API to do auto voice recognition.
- Perform speaker change recognition. There is a Google API for this.
- Add speaker identification. This will use speech processing software on the server.
- Put the information into a JSON format for further processing.
- Split the video, audio and trancript files into 3 minute work segments, so that multiple volunteers can work simultaneously on proofreading.

## Proofread Transcribed Text [Manual step]

- Proofread text for errors. Provide a user friendly interface for quickly correcting errors.
- Correct information such as speaker and section names.

Govmeeting attempts to make the processing as automatic as possible.
But computers are not yet as smart as we would like. Humans are still needed to correct their mistakes.
But every day, computers get smarter and this work should keep getting less and less.

## Add issue tags [Manual step]

- One of the most important jobs is correctly adding tags or metadata
  to the transcript. This is what enables:
  - information to be easily located.
  - a transcript to be indexed and browsed quickly
  - alerts to be set by user on specific issues
- The names of issues need to assigned by people and not computers. This is the best way to ensure that they are meaningful.
- It is important that a very easy to use and quick user interface be provided.

In the future, perhaps this step can also be primarily done by a computer. But it is not all a bad thing to need
some manual work from community volunteers. It helps unite people for a common cause.
If this is a small city 35,000, it shouldn't be that difficult to enlist a dozen or so to give a short amount of time each month.

## Populate Relational Database

The data is put in a relational database so that it can be quickly
accessed using multiple criteria.

## Data is now available for use

- A browe-able & search-able transcript is now available
- A summary of the issues discussed at the meeting is sent to those requesting it.
- Alerts are sent on specific issues to those requesting it.

## Virtual meeting is arranged.

- An agenda is created based on issues at the real meeting.
- Invitatations are sent to community members.
- Included in the invitation are requests for possible additional agenda items.
- When responses are received, a ballot is sent to those who wil attend. On this ballot, members can vote on whch suggested new agenda items to include.
- Within a few days, a virtual meeting is held.

## Workflow Management

Some of the above workflow steps are done automatically by computer and some are done manually by volunteers. There are places in the workflow where a real person should verify that it is OK to proceed:

- Verify that URLs for retrieving transcripts and recordings appear valid.
- Verify that the content of the retrieved files appears valid.
- Verify that the output from the preprocessing appears valid.
- Verify that the speech to text conversion appears valid.
- Verify that the proofreading of the transcript appears completed.
- Verify that the adding of tags to the transcript appear completed.
- Verify the the final transcript data appears complete and valid.

There needs to be a way to elevate the rights of one or more of a location's registered users to a "manager" position.

- Managers would be notified whenever a decision is pending in the workflow.
- A manager could then log in and give or deny approval for the workflow to continue.
