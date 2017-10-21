# govmeeting
## Purpose

Meetings are the heart and soul of democracy. They are where people of different opinions present their points of view and listen to the opposing views. 

In the Athenian Assembly of 500 BC, a quorum of 6,000 of the 43,000 citizens was needed at a government meeting in order to conduct business. In 10th century Iceland, the yearly Althing was held in a natural outdoor amphitheater for two weeks. Every citizen could attend.

Today, in a town of 30,000, it is rare to see more than a dozen people attending thier town council meetings. Is this still democracy?

Even finding out what was said at government meetings is difficult to impossible. The vast majority do not even produce a transcript.

Most only produce “minutes”, which is a list of the topics discussed and actions taken. If there is a transcript, it is usually difficult to access and read. You need to download it. There is never a table of contents. Finding anything in it is very difficult.

This software will obtain or produces transcripts of government meetings. It will process the transcripts, extract the information and makes it available in a very user friendly way. It will do it as soon as possible after the meetings are held.

## Technical overview

The Front-end is written in Typescript using Angular 2.

The Back-end is written in C# using ASP.NET Core and Entity Framework Core.
.NET Core is the open-source version of .NET which runs on Windows, Mac and Linux.


For more technical details, see: [System Design](https://github.com/govmeeting/govmeeting/wiki/system-design)


## Feature Overview

Shortly after a government meeting takes place, you will be able to:
* Go online and see what issues were discussed and exactly what was said and by whom.
* Receive a summary of issues discussed via text or email.
* Receive notices whenever specific issues are discussed.

At any time, you can go online to:
* See all issues discussed in past meetings.
* See all that was said in the past on any specific issue.
* See exactly what any specific official said in the past on any specific issue.

The goal is to first get the software working for towns and small cities. The lessons learned can then be used to implement it for larger city, state or national government entities. People throughout the world deal with the same problems. The software will be designed to be used anywhere, wherever there is democracy and public access to government meetings.

For more functional details, see: [Functional Design](https://github.com/govmeeting/govmeeting/wiki/functional-design)

For a demo of some working code, see:  [govmeeting.org](http://govmeeting.org)



## Contacts
[![Join the chat at https://gitter.im/govmeeting/govmeeting](https://badges.gitter.im/govmeeting/govmeeting.svg)](https://gitter.im/govmeeting/govmeeting?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

<info@govmeeting.org>


-------------------------------------------------------------------------------------------------------

<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-75868363-1', 'auto');
  ga('send', 'pageview');

</script>
