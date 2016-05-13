import {Component, OnInit} from 'angular2/core';
import {Injectable} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {UserchoiceService, IUserChoiceSrv} from './../utilities/userchoice.service'
import {BackendService} from './../utilities/backend.service'

@Injectable()
@Component({
    selector: 'browsemeeting',
    templateUrl: './app/singlemeeting/browsemeeting.component.html',
//    template: `
//        {{topicDiscussions}}
//    `,
    directives: [],
    providers: [
        HTTP_PROVIDERS,
        UserchoiceService,
        BackendService
    ]
})
export class BrowsemeetingComponent {
    
    topicDiscussions: any;
    topics: string[];
    errorMessage: string;
    
        /**
         * <summary>
         *  BrowseMeetingCtrl Constructor.
         * </summary>
         * <param name="backEnd">       The back end service. </param>
         * <param name="userChoiceSrv"> The user choice service. </param>
        **/
    constructor(private _userChoice: UserchoiceService,
        private _backendService: BackendService) {
            this._userChoice.setSpeaker("SHOW ALL");
            this._userChoice.setTopic("SHOW ALL");
    }
    
    ngOnInit() {this.getTopicDiscussions();}
        

    getTopicDiscussions() {
        this._backendService.getTopicDiscussions()
        .subscribe(
        t => {this.topicDiscussions = t.data; console.log(this.topicDiscussions);},
        error => this.errorMessage = <any>error);
    }

    /**
     * <summary>
     *  Check whether to display this topic - only if it or "SHOW ALL" was selected.
     * </summary>
     * <param name="topicName"> Name of the topic. </param>
     * <returns>
     *  Returns true if this topic should be displayed
     * </returns>
    **/
    CheckShowTopic(topicName: string) {
        var _topic = this._userChoice.getTopic();
        return ((_topic == "SHOW ALL") || (_topic == topicName));
    }

    /**
     * <summary>
     *  Check whether to display this speaker - only if it or "SHOW ALL" was selected.
     * </summary>
     * <param name="speakerName">   Name of the speaker. </param>
     * <returns>
     *  Returns true if this speaker should be displayed
     * </returns>
    **/
    CheckShowSpeaker(speakerName: string) {
        var _speaker = this._userChoice.getSpeaker();
        return ((_speaker == "SHOW ALL") || (_speaker == speakerName))
    }
}