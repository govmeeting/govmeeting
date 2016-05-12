This is a application which a local volunteer would use to add some needed information to the text transcript. For each discussion occurs at the meeting, we need a clear short description of what is is about. For example: "hiring new fireman", "repaving Main St.".

It is difficult for a computer to do this automatically, in a way that makes the most sense. This program tries to make it as easy as possible for a volunteer to do this. He or she can select from an existing list of topics. Or they can use the mouse to highlight some words in the spoken text and this will be set as the topic.

The app is written in Angular 2. Angular is a HUGE improvement over the last 1.x release. It is a complete rewrite and greatly simplifies writing Angular apps. As of May 2, 2016 this is now out of beta and is a release candidate.

It was also written using "Visual Studio Code". This is a free, very lightweight development tool that is available for Windows, OSX and Linux. It is more like an intelligent text editor similar to Sublime and very easy to learn.




==== How the app gets run ====

* index.html is read by the browser.
* The angular2.dev.js script file and other js libraries are loaded.
* The shims are loaded for ES6 and Typescript features.
* The boot module is imported via "System.import" (new ES6 feature)
* The boot module defines AppComponent as the root component.
* AppComponent defines the "my-app" selector
* Angular sees "my-app" selector in index.html and creates AppComponent.
* AppComponent's template contains a <talks> element which
  causes a TalksComponent to be created.
* TalksComponent's template contains a list of Talk objects. Each talk object
  contains a speaker name, spoken text and optional "start of" section or topic name.
  These get displayed. 
* THe page is now completely built and is waiting for user input.
* If the user clicks the up or down arrow next to a section name, MoveSectionUp
  or MoveSectionDown is called.
* If the user clicks the up or down arrow next to a topic name, MoveTopicUp
  or MoveTopicDown is called.
* If the user clicks on the speaker name or spoken text, the TopicsComponent
  displays the topic input line.
* If the user selects a topic name, a "topicChanged" event is raised which is captured by the TalksComponent. 
* If the user highlights some some of the spoken text, the topic input box is populated
  with this text. The user can edit this text. When the user the clicks "Set", a "topicChanged" event is fired.
 