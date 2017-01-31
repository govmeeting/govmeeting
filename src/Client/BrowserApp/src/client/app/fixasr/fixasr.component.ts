import { Component, OnInit } from '@angular/core';
import { AfterViewInit, ViewChild } from '@angular/core';
import { AsrSegment } from './asrsegment';
import { AsrService } from './asr.service';
import { VideoComponent } from '../video/video.component';

// This is the "Fix ASR" component for fixing the "Automatic Speech Recognition" errors.

@Component({
  moduleId: module.id,
  selector: 'fixasr',
  templateUrl: './fixasr.component.html',
  styleUrls: ['./fixasr.component.css'],
    providers: [
        // HTTP_PROVIDERS,
        AsrService,
    ]
})
export class FixasrComponent  implements OnInit, AfterViewInit{
    errorMessage: string;
    title = 'fixasr works!';
    asr : AsrSegment[];
    s : string;

    constructor(private _asrService: AsrService) {
    }

    // https://github.com/videogular/videogular2/blob/master/docs/using-the-api.md

    @ViewChild(VideoComponent)
    private videoComponent : VideoComponent;

    ngOnInit() {
        // this.getAsr();

        // The following would get the list in memory.
        this.asr = this._asrService.getAsrFromMemory().data;
        console.log('return from getAsrFromMemory');
        this.s = this.asr[0].said;

        //this.getTopics();
    }

    ngAfterViewInit() {
        console.log('In ngAfterViewInit');
    }

    playPhrase(i : number) {
        let maxPhraseTime = 6; // minimum time of a single phrase
        let contextTime = 1;  // time to play before and after selected phrase
        let startTime  = this.asr[i].startTime;

        console.log('In fixasr playPhrase, index=' + i);

        // Play for contextTime seconds before selected phrase
        let start = this.convertToSeconds(startTime) - contextTime;
        if (start < 0) {start = 0}

        // Assume duration is maxPhraseTime seconds if this is the last phrase.
        // Otherwise play for (contextTime * 2) seconds longer than duration.
        // This means contextTime before and contextTime after.
        let duration = maxPhraseTime;
        if (this.asr.length > i+1) {
            let endTime : string  = this.asr[i+1].startTime;
            duration = this.convertToSeconds(endTime) - start + contextTime * 2);
        } 

        this.videoComponent.playPhrase(start, duration);
    }
    convertToSeconds(time : string) {
        var array = time.split(":");
        let count = array.length;
        let seconds = 0;
        while (count > 0) {
            seconds = seconds + Number(array[count - 1]) * Math.pow(60, array.length - count);
            console.log('In convertToSeconds, seconds=' + seconds);
            count--;
        }
        return seconds;
    }

    getAsr() {
        this._asrService.getAsr()
        .subscribe(
        talks => this.asr = talks,
        error => this.errorMessage = <any>error);
    }

    saveChanges() {
        console.log('saveTranscript');
        //this._talkService.postChanges(this.talks)
        this._asrService.postChanges()
            .subscribe(
            t => {
                t;
            });
        //error => this.errorMessage = <any>error);
    }

}
