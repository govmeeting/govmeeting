import { Component, OnInit } from '@angular/core';
//import { MeetingService } from '../meeting.service-stub';
import { ViewMeetingService } from '../service';
import { UserchoiceService } from '../userchoice.service';

@Component({
  selector: 'gm-topics',
  templateUrl: './component.html',
  styleUrls: ['./component.css']
})
export class TopicsComponent implements OnInit {

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
    this._meetingService.getMeeting()
    .subscribe(
    t => {
        this.Names = t.topicNames;
        // console.log(this.topicNames);
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
