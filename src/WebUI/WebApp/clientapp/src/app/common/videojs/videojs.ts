// videojs.component.ts
import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import videojs from 'video.js';
import { timer } from 'rxjs';

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
    // aspectRatio: string;
    autoplay: boolean;
    controls: boolean;
    muted: boolean;
    playsinline: boolean;
    sources: {
      src: string;
      type: string;
    }[];
  };
  player: videojs.Player;

  constructor(private elementRef: ElementRef) {}

  ngOnInit() {
    // instantiate Video.js
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
}
