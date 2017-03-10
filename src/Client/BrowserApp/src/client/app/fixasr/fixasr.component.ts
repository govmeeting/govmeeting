import { Component, OnInit } from '@angular/core';
import { AfterViewInit, ViewChild } from '@angular/core';
import { AsrSegment } from './asrsegment';
import { AsrService } from './asr.service';
import { VideoComponent } from '../video/video.component';

// test
import { ElementRef, Renderer } from '@angular/core';
import { HostListener } from '@angular/core';

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
        AsrService
    ]
})
export class FixasrComponent  implements OnInit, AfterViewInit {
    //isTest : boolean = true;
    errorMessage: string;
    title = 'fixasr works!';
    asr : AsrSegment[];
    lastPhrasePlayed : number = 0;
    currentIndex : number = -1;
    isTyping : boolean = false;
    firstSpace : boolean = false;

    //test
    insideWords : string = "0123 4567 890A BCDE FGHI"
    insideWords2 : string = "ABC EFG IJK MNO QRS"
    private selection: Selection;

    // https://github.com/videogular/videogular2/blob/master/docs/using-the-api.md

    @ViewChild(VideoComponent)
    private videoComponent : VideoComponent;

    // test
    @ViewChild('myInput') input: ElementRef;
    _el : HTMLElement;

    // test
    // constructor(private _asrService: AsrService) {
    constructor(private _asrService: AsrService, private renderer: Renderer) {
    }

    onFocus(event: any, i : number){
        console.log("onFocus index=" + i);
        this.currentIndex = i;
        this.isTyping = false;
        this.firstSpace = false;
    }

    // test
    doMouseup(event: any, i : number) {
        // console.log(window.getSelection());
        var ele : HTMLInputElement = (<HTMLInputElement>event.target);
        console.log("doMouseup index=" + i + "   start=" + ele.selectionStart + "   end=" + ele.selectionEnd);
        console.log("doMouseup value=" + ele.value);
        // ele.setSelectionRange(4,8);
        this.selectWord(ele);
        // if index is new, play phrase
        // select word clicked on, or next word if not on word
    }

    gotoNextInputElement(ele : HTMLInputElement, i : number) {
        var next : HTMLInputElement = <HTMLInputElement>(ele.parentElement.parentElement.children[i + 2].children[0]);
        console.log(next.value);
        //var next : HTMLInputElement = <HTMLInputElement>(ele.nextElementSibling);
        if (typeof next.setSelectionRange != 'undefined') {
            next.setSelectionRange(1, 1);
            this.selectWord(next);
            next.focus();
        }
    }

    gotoPriorInputElement(ele : HTMLInputElement, i : number) {
        var prior : HTMLInputElement = <HTMLInputElement>(ele.parentElement.parentElement.children[i].children[0]);
        //var prior : HTMLInputElement = <HTMLInputElement>(ele.previousElementSibling);
        if (typeof prior.setSelectionRange != 'undefined') {
            prior.setSelectionRange(1, 1);
            this.selectWord(prior);
            prior.focus();
        }
    }

    gotoLastWordInPriorInputElement(ele : HTMLInputElement, i : number) {
        var prior : HTMLInputElement = <HTMLInputElement>(ele.parentElement.parentElement.children[i].children[0]);
        //var prior : HTMLInputElement = <HTMLInputElement>(ele.previousElementSibling);
        var len = prior.value.length
        if (typeof prior.setSelectionRange != 'undefined') {
            prior.setSelectionRange(len - 1, len - 1);
            this.selectWord(prior);
            prior.focus();
        }
    }
    gotoNextWord(ele : HTMLInputElement) {
        var end : number = ele.selectionEnd;
        ele.setSelectionRange(end + 2, end + 2);
        this.selectWord(ele);
    }

    gotoPriorWord(ele : HTMLInputElement) {
        var start : number = ele.selectionStart;
        ele.setSelectionRange(start - 2, start - 2);
        this.selectWord(ele);
    }


    doKey(event: any, i : number) {
        var key = event.key;   // get key value
        var ele : HTMLInputElement = (<HTMLInputElement>event.target);
        var value : string = ele.value;
        var start : number = ele.selectionStart;
        var end : number = ele.selectionEnd;
        

        console.log("doKey: key='" + key +"'" + "   isTyping=" + this.isTyping)
        console.log("1 doKey index=" + i + "   start=" + start + "   end=" + end);

        switch (key) {
            case 'Enter':
                this.playPhrase(i);
                return;
            case 'ArrowRight':
            if (end  < value.length) {
                this.gotoNextWord(ele);
            } else {
                this.gotoNextInputElement(ele, i);
            }
            return;
          case 'ArrowLeft':
                if (start != 0) {
                    this.gotoPriorWord(ele);
               } else {
                    this.gotoLastWordInPriorInputElement(ele, i);
                }
                return;
            case 'ArrowDown':
                this.gotoNextInputElement(ele, i);
                return;
            case 'ArrowUp':
                this.gotoPriorInputElement(ele, i);
                return;
        }



        // If not space, set isTyping true and firstSpace false and return
        if (key != " ") {
            this.isTyping = true;
            this.firstSpace = false;
            return;
        }

        // If they typed a space at the end of the text, set firstSpace & return
        if (start == value.length) {
            if (this.firstSpace == false) {
                this.firstSpace = true;
                return;
            }
        }

        if (this.isTyping == true) {
            // ignore fist space if they were typing
            if (this.firstSpace != true) {
                this.firstSpace = true;
                return;
            }
        }

        // They could have gotten here in 2 ways.
        // 1. They typed a second space after typing some text.
        // 2. They typed a space when a word was selected.
        // First remove the space they just typed
        console.log("2 left='" + value.substr(0, start - 1) + "'")
        console.log("2 right='" + value.substr(start) + "'")
        value = value.substr(0, start - 1) + value.substr(start)
        start--;
        console.log("2 doKey start=" + start + "   value='" + value + "'")

        // If there is a space right after the one they typed, remove that also.
        if (value.charAt(start) === " ") {
            console.log("3 left='" + value.substr(0, start - 1) + "'")
            console.log("3 right='" + value.substr(start) + "'")
            value = value.substr(0, start - 1) + value.substr(start)
            start--;
            console.log("3 doKey start=" + start + "   value='" + value + "'")
        }

        // "start" now is just before the next word, or at end of text.
        if (start == value.length) {
            if (value.charAt(start - 1) === " ") {
                value = value.substr(0, start - 1);
                console.log("4 doKey start=" + start + "   value='" + value + "'")
            }
        }
        ele.value = value;


        ele.setSelectionRange(start+2, start+2)
        console.log("start=" + ele.selectionStart + "   end=" + ele.selectionEnd);
        this.selectWord(ele);

    }

    ngOnInit() {
        this.getAsr();
        //this.getAsr(this.isTest);

    }

    ngAfterViewInit() {
        //console.log('In ngAfterViewInit');

        // test
        //console.log(this.input);
        //this._el = this.input.nativeElement;
        //this.renderer.invokeElementMethod(this._el, 'focus');
    }

    playPhrase(i : number) {
        if (i == this.lastPhrasePlayed) return;
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

    getAsr() {
        this._asrService.getAsr()
            .subscribe(
            talks => this.asr = talks,
            error => this.errorMessage = <any>error);
    }

    //getAsr(isTest: boolean) {
    //    if (isTest) {
    //        this.asr = this._asrService.getAsrFromMemory().data;
    //        console.log('return from getAsrFromMemory');
    //    } else {
    //        this._asrService.getAsr()
    //        .subscribe(
    //        talks => this.asr = talks,
    //        error => this.errorMessage = <any>error);
    //    }
    //}

    saveChanges() {
        console.log('saveTranscript');
        //this._talkService.postChanges(this.talks)
        this._asrService.postChanges(this.asr)
            .subscribe (
                t => t
            );
        //error => this.errorMessage = <any>error);
    }

    private selectWord(ele: HTMLInputElement) {
        var start = ele.selectionStart;
        var end = ele.selectionEnd;
        var content = ele.value;
        var contentLen = content.length;
        console.log('selectWord start=' + start + '   end=' + end);

        // If they actually selected some text, ignore
        // This also ignores a prior select that we set here. This has 
        // the effect of toggling the select on a word by clicking
        // on it multiple times.
        if (start != end) {
             console.log('selectWord ignore if current select');
           return;
        } 

        // If they clicked at start or end of text, ignore.
        if ((start == 0) || (start == contentLen) ||
            (content.charAt(start) == " ") || (content.charAt(start - 1) == " ")) {
            console.log('selectWord ignore if start or end of word');
            return;
        }
        // find start of word
        while (start > 0 && this.isNotSpace(content.charAt(start -1))) {
          start--;
        }
        // find end of word
        while (end < contentLen && this.isNotSpace(content.charAt(end))) {
          end++;
        }
        ele.setSelectionRange(start, end);
        console.log('selectWord newstart=' + start + '   newend=' + end);
   }

   private isNotSpace(ch: string) {
        return (ch != ' ');
   }

   private isAlphaNum(ch: string) {
       var code = ch.charCodeAt(0);
        if (!(code > 47 && code < 58) && // numeric (0-9)
            !(code > 64 && code < 91) && // upper alpha (A-Z)
            !(code > 96 && code < 123)) { // lower alpha (a-z)
        return false;
        }
        return true;
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
