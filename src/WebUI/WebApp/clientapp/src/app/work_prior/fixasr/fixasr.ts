import { Component, OnInit } from '@angular/core';
import { AfterViewInit, ViewChild } from '@angular/core';
import { FixasrView, AsrSegment } from '../../models/fixasr-view';
import { FixasrService } from './fixasr.service';
import { VideoComponent } from '../../common/video/video';
import { FixasrUtilities } from './utilities';
import { Observable } from 'rxjs/Observable';
import { timer } from 'rxjs/observable/timer';
import { Speaker } from './speaker';
// import { Ng2DropdownModule } from 'ng2-material-dropdown';

// test
import { ElementRef } from '@angular/core';
// import { HostListener } from '@angular/core';

// 2017-02-18
// https://angular.io/docs/ts/latest/guide/user-input.html
// https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement

// This is the "Fix ASR" component for fixing the "Automatic Speech Recognition" errors.
// TODO This component is way too long. Code needs to be factored out.

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-fixasr',
  templateUrl: './fixasr.html',
  // templateUrl: './fixasr.component-Copy.html',
  styleUrls: ['./fixasr.css'],
  providers: [FixasrUtilities],
})
export class FixasrComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  errorMessage: string;
  lastPhrasePlayed = 0;
  currentIndex = -1;
  currentElement: HTMLInputElement;
  isTyping = false;
  isFirstSpace = false;
  isInsertMode = false;
  isSpeakerSelectVisible = true;
  modeButtonText = 'REPLACE';
  _scrollList: HTMLElement;

  showhelp = true;
  showhidehelp = 'Hide';

  // TODO - Fix problem with asrtext.
  // We should just use asrtext, which contains both asrsegments & lastedit.
  // But the browser hangs when we try to access asrtext from HTML.
  asrsegments: AsrSegment[];
  lastedit = -1;
  speakerName = '';

  speakers: Speaker[] = [
    { abbreviation: 'TW', option: 'Tricia Warren' },
    { abbreviation: 'WW', option: 'Wendy Wolf' },
    { abbreviation: 'RH', option: 'Russell Hoffman' },
    { abbreviation: 'MT', option: 'Michael Tomko' },
    { abbreviation: 'KB', option: 'Kellie Bigos' },
    { abbreviation: 'TWo', option: 'Thomas Woodin' },
    { abbreviation: 'MF', option: 'Michele Farnham' },
    { abbreviation: '?', option: 'unknown' },
  ];

  // https://github.com/videogular/videogular2/blob/master/docs/using-the-api.md

  // "static" argument of @ViewChild: Angular recommends retrieving view queries results
  // in the ngAfterViewInit lifecycle hook to ensure that queries matches that are dependent
  // on binding resolutions (like in *ngFor loops or *ngIf conditions) are ready and will
  // thus be found by the query. To get this behavior, the static parameter must be set to false.
  // See: https://dev.to/angular/the-angular-viewchild-decorator-424c

  @ViewChild('myInput', { static: false }) input: ElementRef;

  @ViewChild(VideoComponent, { static: false })
  private videoComponent: VideoComponent;

  constructor(private _fixasrService: FixasrService, private _Utilities: FixasrUtilities) {}

  ngOnInit() {
    this.getAsr();
    // We cast to avoid a compiler error. It should never be null.
    this._scrollList = document.getElementById('scroll-text') as HTMLElement;
    NoLog || console.log(this.ClassName + 'currentIndex = ' + this.currentIndex);
  }

  CheckShowHelp(): boolean {
    return this.showhelp;
  }
  ToggleHelp() {
    this.showhidehelp = this.showhelp ? 'Show' : 'Hide';
    this.showhelp = !this.showhelp;
  }

  /* for testing
    getpos() {
        this.lastedit = this.getScrollPosition();
    }
    setpos() {
        this._scrollList.scrollTop = this.lastedit;
    }
    */

  setScrollPosition(top: number) {
    this._scrollList.scrollTop = top;
  }

  getScrollPosition(): number {
    return this._scrollList.scrollTop;
  }

  toggleInsertMode() {
    this.isInsertMode = !this.isInsertMode;
    this.modeButtonText = this.isInsertMode ? 'INSERT' : 'REPLACE';
  }

  // #########################  Event Handlers ################################################

  // ########  Handle speaker selection

  selectSpeaker(index: any) {
    NoLog || console.log(this.ClassName + 'selected index=' + index);
    this._Utilities.insertAtStartCurrentWord(this.currentElement, '[' + this.speakers[index].abbreviation + '] ');
  }

  addSpeaker(speaker: any) {
    NoLog || console.log(this.ClassName + 'new speaker=', speaker);
    const abbrev = this.createSpeakerAbbrev(speaker);
    this._Utilities.insertAtStartCurrentWord(this.currentElement, '[' + abbrev + '] ');
    const newSpeaker = new Speaker(speaker, abbrev);
    this.speakers.splice(this.speakers.length - 1, 0, newSpeaker);
  }

  createSpeakerAbbrev(name: string): string {
    let firstname: string;
    let lastname: string;
    let abbrev: string;
    let extras: string;
    let x = name.indexOf(' ');
    // For a multi-word name, we start with abbreviaion of first-initial + last-initial.
    if (x !== -1) {
      firstname = name.substr(0, x);
      x = name.lastIndexOf(' ');
      lastname = name.substr(x + 1);
      abbrev = firstname.substr(0, 1).toUpperCase() + lastname.substr(0, 1).toUpperCase();
      // "extras" has extra letters we may need to make the abbreviation unique.
      extras = lastname.substr(1); // Use rest of the letters of last name.
    } else {
      // For a single word name, we start with abbreviaion of first-initial.
      abbrev = name.substr(0, 1).toUpperCase();
      extras = name.substr(1); // Use rest of the letters of single name.
    }
    while (!this.isAbbreviationUnique(abbrev)) {
      abbrev = abbrev + extras.substr(0, 1);
      extras = extras.substr(1);
    }
    return abbrev;
  }

  isAbbreviationUnique(abbrev: string): boolean {
    let answer = true;
    this.speakers.forEach((element) => {
      if (element.abbreviation === abbrev) {
        answer = false;
      }
    });
    return answer;
  }

  // ########

  onFocus(event: any, i: number) {
    NoLog || console.log(this.ClassName + 'onFocus index=' + i + '  size=' + this.asrsegments.length);
    this.currentIndex = i;
    this.currentElement = event.target as HTMLInputElement;
    // this.isSpeakerSelectVisible = true;
    this.isTyping = false;
    this.isFirstSpace = false;
  }

  onMouseup(event: any, i: number) {
    if (this.isInsertMode) {
      return;
    }

    const ele: HTMLInputElement = event.target as HTMLInputElement;
    NoLog ||
      console.log(
        this.ClassName + 'onMouseup index=' + i + '   start=' + ele.selectionStart + '   end=' + ele.selectionEnd
      );
    NoLog || console.log(this.ClassName + 'onMouseup value=', ele.value);
    this._Utilities.selectWord(ele);
  }

  // When we enter punctuation while some text is selected,
  // put the puntuation at the end of the word and do NOT replace the text.
  // Therefore we remove the selection of the word, so that it does not get replaced.
  onKeyDown(event: any, i: number) {
    switch (event.key) {
      case '.':
      case ',':
      case ';':
      case '?':
        const ele: HTMLInputElement = event.target as HTMLInputElement;
        ele.selectionStart = ele.selectionEnd;
        return;
    }
  }

  onKey(event: any, i: number) {
    let ele: HTMLInputElement;
    // After inserting punctuation while in "Replace" mode, go to next word.
    if (!this.isInsertMode) {
      switch (event.key) {
        case '.':
        case ',':
        case ';':
        case '?':
          ele = event.target as HTMLInputElement;
          this._Utilities.gotoNextWord(ele);
          return;
      }
    }

    // If the key is "Insert", toggle Insert mode
    if (event.key === 'Insert') {
      this.toggleInsertMode();
      return;
    }

    // If the key is "Enter", play the recording the text.
    if (event.key === 'Enter') {
      this.playPhrase();
      return;
    }

    if (this.isInsertMode) {
      return;
    }

    const key = event.key; // get key value
    ele = event.target as HTMLInputElement;
    let value: string = ele.value;
    let start: number = ele.selectionStart;
    const end: number = ele.selectionEnd;

    NoLog || console.log(this.ClassName + 'doKey: key=' + key + '   isTyping=' + this.isTyping);
    NoLog || console.log(this.ClassName + '1 doKey index=' + i + '   start=' + start + '   end=' + end);

    // Handle the arrow keys
    switch (key) {
      case 'ArrowRight':
        if (end < value.length) {
          this._Utilities.gotoNextWord(ele);
        } else {
          this._Utilities.gotoNextInputElement(ele, i);
        }
        return;
      case 'ArrowLeft':
        if (start !== 0) {
          this._Utilities.gotoPriorWord(ele);
        } else {
          this._Utilities.gotoLastWordInPriorInputElement(ele, i);
        }
        return;
      case 'ArrowDown':
        if (i >= this.asrsegments.length - 1) {
          this._Utilities.selectLastWord(ele);
        } else {
          this._Utilities.gotoNextInputElement(ele, i);
        }
        return;
      case 'ArrowUp':
        this._Utilities.gotoPriorInputElement(ele, i);
        return;
      //            case '.':
      //                this._Utilities.insertAtEndCurrentWord(this.currentElement, '.');
      //                return;
    }

    // If not space, set isTyping true and firstSpace false and return
    if (key !== ' ') {
      this.isTyping = true;
      this.isFirstSpace = false;
      return;
    }

    // If they typed a space at the end of the text, set firstSpace & return
    if (start === value.length) {
      if (this.isFirstSpace === false) {
        this.isFirstSpace = true;
        return;
      }
    }

    if (this.isTyping === true) {
      // ignore fist space if they were typing
      if (this.isFirstSpace !== true) {
        this.isFirstSpace = true;
        return;
      }
    }

    // They could have gotten here in 2 ways.
    // 1. They typed a second space after typing some text.
    // 2. They typed a space when a word was selected.
    // First remove the space they just typed
    NoLog || console.log(this.ClassName + '2 left=' + value.substr(0, start - 1));
    NoLog || console.log(this.ClassName + '2 right=' + value.substr(start));
    value = value.substr(0, start - 1) + value.substr(start);
    start--;
    NoLog || console.log(this.ClassName + '2 doKey start=' + start + '   value=' + value);

    // If there is a space right after the one they typed, remove that also.
    if (value.charAt(start) === ' ') {
      NoLog || console.log(this.ClassName + '3 left=' + value.substr(0, start - 1));
      NoLog || console.log(this.ClassName + '3 right=' + value.substr(start));
      value = value.substr(0, start - 1) + value.substr(start);
      start--;
      NoLog || console.log(this.ClassName + '3 doKey start=' + start + '   value=' + value);
    }

    // Select the correct word

    // "start" now is just before the next word, or at end of text.
    if (start === value.length) {
      if (value.charAt(start - 1) === ' ') {
        value = value.substr(0, start - 1);
        NoLog || console.log(this.ClassName + '4 doKey start=' + start + '   value=' + value);
      }
    }
    ele.value = value;
    ele.setSelectionRange(start + 2, start + 2);
    NoLog || console.log(this.ClassName + 'start=' + ele.selectionStart + '   end=' + ele.selectionEnd);
    this._Utilities.selectWord(ele);
  }

  // #####################  get & post data via AsrService ##########################

  getAsr() {
    this._fixasrService.getAsr().subscribe(
      (asrtext) => {
        // TODO - We should be able to just move asrtext to this.asrtext.
        // It appears to move the data OK. When I stop at a breakpoint, the
        // the data is all there. But accessing it from the HTML
        // causes an error (It says asrtext is null).
        this.asrsegments = asrtext.asrsegments;
        this.lastedit = asrtext.lastedit;
        NoLog || console.log(this.ClassName + 'getAsr lastedit=' + this.lastedit);

        // We want to scroll the list to the last stored position.
        // But Angular will not yet have updated the list. We need
        // to yield for an instant to let it first do the update.
        // const timer = Observable.timer(100);   // no longer valid
        const timerx = timer(100); // yield for 100 milliseconds
        timerx.subscribe((t) => this.setScrollPosition(this.lastedit));
      },
      (error) => (this.errorMessage = error as any)
    );
  }

  saveChanges() {
    const lastedit = this.getScrollPosition();
    const fixasrtext: FixasrView = { lastedit, asrsegments: this.asrsegments };
    NoLog || console.log(this.ClassName + 'saveTranscript');
    // TODO - See notes under getAsr().
    // asrtext.lastedit = this.getScrollPosition();
    // asrtext.asrsegments = this.asrsegments;
    // this._asrService.postChanges(asrtext)
    // this._fixasrService.postChanges({ 'lastedit': lastedit, 'asrsegments': this.asrsegments });
    this._fixasrService.postChanges(fixasrtext);
    // .subscribe (
    //     t => t
    // );
    // error => this.errorMessage = <any>error);
  }

  // #####################  Play selected part of video ####################################

  playPhrase() {
    // start playing at the currently selected phrase
    let toPlay = this.currentIndex;
    // If not current phrase, start from last edited phrase.
    if (toPlay === -1) {
      toPlay = this.lastedit;
      // Otherwise start from beginning.
      if (toPlay === -1) {
        this.videoComponent.playPhrase(0, 4);
        return;
        // toPlay = 0;
      }
    }
    if (toPlay === this.lastPhrasePlayed) {
      return;
    }
    this.lastPhrasePlayed = toPlay;

    const maxPhraseTime = 6; // minimum time of a single phrase
    const beforeTime = 1; // time to play before
    const afterTime = 3; // and after selected phrase
    const startTime = this.asrsegments[toPlay].startTime;

    NoLog || console.log(this.ClassName + 'playPhrase, index=' + toPlay);

    // Play for contextTime seconds before selected phrase
    let start = this.convertToSeconds(startTime) - beforeTime;
    if (start < 0) {
      start = 0;
    }

    // Assume duration is maxPhraseTime seconds if this is the last phrase.
    // Otherwise play for (contextTime * 2) seconds longer than duration.
    // This means contextTime before and contextTime after.
    let duration = maxPhraseTime;
    if (this.asrsegments.length > toPlay + 1) {
      const endTime: string = this.asrsegments[toPlay + 1].startTime;
      duration = this.convertToSeconds(endTime) - start + beforeTime + afterTime;
    }
    this.videoComponent.playPhrase(start, duration);
    this.currentElement.focus();
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
