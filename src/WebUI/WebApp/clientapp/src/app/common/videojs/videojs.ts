// videojs.component.ts
import {
  Component,
  ElementRef,
  Input,
  OnDestroy,
  OnInit,
  AfterViewInit,
  ViewChild,
  ViewEncapsulation,
} from '@angular/core';
import videojs from 'video.js';
import { timer } from 'rxjs';
import * as Hotkeys from 'videojs-hotkeys';
// import * as ZoomRotate from 'videojs-rotatezoom';
// import { AddRotateButtons, RotateVideo } from './vjsutils/AddButtons';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-videojs',
  templateUrl: './videojs.html',
  styleUrls: ['./videojs.css'],
  encapsulation: ViewEncapsulation.None,
})
export class VideojsComponent implements OnInit, OnDestroy, AfterViewInit {
  private ClassName: string = this.constructor.name + ': ';
  player: videojs.Player | null = null;
  private hotkeysPlugin: any; // used in constructor and needed but why??
  // private zoomrotatePlugin: any;
  @ViewChild('target', { static: true }) target: ElementRef | null = null;
  @ViewChild('vjscontainer') vjscontainer: ElementRef | null = null;

  // see options: https://github.com/videojs/video.js/blob/maintutorial-options.html
  @Input() options:
    | undefined
    | {
        fluid: boolean;
        aspectRatio: string;
        // autoplay: boolean;
        preload: string;
        controls: boolean;
        muted: boolean;
        playsinline: boolean;
        playbackRates: number[];
        plugins: {
          hotkeys: {};
        };
        sources: {
          src: string;
          type: string;
        }[];
        tracks: {
          src: string;
          kind: TextTrackKind;
          srclang: string;
          label: string;
          default?: boolean;
        }[];
      };

  // zoomrotate: {};

  constructor(private elementRef: ElementRef) {
    this.hotkeysPlugin = Hotkeys;
    // this.zoomrotatePlugin = ZoomRotate;
  }

  ngOnInit() {
    // instantiate Video.js
    // this.player = videojs(this.target.nativeElement);
    if (this.target === null) {
      return;
    }
    this.player = videojs(this.target.nativeElement, this.options, function onPlayerReady() {
      NoLog || console.log('VideojsComponent: ' + 'onPlayerReady', this);
    });
  }

  ngAfterViewInit() {
    NoLog || console.log(this.ClassName + '---ngAfterViewInit() Demo---');
    // Experimenting with adding buttons to the video's control bar
    // AddRotateButtons(this.vjscontainer);
    // this.getCueChanges();
  }

  ngOnDestroy() {
    // destroy player
    if (this.player) {
      this.player.dispose();
    }
  }

  // rotateVideo() {
  //   RotateVideo(this.vjscontainer);
  // }

  playPhrase(start: number, duration: number) {
    if (this.player === null) {
      return;
    }
    NoLog || console.log(this.ClassName + 'playPhrase, start=' + start + ' duration=' + duration);
    start = start / 1000;
    const pauseTimer = timer(duration);
    this.player.currentTime(start);
    this.player.play();
    pauseTimer.subscribe((t) => {
      if (this.player !== null) this.player.pause();
    });
    NoLog || console.log(this.ClassName + 'exiting playPhrase');
  }

  getActiveTrack(tracks: TextTrackList): TextTrack {
    let track: TextTrack;
    for (let i = 0, L = tracks.length; i < L; i++) {
      track = tracks[i];
      if (track.mode === 'showing') {
        return track;
      }
    }
    // fallback to first track
    return tracks[0];
  }

  secondsToTime(timeInSeconds: number) {
    const hour: number = Math.floor(timeInSeconds / 3600);
    let min: number = Math.floor((timeInSeconds % 3600) / 60);
    let sec: number = Math.floor(timeInSeconds % 60);
    sec = sec < 10 ? 0 + sec : sec;
    min = hour > 0 && min < 10 ? 0 + min : min;
    if (hour > 0) {
      return hour + ':' + min + ':' + sec;
    }
    return min + ':' + sec;
  }

  getCueChanges() {
    if (this.player === null) {
      return;
    }
    const textTrack = this.player.textTracks()[0];
    textTrack.addEventListener('cuechange', (event) => {
      // @ts-ignore
      const activeCue = textTrack.activeCues[0];
      console.log(activeCue.startTime, activeCue.endTime);
      // @ts-ignore
      console.log(activeCue.text);
    });
  }

  getTextTrack(): TextTrack {
    // @ts-ignore
    return this.player.textTracks()[0];
  }

  // (for debugging) returns array of all tracks on video
  getTracks() {
    if (this.player === null) {
      return;
    }
    const validTracks: TextTrack[] = [];
    let tracks: TextTrackList;
    let track: TextTrack;
    tracks = this.player.textTracks();
    for (let i = 0, L = tracks.length; i < L; i++) {
      track = tracks[i];
      if (track.kind === 'captions' || track.kind === 'subtitles') {
        validTracks.push(track);
      }
      if (track.language === 'en') {
        console.dir(tracks[i]);
      }
    }
    return validTracks;
  }
}
