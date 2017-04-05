import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
//import { HTTP_PROVIDERS } from '@angular/http';
import { MeetingService } from '../meeting.service';
import { UserchoiceService } from '../userchoice.service';

@Component({
    moduleId: module.id,
    selector: 'gm-browse-meeting',
    templateUrl: 'browsemeeting.component.html'
})
export class BrowsemeetingComponent implements OnInit {

    topicDiscussions: any;
    topics: string[];
    errorMessage: string;

    /**
     * <summary>
     *  BrowseMeetingCtrl Constructor.
     * </summary>
     * <param name="_meetingService">       The meeting service. </param>
     * <param name="_userChoiceSrv"> The user choice service. </param>
    **/
    constructor(private _meetingService: MeetingService,
        private _userChoice: UserchoiceService) {
    }

    ngOnInit() {this.getTopicDiscussions();}

    getTopicDiscussions() {
        this._meetingService.getMeeting()
        .subscribe(
        t => {
            this.topicDiscussions = t.topicDiscussions;
             //console.log(this.topicDiscussions);
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
        //console.log("CheckShowTopic " + topicName + " " + _topic);
        return ((_topic === 'SHOW ALL') || (_topic === topicName));
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
        //console.log("CheckShowSpeaker " + speakerName + " " + _speaker);
        return ((_speaker === 'SHOW ALL') || (_speaker === speakerName));
    }
}
