import { Component, OnInit } from '@angular/core';
import { ViewTranscriptService } from '../viewtranscript.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-heading',
  templateUrl: './heading.html',
  styleUrls: ['./heading.css'],
})
export class HeadingComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  meeting: any = {
    meetingId: 0,
    locationId: 0,
    governmentBody: '',
    language: '',
    date: '',
    meetingLength: 0,
  };

  errorMessage: string;

  constructor(private _viewMeetingService: ViewTranscriptService) {}

  ngOnInit() {
    this.getMeeting();
  }

  getMeeting() {
    this._viewMeetingService.getMeeting(null).subscribe(
      (viewMeeting: any) => {
        this.meeting = viewMeeting.meeting;
        NoLog || console.log(this.ClassName, this.meeting);
      },
      (error: any) => (this.errorMessage = error as any)
    );
  }
}
