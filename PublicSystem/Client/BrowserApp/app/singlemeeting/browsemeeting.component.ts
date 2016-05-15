import {Component, OnInit} from 'angular2/core';
import {Injectable} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {BackendService} from './../utilities/backend.service'
import {UserchoiceService, IUserChoiceSrv} from './../utilities/userchoice.service'

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
        BackendService
        //UserchoiceService
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
    constructor(private _backendService: BackendService,
        private _userChoice: UserchoiceService) {
    }
    
    ngOnInit() {this.getTopicDiscussions();}
        

    getTopicDiscussions() {
        this._backendService.getMeeting()
        .subscribe(
        t => {this.topicDiscussions = t.data.topicDiscussions;
             // console.log(this.topicDiscussions);
            },
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
        // console.log("CheckShowTopic " + topicName + " " + _topic);
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
        // console.log("CheckShowSpeaker " + speakerName + " " + _speaker);
        return ((_speaker == "SHOW ALL") || (_speaker == speakerName))
    }
}