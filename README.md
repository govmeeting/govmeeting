# Govmeeting

Meetings are the heart and soul of democracy. They are where people of different opinions listen to others and present their points of view.

In the Athenian Assembly of 500 BC, a quorum of 6,000 of the 43,000 citizens was needed to conduct business. In the 10th century, the Icelandic Althing was held in a natural outdoor amphitheater and all citizens could attend.

Today it is rare to see more than a dozen attendees at a council meeting in a town of 30,000 people. Is this still democracy?

Some public meetings are broadcast on local TV.  But a very small percent of people actually watch. Sometimes very contentious issues are debated and voted on. But there is usually no public record kept of what was said.

A dozen people at the meeting, including some council members, might speak strongly against some terrible decision. But it is easy today for the majority of the council to totally ignore them. They know that less than one percent of the voters will ever hear what they said.

The purpose of this project is to preserve those discussions and make them easily available to all citizens of the community. It will do this through a combination of intelligent software and community volunteer effort.

## Functional overview

Shortly after a government meeting takes place, you will be able to:
* Receive a summary of issues discussed via text message or email.
* Optionally receive a full transcript of the meeting via email.

At any time, you can go online and:
* Sign up to receive a phone alert or email whenever a specific issue is discussed.
* Use a more powerful tool to browse a specific meeting.
* Search all past meetings for issues discussed.
* See all that was said in the past on any specific issue.
* See what any specific official said on any specific issue in all past meetings. This is especially helpful at election time.

For a detailed functional design, see: [Functional Design](https://github.com/govmeeting/govmeeting/wiki/functional-design)

For a demo of some working code, see:  [govmeeting.org](http://govmeeting.org)

## Technical overview

* Front-end written in Typescript and Angular.
* Web server written in C# using ASP.NET Core.
* SQL database using Entity Framework Core as an ORM.
* Back-end processing written in C# with .Net Core.

ASP.NET Core and Entity Framework Core is open-source software which runs on Windows, Mac and Linux.
For a detailed system design, see: [System Design](https://github.com/govmeeting/govmeeting/wiki/system-design)

## Quickstart

### Visual Studio
  * Opening the "govmeeting.sln" will load all the projects
  * Opening src\Server\WebApp\WebApp.sln will load just the Angular - Asp.Net Core app.

### Visual Studio Code

* Install the extension "Debugger for Chrome" by Microsoft
* Install the extension "C# for Visual Studio Code" by Microsoft

## Contacts
[![Join the chat at https://gitter.im/govmeeting/govmeeting](https://badges.gitter.im/govmeeting/govmeeting.svg)](https://gitter.im/govmeeting/govmeeting?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

<info@govmeeting.org>

