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

const NoLog = false; // set to false for console logging

@Component({
  selector: 'gm-videojs',
  templateUrl: './videojs.html',
  styleUrls: ['./videojs.css'],
  encapsulation: ViewEncapsulation.None,
})
export class VideojsComponent implements OnInit, OnDestroy, AfterViewInit {
  private ClassName: string = this.constructor.name + ': ';

  @ViewChild('target', { static: true }) target: ElementRef;
  @ViewChild('target', { read: ElementRef }) targetElement: ElementRef;

  // <gm-videojs _ngcontent-tpj-c384="" ...
  //     <div id="vjs_video_3" ...
  //        ...
  //        <div class ="vjs-playback-rate ...
  //          <div class="vjs-playback-rate-value ...
  //            <button class=vjs-playback-rate vjs-menu-button ...
  // @ViewChild('vjs_video_3') vjs_video_3: ElementRef;

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

  ngAfterViewInit() {
    console.log('---ngAfterViewInit() Demo---');
    var x = this.targetElement;
    var y = this.targetElement.nativeElement;
    var z = 1;
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

  createButton(icon: string) {
    var button = document.createElement('button');
    button.classList.add('vjs-menu-button');
    // create "rotate" icon. [ When I pasted the code sequence below into
    // a Google search, it displayed a roatate icon. ]
    button.innerHTML = icon;
    button.style.fontSize = '1.8em';
    return button;
  }

  insertAfter(newEl, element) {
    element.parentNode.insertBefore(newEl, element.nextSibling);
  }

  // Create buttons, attach click handlers and add them to the video element.
  // rotate(player) {
  rotate(gmVideojs: ElementRef) {
    var dimension = 0;
    var rotateLeftIcon = '&#8635;';
    var rotateRightIcon = '&#8634;';

    var rotateLeftButton = this.createButton(rotateLeftIcon);
    var rotateRightButton = this.createButton(rotateRightIcon);

    rotateLeftButton.onclick = function () {
      dimension += 90;
      dimension %= 360;
      // player.zoomrotate({ rotate: dimension });
    };

    rotateRightButton.onclick = function () {
      dimension -= 90;
      if (Math.abs(dimension) == 360) {
        dimension = 0;
      }
      // player.zoomrotate({ rotate: dimension });
    };

    // Add the buttons after the playbackRate button
    // var playbackRate = document.querySelector('vjs-playback-rate');
    // var pbr = this.vjs_video_3;
    // var playbackRate = this.vjs_video_3.nativeElement.querySelector('vjs-playback-rate');
    // var t: ElementRef = this.target;
    // var te: ElementRef = this.targetElement;
    // var vv3 = gmVideojs.nativeElement.querySelector('#vjs_video_3');
    // var playbackRate = gmVideojs.nativeElement.querySelector(
    //   '#vjs-playback-rate-value-label-vjs_video_3_component_262'
    // );
    var playbackRate = gmVideojs.nativeElement.querySelector('.vjs-playback-rate');
    this.insertAfter(rotateLeftButton, playbackRate);
    this.insertAfter(rotateRightButton, rotateLeftButton);
  }
}
