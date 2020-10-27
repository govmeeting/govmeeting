import { Component, OnInit } from '@angular/core';
// import { MeetingService } from '../meeting.service-stub';
import { ViewTranscriptService } from '../viewtranscript.service';
import { UserchoiceService } from '../userchoice.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-topics',
  templateUrl: './topics.html',
  styleUrls: ['./topics.css'],
})
export class TopicsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  nameType = 'topicNames';
  Names: string[];
  errorMessage: string;
  selected = 0;

  constructor(private _meetingService: ViewTranscriptService, private _userChoice: UserchoiceService) {}

  ngOnInit() {
    this.getNames();
    this._userChoice.setTopic('SHOW ALL');
  }

  getNames() {
    this._meetingService.getMeeting(null).subscribe(
      (t) => {
        this.Names = t.topicNames;
        NoLog || console.log(this.ClassName, this.Names);
      },
      (error) => (this.errorMessage = error as any)
    );
  }

  IsSelected(i: number): boolean {
    return this._userChoice.getTopic() === this.Names[i];
  }

  Filter(i: number) {
    this.selected = i;
    this._userChoice.setTopic(this.Names[i]);
  }
}
