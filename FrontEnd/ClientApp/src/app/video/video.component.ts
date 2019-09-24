import { Component, OnInit } from '@angular/core';
import { VgAPI } from 'videogular2/core';
import { Observable } from 'rxjs';
import { timer } from 'rxjs/observable/timer';
import { AppData } from '../appdata';

class videoSource {
  src: string;
  type: string
}

// https://github.com/videogular/videogular2
// https://stackblitz.com/edit/angular-videogular?file=app%2Fhello.component.ts
// https://www.npmjs.com/package/videogular2
// https://videogular.github.io/videogular2/docs/getting-started/

@Component({
  selector: 'gm-video',
  templateUrl: 'video.component.html',
  styleUrls: ['video.component.css']
})
export class VideoComponent {
    sources: Array<videoSource>;
    api: VgAPI;


    onPlayerReady(api: VgAPI) {
        this.api = api;
        console.log('In video OnPlayerReady');
        api.play();
    }

    constructor(private appData: AppData) {
      let location: string;

        console.log('VideoComponent constructor');
        console.log('AppData=' + appData);
        console.log('appData.isAspServerRunning=' + appData.isAspServerRunning);
        // TODO - Use the server API to return the video. Until then we need to specify the full path of the video file.
        // var location: string = 'api/video/3/1';  // This would be for MeetingID=3 Part=1

        // If Web_App is running, return from solutions's Datafiles folder
        if (appData.isAspServerRunning) {
          //location = 'datafiles/USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en/2017-02-15/Fixasr/part01/';
          location = 'datafiles/USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en/2017-01-09/Fixasr/part01/';
       // else return from ClientApp stubdata folder
        } else {
          location = 'assets/stubdata/';
        }
        console.log('location=' + location);
        const fileBasename = 'ToFix';

        this.sources = [
            {
                // src: location + '2016-10-11 Boothbay Harbor Selectmen (3 minutes).mp4',
                src: location + fileBasename + '.mp4',
                type: 'video/mp4'
            }
/*            // TODO - provide .ogg and .webm versions of the videos
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
        console.log('In video playPhrase, start=' + start + ' duration=' + duration);
        // const timer = Observable.timer(duration * 1000);
        const timerx = timer(100);   // yield for 100 milliseconds
        timerx.subscribe(t => this.api.pause());
        // timer.subscribe(t=>console.log('done with timeout'));
        this.api.seekTime(start);
        this.api.play();
        console.log('exiting video playPhrase');
    }
 }
