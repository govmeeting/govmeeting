import {Component} from 'angular2/core';
import {NavbarComponent} from './navigation/navbar.component'
import {FooterComponent} from './navigation/footer.component'
import {HeadingComponent} from './singlemeeting/heading.component'
import {BrowsemeetingComponent} from './singlemeeting/browsemeeting.component'
import {TopicsComponent} from './singlemeeting/topics.component'
import {SpeakersComponent} from './singlemeeting/speakers.component'
import {BackendService} from './utilities/backend.service'
import {UserchoiceService, IUserChoiceSrv} from './utilities/userchoice.service'

@Component({
    selector: 'my-app',
    templateUrl: './app/app.component.html',
    directives: [NavbarComponent, FooterComponent, HeadingComponent,
        BrowsemeetingComponent, TopicsComponent, SpeakersComponent]
    //providers: [BackendService, UserchoiceService]
        ,
})
export class AppComponent {
    
    constructor(private _userChoice: UserchoiceService) {
            this._userChoice.setSpeaker("SHOW ALL");
            this._userChoice.setTopic("SHOW ALL");
    }   
}