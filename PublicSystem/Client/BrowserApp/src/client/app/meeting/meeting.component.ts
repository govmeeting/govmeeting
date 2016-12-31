import { Component } from '@angular/core';
import { NewfooterComponent } from './newfooter/index';
import { HeadingComponent } from './heading/index';
// import { SpeakersComponent } from './speakers/index';
// import { TopicsComponent } from './topics/index';
import { BrowsemeetingComponent } from './browsemeeting/index';
// import {HTTP_PROVIDERS} from '@angular/http';
import { BackendService } from '../shared/index';
import { UserchoiceService } from '../shared/index';


/**
 * This class represents the lazy loaded MeetingComponent.
 */
@Component({
  moduleId: module.id,
  selector: 'sd-meeting',
  templateUrl: 'meeting.component.html',

  // directives: [NewfooterComponent, HeadingComponent,
  //  SpeakersComponent, TopicsComponent, BrowsemeetingComponent],

    // We declare these providers here, so that there is only one instance of each for
    // the entire meeting SPA. If we declared these providers in the sub-components,
    // we would have a new instance injected each time the component was created.
    providers: [
        // HTTP_PROVIDERS,
        BackendService,
        UserchoiceService
    ],

   styleUrls: ['meeting.component.css']
})
export class MeetingComponent {

    constructor(private _backendService: BackendService) { };

    postMeeting() {
        console.log('postMeeting');
        this._backendService.postMeeting()
        .subscribe(
            t => {
                
                t
            })
            //error => this.errorMessage = <any>error);
    }
}
