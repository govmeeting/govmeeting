import { Component, OnInit } from '@angular/core';
import { AsrSegment } from './asrsegment';
import { AsrService } from './asr.service';

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
export class FixasrComponent  implements OnInit {
  errorMessage: string;
  title = 'fixasr works!';
  asr : AsrSegment[];
  s : string;

  constructor(private _asrService: AsrService) {
  }

  ngOnInit() {
      // this.getAsr();

      // The following would get the list in memory.
      this.asr = this._asrService.getAsrFromMemory().data;
      console.log('return from getAsrFromMemory');
      this.s = this.asr[0].said;

      //this.getTopics();
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
