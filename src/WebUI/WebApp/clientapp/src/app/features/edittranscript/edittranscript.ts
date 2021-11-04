import { Component, OnInit, ViewChild } from '@angular/core';
import { ElementRef } from '@angular/core';
import { PlayPhraseData } from '../../models/edittranscript-view';

// import { VideoComponent } from '../../common/video/video';
import { VideojsComponent } from '../../common/videojs/videojs';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-edittranscript',
  templateUrl: './edittranscript.html',
  styleUrls: ['./edittranscript.css'],
})
export class EditTranscriptComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';

  showhelp = false; // if true, shows the help box to the user

  @ViewChild('myInput', { static: false }) input: ElementRef;

  // @ViewChild(VideoComponent, { static: false })
  // private videoComponent: VideoComponent;

  @ViewChild(VideojsComponent, { static: false })
  private videojsComponent: VideojsComponent;

  @ViewChild('gmvideojs', { read: ElementRef }) gmVideojs: ElementRef;

  constructor() {}

  ngOnInit() {}

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

  onGetTracks() {
    this.videojsComponent.getTracks();
  }

  onRotate() {
    this.videojsComponent.rotateVideo();
  }
}
