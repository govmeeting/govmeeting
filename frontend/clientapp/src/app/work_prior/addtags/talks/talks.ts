import { Component, OnInit } from '@angular/core';
import { AddtagsService } from '../addtags.service';
import { Addtags, Talk } from '../../../models/addtags-view';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-talks',
  templateUrl: './talks.html',
  styleUrls: ['./talks.css'],
})
export class TalksComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  errorMessage: string;
  talks: Talk[] | null;
  gotTalks = false;
  addtags: Addtags = { sections: [''], topics: [''], talks: null };
  topics: string[];
  highlightedTopic: string;
  shownTopicSelection = -1; // index of where we are displaying topic choice.

  constructor(private _addtagsService: AddtagsService) {
    // this.talks = addtagsService.getTalks();
  }

  ///////////////////////////////////////////////////////////////
  //  Get the data that we need.
  ///////////////////////////////////////////////////////////////

  ngOnInit() {
    NoLog || console.log(this.ClassName + 'ngOnInit');
    this.getTalks();

    // The following would get the list in memory.
    // this.talks = this._talkService.getTalksFromMemory();

    // this.getTopics();
  }

  getTalks() {
    if (!this.gotTalks) {
      this.gotTalks = true;
      NoLog || console.log(this.ClassName + 'getTalks');
      this._addtagsService.getTalks().subscribe(
        (addtags) => ((this.addtags = addtags), (this.talks = addtags.talks)),
        (error) => (this.errorMessage = error as any)
      );
    }
  }

  // TODO activate Save button only if changes were made.
  saveChanges() {
    NoLog || console.log(this.ClassName + 'saveTranscript');
    this._addtagsService.postChanges(this.addtags);
    // .subscribe(
    // t => t
    // );
    // error => this.errorMessage = <any>error);
    NoLog || console.log(this.ClassName + 'exit saveTranscript');
  }

  ///////////////////////////////////////////////////////////////
  //  Handle user entry of new topic
  ///////////////////////////////////////////////////////////////

  // Capture the "topicSelect" event and set the new topic.
  onTopicSelect(newTopic: string, talk: Talk) {
    NoLog || console.log(this.ClassName + 'OnTopicSelect ', newTopic);
    if (newTopic === '') {
      talk.topic = null;
    } else {
      talk.topic = newTopic;
      talk.showSetTopic = false;
    }
  }

  // Capture the "textSelected" event and set the input box to the new data.
  handleTextSelected(highlighted: string) {
    NoLog || console.log(this.ClassName + 'handleTextSelected: ', highlighted);
    this.highlightedTopic = highlighted;
  }

  ///////////////////////////////////////////////////////////////
  //  Handle moving the section up or down
  ///////////////////////////////////////////////////////////////

  moveSectionUp(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i > 0) {
      this.talks[i - 1].section = talk.section;
      talk.section = null;
    }
  }

  moveSectionDown(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i < this.talks.length - 1) {
      this.talks[i + 1].section = talk.section;
      talk.section = null;
    }
  }

  ///////////////////////////////////////////////////////////////
  //  Handle moving the topic up or down
  ///////////////////////////////////////////////////////////////

  moveTopicUp(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i > 0) {
      this.talks[i - 1].topic = talk.topic;
      talk.topic = null;
    }
  }

  moveTopicDown(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i < this.talks.length - 1) {
      this.talks[i + 1].topic = talk.topic;
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
      if (this.talks) {
        this.talks[this.shownTopicSelection].showSetTopic = false;
        this.shownTopicSelection = -1;
      }
    }
  }
}
