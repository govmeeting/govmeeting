import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../meeting.service';

@Component({
  selector: 'gm-heading',
  templateUrl: './heading.component.html',
  styleUrls: ['./heading.component.css']
})
export class HeadingComponent implements OnInit {

  meetingInfo: any = {name: '', date: ''};

  errorMessage: string;

  constructor(private _meetingService: MeetingService) { }

  ngOnInit() {this.getMeetingInfo();}

  getMeetingInfo() {
    this._meetingService.getMeeting()
    .subscribe(
    (meeting: any) => {
        this.meetingInfo = meeting.meetingInfo;
        //console.log(this.meetingInfo);
    },
    (error: any) => this.errorMessage = <any>error);
}

}
