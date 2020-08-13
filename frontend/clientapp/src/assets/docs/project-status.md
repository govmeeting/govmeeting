- A number of pieces of the software are implemented (but need improvement).
- A number of critical pieces need to be implemented.

# Implemented

- Overall system design
- Component libraries
- Data Model / Relational database design.
- Build and Publish scripts

## frontend

- User interface design
- Framework for Navigation and dashboard
- Component to proofread a transcript
- Component to add tags to a transcript
- Component to browse a processed transcript
- Placeholders for various other components
- View Models
- Message services

## Backend

- Asp.Net Web API
- .Net Workflow processing framework
- Transcribe a meeting recording using Google Speech Services.
- Google Cloud access routines.
- Auto-process an existing city transcript and extract the information.
- Database and File access routines
- Repositories to abstract away file and database access
- Component for handling multiple backups during transcript editing
- Message logging

## Authentication

- User registration and login
- 2-factor authentication and 3rd-party logins
- Authorization of Web API calls

# To Be Implemented

- <b> Critical Components </b> - essential for the software to be usable.
- <b> Needed Improvements </b> - important for easy usability.
- <b> Priority </b> - would add much value.
- <b> Extras </b> - could be added later.

## Critical Components

- Component to retrieve online transcripts and recordings.
  <a href="https://github.com/govmeeting/govmeeting/issues/83">Issue #83</a>
- Implement "Register Government Entity" feature.
  <a href="https://github.com/govmeeting/govmeeting/issues/62">Issue #62</a>
- Work in Progress feature.
  <a href="https://github.com/govmeeting/govmeeting/issues/58">Issue #58</a>
- Implement User Alerts feature.
  <a href="https://github.com/govmeeting/govmeeting/issues/20">Issue #20</a>
- Support multi-languages.
  <a href="https://github.com/govmeeting/govmeeting/issues/16">Issue #16</a>
- Component to identify political sub-divisions from user's location.
  <a href="https://github.com/govmeeting/govmeeting/issues/13">Issue #13</a>
- Capture additional user info during user registration.
  <a href="https://github.com/govmeeting/govmeeting/issues/47">Issue #47</a>
- Implement a "Manager" component.
  <a href="https://github.com/govmeeting/govmeeting/issues/84">Issue #84</a>
- Design and implement a "reputation" system.
  <a href="https://github.com/govmeeting/govmeeting/issues/77">Issue #77</a>

## Needed Improvements

- Improve accuracy of voice recognition.
  <a href="https://github.com/govmeeting/govmeeting/issues/66">Issue #66</a>
- Improve Proofreading user interface.
  <a href="https://github.com/govmeeting/govmeeting/issues/">Issue #</a>
- Improve Add Tags user interface.
  <a href="https://github.com/govmeeting/govmeeting/issues/">Issue #</a>
- Improve View Meeting user interface.
  <a href="https://github.com/govmeeting/govmeeting/issues/">Issue #</a>
- Download and process panoramic images for location headers.
  <a href="https://github.com/govmeeting/govmeeting/issues/76">Issue #76</a>

## Priority

- Mobile app to record a meeting.
  <a href="https://github.com/govmeeting/govmeeting/issues/18">Issue #18</a>
- Mobile app to use voice commands to proofread a meeting.
  <a href="https://github.com/govmeeting/govmeeting/issues/55">Issue #55</a>
- Addtags - make it a two step process?
  <a href="https://github.com/govmeeting/govmeeting/issues/67">Issue #67</a>
- Addtags - filter view by section.
  <a href="https://github.com/govmeeting/govmeeting/issues/65">Issue #65</a>
- Locate existing online transcripts or recordings.
  <a href="https://github.com/govmeeting/govmeeting/issues/13">Issue #13</a>

## Extras

- Component to get political information about a government entity.
  <a href="https://github.com/govmeeting/govmeeting/issues/74">Issue #74</a>
- Re-write front-end Authentication code in Angular.
  <a href="https://github.com/govmeeting/govmeeting/issues/73">Issue #73</a>
- Feature to enlist help with proofreading.
  <a href="https://github.com/govmeeting/govmeeting/issues/69">Issue #69</a>
- Create server WebApi for serving video files.
  <a href="https://github.com/govmeeting/govmeeting/issues/61">Issue #61</a>
- Implement a means to network multiple instances of Govmeeting systems
  <a href="https://github.com/govmeeting/govmeeting/issues/">Issue #</a>

# Production Systems

## Running a Govmeeting site

Anyone can download the Govmeeting software and run it on their own servers or shared hosts.
This could be:

- A government body itself
- A citizen activist group
- An individual citizen

The scale and requirements of the installation will depend on size of the community it handles. This determines the potentail load on the system.

Requirements also depend on how much data will be saved. One option is to only save the processed transripts and the extracted data. Assume a transcript size of 20,000 words and average 6 character word size. An entire year of monthly town council meetings can fit into 1.5 meg of storage. This is a trivial amount of data

However, saving and hosting the video/audio of the meetings is another matter.
This would be needed to allow playback of selected sections of the meeting.
The stored transcript data contains the start/end time of every speakers' comments.
So that is a do-able feature and perhaps it is very useful.

## Govmeeting.org

It would be helpful if a public site was available for those who
don't want install and maintain their own system. This also means that the collected data will not be under
their total control. So there is a trade-off to be made.

"govmeeting.org" is the current demo site for the software. It is now run on a low-cost shared host.
We can look into creating a non-profit that will own and operate this site. If many municipalities elect to use this site, it will need to be run on a cloud service like AWS or Azure, in order to dynamically increase capacity.
