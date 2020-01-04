import { Component, OnInit } from '@angular/core';
import { ViewMeetingService } from '../viewmeeting.service';

@Component({
  selector: 'gm-heading',
  templateUrl: './heading.html',
  styleUrls: ['./heading.css']
})
export class HeadingComponent implements OnInit {

    meeting: any = {
        meetingId: 0,
        locationId: 0,
        governmentBody: '',
        language: '',
        date: '',
        meetingLength: 0
    };

  errorMessage: string;

  constructor(private _viewMeetingService: ViewMeetingService) { }

  ngOnInit() {this.getMeeting();}

  getMeeting() {
    this._viewMeetingService.getMeeting()
    .subscribe(
    (viewMeeting: any) => {
        this.meeting = viewMeeting.meeting;
        // console.log(this.meeting);
    },
    (error: any) => this.errorMessage = <any>error);
}

}
