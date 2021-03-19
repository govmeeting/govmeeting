import { Component, OnInit } from '@angular/core';
// import { VgAPI } from 'videogular2/core';
import { VgApiService } from '@videogular/ngx-videogular/core';

import { Observable } from 'rxjs';
import { timer } from 'rxjs/observable/timer';
import { AppData } from '../../appdata';
import { VideoService } from './video.service';

class VideoSource {
  src: string;
  type: string;
}

// https://github.com/videogular/videogular2
// https://stackblitz.com/edit/angular-videogular?file=app%2Fhello.component.ts
// https://www.npmjs.com/package/videogular2
// https://videogular.github.io/videogular2/docs/getting-started/

const NoLog = false; // set to false for console logging

@Component({
  selector: 'gm-video',
  templateUrl: 'video.html',
  styleUrls: ['video.css'],
})
export class VideoComponent {
  private ClassName: string = this.constructor.name + ': ';

  sources: Array<VideoSource>;
  // api: VgAPI;
  api: VgApiService;

  onPlayerReady(api: VgApiService) {
    this.api = api;
    NoLog || console.log(this.ClassName + 'OnPlayerReady');
    // api.play();
  }

  // constructor(private appData: AppData) {
  constructor(private appData: AppData, private _videoService: VideoService) {
    NoLog || console.log(this.ClassName + 'constructor - AppData=', appData);

    let location: string = _videoService.getLocation();
    let fileBasename = _videoService.getFileBasename();

    if (appData.isLargeEditData) {
      location = 'assets/DATA_IGNORED_BY_GIT/';
      fileBasename = 'USA_NJ_Passaic_LittleFalls_TownshipCouncil_en_2020-06-20';
    }

    NoLog || console.log(this.ClassName + 'location=' + location);
    NoLog || console.log(this.ClassName + 'fileBasename=' + fileBasename);

    this.sources = [
      {
        // src: location + '2016-10-11 Boothbay Harbor Selectmen (3 minutes).mp4',
        src: location + fileBasename + '.mp4',
        type: 'video/mp4',
      },

      /*   // TODO - provide .ogg and .webm versions of the videos
          {
            src: location + location + fileBasename + '.ogg',
            type: 'video/ogg'
          },
          {
            src: location + location + fileBasename + '.webm',
            type: 'video/webm'
          }
      */
    ];
  }

  playPhrase(start: number, duration: number) {
    NoLog || console.log(this.ClassName + 'playPhrase, start=' + start + ' duration=' + duration);
    // const timer = Observable.timer(duration * 1000);
    const timerx = timer(100); // yield for 100 milliseconds
    timerx.subscribe((t) => this.api.pause());
    // timer.subscribe(t=>NoLog || console.log(this.ClassName + 'done with timeout'));
    this.api.seekTime(start);
    this.api.play();
    NoLog || console.log(this.ClassName + 'exiting playPhrase');
  }
}
