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
export class EditTranscriptComponent implements OnInit, AfterViewInit {
  private ClassName: string = this.constructor.name + ': ';

  showhelp = false; // if true, shows the help box to the user

  // @ViewChild('myInput', { static: false }) input: ElementRef;

  // Prior component based on Videogular
  // @ViewChild(VideoComponent, { static: false })
  // private videoComponent: VideoComponent;

  @ViewChild(VideojsComponent, { static: false })
  private videojsComponent: VideojsComponent;

  @ViewChild(TalksComponent, { static: true }) talksComp: TalksComponent;

  @ViewChild('gmvideojs', { read: ElementRef }) gmVideojs: ElementRef;

  constructor() {}

  ngOnInit() {}

  ngAfterViewInit() {
    // this.onGetCues();
  }

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
    this.videojsComponent.playPhrase(data.start, data.duration);
  }

  onGetCues() {
    // this.videojsComponent.getCueChanges();

    const textTrack = this.videojsComponent.getTextTrack();
    textTrack.addEventListener('cuechange', (event) => {
      const activeCue = textTrack.activeCues[0];
      console.log(activeCue.id, activeCue.startTime, activeCue.endTime);
      this.onSendCaptionId(parseInt(activeCue.id, 10));
      // @ts-ignore
      console.log(activeCue.text);
    });
  }

  onSendCaptionId(captionId: number) {
    this.talksComp.sendCaptionId(captionId);
  }

  onGetTracks() {
    this.videojsComponent.getTracks();
  }

  onRotate() {
    this.videojsComponent.rotateVideo();
  }
}
