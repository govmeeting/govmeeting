import { Component, OnInit } from '@angular/core';
import { AfterViewInit, ViewChild } from '@angular/core';
import { AsrSegment } from './asrsegment';
import { AsrText } from './asrtext';
import { AsrService } from './asr.service';
import { VideoComponent } from '../video/video.component';
import { FixasrUtilities } from './fixasr-utilities';

// test
import { ElementRef } from '@angular/core';
//import { HostListener } from '@angular/core';

//2017-02-18
// https://angular.io/docs/ts/latest/guide/user-input.html
// https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement


// This is the "Fix ASR" component for fixing the "Automatic Speech Recognition" errors.

@Component({
  moduleId: module.id,
  selector: 'gm-fixasr',
  templateUrl: './fixasr.component.html',
  styleUrls: ['./fixasr.component.css'],
    providers: [
        AsrService,
        FixasrUtilities
    ]
})
export class FixasrComponent  implements OnInit {
    errorMessage: string;
    asrtext : AsrText;
    asr: AsrSegment[];
    lastPhrasePlayed : number = 0;
    currentIndex : number = -1;
    isTyping : boolean = false;
    isFirstSpace : boolean = false;
    isInsertMode: boolean = false;
    modeButtonText: string = 'REPLACE';
    _scrollList: HTMLElement;
    lastedit: number;

    // https://github.com/videogular/videogular2/blob/master/docs/using-the-api.md

    @ViewChild('myInput') input: ElementRef;

    @ViewChild(VideoComponent)
    private videoComponent : VideoComponent;

    constructor(
        private _asrService: AsrService,
        private _Utilities: FixasrUtilities) {
    }

    ngOnInit() {
        this.getAsr();
        this._scrollList = document.getElementById('scroll-text');
    }

    getpos() {
        this.lastedit = this.getScrollPosition();
    }

    setpos() {
        this._scrollList.scrollTop = this.lastedit;
    }

    setScrollPosition(top: number) {
        this._scrollList.scrollTop = top;
    }

    getScrollPosition() : number {
        return this._scrollList.scrollTop;
    }

    toggleInsertMode() {
        this.isInsertMode = !this.isInsertMode;
        this.modeButtonText = (this.isInsertMode ? 'INSERT' : 'REPLACE');
    }

// #########################  Event Handlers ################################################

    onFocus(event: any, i : number) {
        console.log('onFocus index=' + i + '  size=' + this.asr.length);
        this.currentIndex = i;
        this.isTyping = false;
        this.isFirstSpace = false;
    }

    onMouseup(event: any, i : number) {
        if (this.isInsertMode) return;

        var ele : HTMLInputElement = (<HTMLInputElement>event.target);
        console.log('onMouseup index=' + i + '   start=' + ele.selectionStart + '   end=' + ele.selectionEnd);
        console.log('onMouseup value=' + ele.value);
        this._Utilities.selectWord(ele);
    }

    onKey(event: any, i : number) {
        if (event.key === 'Insert') {
            this.toggleInsertMode();
            return;
        }
        if (this.isInsertMode) return;

        var key = event.key;   // get key value
        var ele : HTMLInputElement = (<HTMLInputElement>event.target);
        var value : string = ele.value;
        var start : number = ele.selectionStart;
        var end : number = ele.selectionEnd;


        console.log('doKey: key=' + key + '   isTyping=' + this.isTyping);
        console.log('1 doKey index=' + i + '   start=' + start + '   end=' + end);

        switch (key) {

        // If 'Enter' play that portion of video
            case 'Enter':
                this.playPhrase(i);
                return;

        // Handle the arrow keys
            case 'ArrowRight':
                if (end  < value.length) {
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
                if (i >= (this.asr.length - 1)) {
                    this._Utilities.selectLastWord(ele);
                } else {
                    this._Utilities.gotoNextInputElement(ele, i);
                }
                return;
            case 'ArrowUp':
                this._Utilities.gotoPriorInputElement(ele, i);
                return;
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
        console.log('2 left=' + value.substr(0, start - 1));
        console.log('2 right=' + value.substr(start));
        value = value.substr(0, start - 1) + value.substr(start);
        start--;
        console.log('2 doKey start=' + start + '   value=' + value);

        // If there is a space right after the one they typed, remove that also.
        if (value.charAt(start) === ' ') {
            console.log('3 left=' + value.substr(0, start - 1));
            console.log('3 right=' + value.substr(start));
            value = value.substr(0, start - 1) + value.substr(start);
            start--;
            console.log('3 doKey start=' + start + '   value=' + value);
        }

        // Select the correct word

        // "start" now is just before the next word, or at end of text.
        if (start === value.length) {
            if (value.charAt(start - 1) === ' ') {
                value = value.substr(0, start - 1);
                console.log('4 doKey start=' + start + '   value=' + value);
            }
        }
        ele.value = value;
        ele.setSelectionRange(start+2, start+2);
        console.log('start=' + ele.selectionStart + '   end=' + ele.selectionEnd);
        this._Utilities.selectWord(ele);

    }

// #####################  get & put data via AsrService ##########################

    getAsr() {
        this._asrService.getAsr()
            .subscribe(
            asrtext => {
                // Todo - We should be able to just move asrtext to this.asrtext.
                // It appears to move the data OK. When I stop at a breakpoint, the 
                // the data is all there. But accessing it from the HTML 
                // causes an error (It says asrtext is null).
                this.asr = asrtext.asrsegments;
                this.lastedit = asrtext.lastedit;
                // console.log('asr=' + this.asr);

                // This causes an error: "lastedit not a property of asrtext"
                // this.asrtext.lastedit = asrtext.lastedit;
            },
            error => this.errorMessage = <any>error);
    }

    saveChanges() {
        console.log('saveTranscript');
        this._asrService.postChanges(this.asrtext)
            .subscribe (
                t => t
            );
        //error => this.errorMessage = <any>error);
    }

// #####################  Play selected part of video ####################################

    playPhrase(i : number) {
        if (i === this.lastPhrasePlayed) return;
        this.lastPhrasePlayed = i;

        let maxPhraseTime = 6; // minimum time of a single phrase
        let beforeTime = 1;  // time to play before
        let afterTime = 3;   // and after selected phrase
        let startTime  = this.asr[i].startTime;

        console.log('In fixasr playPhrase, index=' + i);

        // Play for contextTime seconds before selected phrase
        let start = this.convertToSeconds(startTime) - beforeTime;
        if (start < 0) {start = 0;}

        // Assume duration is maxPhraseTime seconds if this is the last phrase.
        // Otherwise play for (contextTime * 2) seconds longer than duration.
        // This means contextTime before and contextTime after.
        let duration = maxPhraseTime;
        if (this.asr.length > i+1) {
            let endTime : string  = this.asr[i+1].startTime;
            duration = this.convertToSeconds(endTime) - start + beforeTime + afterTime;
        }
        this.videoComponent.playPhrase(start, duration);
    }

   convertToSeconds(time: string) {
       var array = time.split(':');
       let count = array.length;
       let seconds = 0;
       while (count > 0) {
           seconds = seconds + Number(array[count - 1]) * Math.pow(60, array.length - count);
           console.log('In convertToSeconds, seconds=' + seconds);
           count--;
       }
       return seconds;
   }
}
