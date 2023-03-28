import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { ElementRef } from '@angular/core';
import { PlayPhraseData } from '../../models/edittranscript-view';

// import { VideoComponent } from '../../common/video/video';
import { VideojsComponent } from '../../common/videojs/videojs';
import { TalksComponent } from './talks/talks';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-edittranscript',
  templateUrl: './edittranscript.html',
  styleUrls: ['./edittranscript.css'],
})
export class EditTranscriptComponent {
  private ClassName: string = this.constructor.name + ': ';

  showhelp = false; // if true, shows the help box to the user
  hiliteSpeech = false; // if true, hilite spoken text

  @ViewChild(VideojsComponent, { static: false })
  private videojsComponent: VideojsComponent | null = null;

  @ViewChild(TalksComponent, { static: true }) talksComp: TalksComponent | null = null;
  @ViewChild('gmvideojs', { read: ElementRef }) gmVideojs: ElementRef | null = null;

  constructor() {}

  // TODO - We may decide to turn on speech hiliting by default.
  // ngAfterViewInit() {
  //   this.onHiliteSpeech();
  // }

  CheckShowHelp(): boolean {
    return this.showhelp;
  }
  ToggleHelp() {
    this.showhelp = !this.showhelp;
  }

  // Capture the "playVideo" event and play the talk.
  onplayVideo(data: PlayPhraseData) {
    NoLog || console.log(this.ClassName + 'onplayVideo ', data.start);
    // this.videoComponent.playPhrase(data.start, data.duration);
    if (this.videojsComponent) {
      this.videojsComponent.playPhrase(data.start, data.duration);
    }
  }

  handleCueChange = () => {
    if (this.videojsComponent) {
      const textTrack = this.videojsComponent.getTextTrack();
      if (textTrack) {
        // @ts-ignore
        const activeCue = textTrack.activeCues[0];
        // We were sometimes getting two cuechange events for the same cue.
        // The first event had activeCue undefined. So we check for that here.
        // TODO: Why does this only happen when the speaker changes?
        if (activeCue !== undefined && activeCue.id !== undefined) {
          this.hiliteSpecificCaption(parseInt(activeCue.id, 10));
        }
        // @ts-ignore
        // console.log(activeCue.text);
      }
      // NOTE: prettier keeps putting the semicolon back on the next line if it's removed.
      //       But tslint keeps conplaining that it's there.
      //       The solution is to add "ignore-bound-class-methods" in tslint.json to the
      //       semicolon:options.
    }
  };

  onHiliteSpeech() {
    if (this.videojsComponent && this.talksComp) {
      const textTrack = this.videojsComponent.getTextTrack();
      if (this.hiliteSpeech) {
        textTrack.removeEventListener('cuechange', this.handleCueChange);
        this.talksComp.removePriorHilite();
      } else {
        textTrack.addEventListener('cuechange', this.handleCueChange);
      }
      this.toggleHiliteSpeech();
    }
  }

  // Hilite specific caption.
  // The captionIds are sequential with the 1st caption being "1".
  hiliteSpecificCaption(captionId: number) {
    // Call a method on the TalksComponent
    if (this.talksComp) {
      this.talksComp.hiliteCaptionText(captionId);
    }
  }

  toggleHiliteSpeech() {
    this.hiliteSpeech = !this.hiliteSpeech;
  }

  // (for debugging)
  // onGetTracks() {
  //   this.videojsComponent.getTracks();
  // }

  // (experiment) This rotates the video
  // onRotate() {
  //   this.videojsComponent.rotateVideo();
  // }
}
