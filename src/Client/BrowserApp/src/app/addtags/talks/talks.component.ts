import { Component, OnInit } from '@angular/core';
import { TalksService } from './talks.service';
import { TopicsService } from '../topics/topics.service';
import { Addtags } from '../addtags';
import { Talk } from './talk';

@Component({
  selector: 'gm-talks',
  templateUrl: './talks.component.html',
  styleUrls: ['./talks.component.css'],
  providers: [
    TalksService,
    TopicsService
]

})
export class TalksComponent implements OnInit {

  errorMessage: string;
  talks: Talk[];
  addtags: Addtags = {data: null};
  topics: string[];
  highlightedTopic: string;
  shownTopicSelection: number = -1; // index of where we are displaying topic choice.

  constructor(private _talkService: TalksService, private _topicsService: TopicsService) {
  }

///////////////////////////////////////////////////////////////
//  Get the data that we need.
///////////////////////////////////////////////////////////////

  ngOnInit() {
      this.getTalks();

      // The following would get the list in memory.
      // this.talks = this._talkService.getTalksFromMemory();

      //this.getTopics();
  }

  getTalks() {
      this._talkService.getTalks()
      .subscribe(
      //talks => this.addtags.data = this.talks = talks,
      addtags => (this.addtags = addtags, this.talks = addtags.data),
      error => this.errorMessage = <any>error);
  }

  saveChanges() {
      console.log('saveTranscript');
      this._talkService.postChanges(this.addtags)
          .subscribe(
          t => t
          );
      //error => this.errorMessage = <any>error);
  }

/*
  getTopics() {
      this._topicsService.getTopicsFromFile()
      .subscribe(
      topics => this.topics = topics,
      error => this.errorMessage = <any>error);
  }
*/

///////////////////////////////////////////////////////////////
//  Handle user entry of new topic
///////////////////////////////////////////////////////////////

 // Capture the "topicSelect" event and set the new topic.
  onTopicSelect(newTopic: string, talk: Talk) {
      console.log('talks.component--OnTopicSelect ' + newTopic);
      if (newTopic === '') {
          talk.topic = null;
      } else {
          talk.topic = newTopic;
          talk.showSetTopic = false;
      }
  }

 // Capture the "textSelected" event and set the input box to the new data.
  handleTextSelected(highlighted: string) {
      console.log('talks.component--handleTextSelected: ' + highlighted);
      this.highlightedTopic = highlighted;
  }

///////////////////////////////////////////////////////////////
//  Handle moving the section up or down
///////////////////////////////////////////////////////////////

  moveSectionUp(talk: Talk, i: number) {
      this.clearShownTopicSelection();
      if (i>0) {
          this.talks[i-1].section = talk.section;
          talk.section = null;
      }
  }

  moveSectionDown(talk: Talk, i: number) {
     this.clearShownTopicSelection();
     if (i<this.talks.length-1) {
          this.talks[i+1].section = talk.section;
          talk.section = null;
      }
  }

///////////////////////////////////////////////////////////////
//  Handle moving the topic up or down
///////////////////////////////////////////////////////////////

  moveTopicUp(talk: Talk, i: number) {
      this.clearShownTopicSelection();
      if (i>0) {
          this.talks[i-1].topic = talk.topic;
          talk.topic = null;
      }
  }

  moveTopicDown(talk: Talk, i: number) {
      this.clearShownTopicSelection();
      if (i<this.talks.length-1) {
          this.talks[i+1].topic = talk.topic;
          talk.topic = null;
      }
  }

  showTopicSelection(talk: Talk, i: number) {
      this.clearShownTopicSelection();
      talk.showSetTopic = true;
      // save index of where we are displaying topic choice.
      this.shownTopicSelection = i;
  }

  clearShownTopicSelection() {
      if (this.shownTopicSelection !== -1) {

      this.talks[this.shownTopicSelection].showSetTopic = false;
      this.shownTopicSelection = -1;
      }
  }
}
