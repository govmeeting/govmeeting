// videojs.component.ts
import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import videojs from 'video.js';
import { timer } from 'rxjs';
import * as Hotkeys from 'videojs-hotkeys';

const NoLog = false; // set to false for console logging

@Component({
  selector: 'gm-videojs',
  templateUrl: './videojs.html',
  styleUrls: ['./videojs.css'],
  encapsulation: ViewEncapsulation.None,
})
export class VideojsComponent implements OnInit, OnDestroy {
  private ClassName: string = this.constructor.name + ': ';

  @ViewChild('target', { static: true }) target: ElementRef;
  // see options: https://github.com/videojs/video.js/blob/maintutorial-options.html
  @Input() options: {
    fluid: boolean;
    aspectRatio: string;
    autoplay: boolean;
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
  player: videojs.Player;

  private plugin: any;

  constructor(private elementRef: ElementRef) {
    this.plugin = Hotkeys;
  }

  ngOnInit() {
    // instantiate Video.js
    // this.player = videojs(this.target.nativeElement);
    this.player = videojs(this.target.nativeElement, this.options, function onPlayerReady() {
      console.log('onPlayerReady', this);
    });
  }

  ngOnDestroy() {
    // destroy player
    if (this.player) {
      this.player.dispose();
    }
  }

  playPhrase(start: number, duration: number) {
    NoLog || console.log(this.ClassName + 'playPhrase, start=' + start + ' duration=' + duration);
    start = start / 1000;

    // const timerxx = timer(duration);
    // this.api.currentTime = start;
    // this.api.play();
    // timerxx.subscribe((t) => this.api.pause());

    const pauseTimer = timer(duration);
    this.player.currentTime(start);
    this.player.play();
    pauseTimer.subscribe((t) => this.player.pause());

    NoLog || console.log(this.ClassName + 'exiting playPhrase');
  }

  getTracks() {
    var validTracks: TextTrack[] = [];
    var tracks: TextTrackList;
    var track: TextTrack;
    tracks = this.player.textTracks();
    for (var i = 0, L = tracks.length; i < L; i++) {
      track = tracks[i];
      if (track.kind === 'captions' || track.kind === 'subtitles') {
        validTracks.push(track);
      }

      if (track.language == 'en') {
        console.dir(tracks[i]);
      }
    }
    // tracks.forEach(function (track) {
    //   if (track.kind() === 'captions' || track.kind() === 'subtitles') {
    //     validTracks.push(track);
    //   }
    // });
    return validTracks;
  }

  getActiveTrack(tracks: TextTrackList): TextTrack {
    var track: TextTrack;
    for (var i = 0, L = tracks.length; i < L; i++) {
      track = tracks[i];
      if (track.mode === 'showing') {
        return track;
      }
    }
    // fallback to first track
    return tracks[0];
  }

  secondsToTime(timeInSeconds: number) {
    var hour: number = Math.floor(timeInSeconds / 3600);
    var min: number = Math.floor((timeInSeconds % 3600) / 60);
    var sec: number = Math.floor(timeInSeconds % 60);
    sec = sec < 10 ? 0 + sec : sec;
    min = hour > 0 && min < 10 ? 0 + min : min;
    if (hour > 0) {
      return hour + ':' + min + ':' + sec;
    }
    return min + ':' + sec;
  }
}
