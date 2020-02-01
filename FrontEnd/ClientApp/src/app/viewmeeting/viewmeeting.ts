import { Component, OnInit } from '@angular/core';
import { UserchoiceService } from './userchoice.service';
import { ViewMeetingService } from './viewmeeting.service';
import { TopicDiscussion } from '../models/viewmeeting-view'


@Component({
  selector: 'gm-viewmeeting',
  templateUrl: './viewmeeting.html',
  styleUrls: ['./viewmeeting.css'],
  providers: [
    UserchoiceService
  ]
})
export class ViewMeetingComponent implements OnInit {
    showhelp: boolean = true;
    showhidehelp: string = "Hide";
    topicDiscussions: TopicDiscussion[];
    errorMessage: string;

    constructor(private _viewMeetingService: ViewMeetingService) {
  }
    // Normally the meetingId will be passed to the getMeeting method.
    // But we did not yet write the component for the user to select a meeting.
    // We will use id "1" for now. This maps to a meeting of BBH on the server.
    // On the server, we will get information about this meeting from the database via the meetingId.
    // For development, this means calling a routine in DatabaseRepsitories_Lib/MeetingRepository_Stub.cs.
    // If you look at this file, you will see that meetingId "1" maps to a meeting of the
    // Boothbay Harbor Selectmen on 9/8/2014.
    private meetingId = 1;

    ngOnInit() {this.getTopicDiscussions();}

    getTopicDiscussions() {
        this._viewMeetingService.getMeeting(this.meetingId)
        .subscribe(
        t => {
            this.topicDiscussions = t.topicDiscussions;
             console.log(this.topicDiscussions);
        },
        error => this.errorMessage = <any>error);
    }


    CheckShowHelp(): boolean {
        return this.showhelp;
    }
    ToggleHelp() {
        this.showhidehelp = this.showhelp ? "Show" : "Hide";
        this.showhelp = !this.showhelp;
    }
}
