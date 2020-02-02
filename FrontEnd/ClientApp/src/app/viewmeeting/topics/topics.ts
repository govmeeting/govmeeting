import { Component, OnInit } from '@angular/core';
//import { MeetingService } from '../meeting.service-stub';
import { ViewMeetingService } from '../viewmeeting.service';
import { UserchoiceService } from '../userchoice.service';

console.log = function() {}  // comment this out for console logging

@Component({
  selector: 'gm-topics',
  templateUrl: './topics.html',
  styleUrls: ['./topics.css']
})
export class TopicsComponent implements OnInit {
  private ClassName: string = this.constructor.name;
  nameType: string = 'topicNames';
  Names: string[];
  errorMessage: string;
  selected: number = 0;

  constructor(private _meetingService: ViewMeetingService,
    private _userChoice: UserchoiceService) { }

  ngOnInit() {
    this.getNames();
    this._userChoice.setTopic('SHOW ALL');
  }

  getNames() {
    this._meetingService.getMeeting(null)
    .subscribe(
    t => {
        this.Names = t.topicNames;
        console.log(this.ClassName +this.Names);
    },
    error => this.errorMessage = <any>error);
  }

  IsSelected(i: number) : boolean {
      return(this._userChoice.getTopic() === this.Names[i]);
  }

  Filter(i: number) {
      this.selected = i;
      this._userChoice.setTopic(this.Names[i]);
  }

}
