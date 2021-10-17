import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { EditTranscriptService } from '../edittranscript.service';
import { EditTranscript, Talk, Word, PlayPhraseData } from '../../../models/edittranscript-view';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-talks',
  templateUrl: './talks.html',
  styleUrls: ['./talks.css'],
})
export class TalksComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';

  @Output() playVideo: EventEmitter<PlayPhraseData>;

  errorMessage: string;
  talks: Talk[] | null;
  gotTalks = false;
  edittranscript: EditTranscript = { sections: [''], topics: [''], talks: null };
  topics: string[];
  highlightedTopic: string;
  shownTopicSelection = -1; // index of where we are displaying topic choice.

  wordColor = 'lightgreen';

  getWordColor(speaker: number): string {
    switch (speaker) {
      case 1: {
        return 'lightblue';
      }
      case 2: {
        return 'lightgreen';
      }
      case 3: {
        return 'yellow';
      }
      case 4:
        {
          return 'pink';
        }
        return 'brown';
    }
  }

  constructor(private _edittranscriptService: EditTranscriptService) {
    this.playVideo = new EventEmitter<PlayPhraseData>();
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
      this._edittranscriptService.getTalks().subscribe(
        (edittranscript) => ((this.edittranscript = edittranscript), (this.talks = edittranscript.talks)),
        (error) => (this.errorMessage = error as any)
      );
    }
  }

  // TODO activate Save button only if changes were made.
  saveChanges() {
    NoLog || console.log(this.ClassName + 'saveTranscript');
    this._edittranscriptService.postChanges(this.edittranscript);
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

  ///////////////////////////////////////////////////////////////
  //  Handle video play
  ///////////////////////////////////////////////////////////////

  // #####################  Play selected part of video ####################################

  onplayVideo(talk: Talk, i: number) {
    // we pass "i", the index into the talks array. But we don't use it as of now.
    // get the start time for this talk
    const starttime = talk.words[0].starttime;
    // get end time
    const endtime = talk.words[talk.words.length - 1].endtime;
    const data: PlayPhraseData = { start: starttime, duration: endtime - starttime };

    // this.playVideo.emit(starttime, endtime - starttime); // we should also send duration
    this.playVideo.emit(data);
  }

  convertToSeconds(time: string) {
    const array = time.split(':');
    let count = array.length;
    let seconds = 0;
    while (count > 0) {
      seconds = seconds + Number(array[count - 1]) * Math.pow(60, array.length - count);
      NoLog || console.log(this.ClassName + 'In convertToSeconds, seconds=' + seconds);
      count--;
    }
    return seconds;
  }
}
