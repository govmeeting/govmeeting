import { Component } from '@angular/core';
import {VgApiService} from '@videogular/ngx-videogular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'video-player';

  preload: string = 'auto';
  api: VgApiService;

  constructor() {}

  // onPlayerReady(api: VgApiService) {
    videoPlayerInit(api: VgApiService) {
      this.api = api;

      this.api.getDefaultMedia().subscriptions.ended.subscribe(
        () => {
            // Set the video to the beginning
            this.api.getDefaultMedia().currentTime = 0;
        }
    );

  }

  DoSomething() {
    this.api.currentTime = 15;
    this.api.play();
  }

}
