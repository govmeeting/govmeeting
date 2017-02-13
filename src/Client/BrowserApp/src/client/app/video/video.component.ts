import { Component } from '@angular/core';
import { VgAPI } from 'videogular2/core';
import { Observable } from 'rxjs/Rx';

@Component({
  moduleId: module.id,
  selector: 'sd-video',
  templateUrl: 'video.component.html',
  styleUrls: ['video.component.css']
})
export class VideoComponent {
    sources:Array<Object>;
    api:VgAPI;

    onPlayerReady(api:VgAPI) {
        this.api = api;
        console.log('In video OnPlayerReady');
    }
    constructor() {
        this.sources = [
/*            {
              src: 'assets/2016-10-11 Boothbay Harbor Selectmen Oct 11.mp4',
              type: 'video/mp4'
            }
*/
            {
              src: 'assets/2016-10-11 Boothbay Harbor Selectmen (3 minutes).mp4',
              type: 'video/mp4'
            }
/*            {
              src: 'assets/2016-10-11 Boothbay Harbor Selectmen (3 minutes).ogg',
              type: 'video/ogg'
            }
            {
                src: "http://static.videogular.com/assets/videos/videogular.mp4",
                type: "video/mp4"
            },
            {
                src: "http://static.videogular.com/assets/videos/videogular.ogg",
                type: "video/ogg"
            },
            {
                src: "http://static.videogular.com/assets/videos/videogular.webm",
                type: "video/webm"
            }
*/
        ];
    }

    playPhrase(start : number, duration : number) {
        console.log('In video playPhrase, start=' + start + ' duration=' + duration);
        let timer = Observable.timer(duration * 1000);
        timer.subscribe(t=>this.api.pause());
        //timer.subscribe(t=>console.log("done with timeout"));
        this.api.seekTime(start);
        this.api.play();
        console.log('exiting video playPhrase');
    }
 }
