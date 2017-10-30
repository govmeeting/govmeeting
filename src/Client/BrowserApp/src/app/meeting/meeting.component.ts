import { Component, OnInit } from '@angular/core';
import { MeetingService } from './meeting.service';
import { UserchoiceService } from './userchoice.service';

@Component({
  selector: 'gm-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.css'],
  providers: [
    MeetingService,
    UserchoiceService
  ]
})
export class MeetingComponent implements OnInit {

  constructor(private _meetingService: MeetingService) { }

  ngOnInit() {
  }

  postMeeting() {
    console.log('postMeeting');
    this._meetingService.postMeeting()
    .subscribe(
        t => t
        );
        //error => this.errorMessage = <any>error);
}
}
