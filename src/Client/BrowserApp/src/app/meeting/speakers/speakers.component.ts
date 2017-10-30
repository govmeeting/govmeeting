import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../meeting.service';
import { UserchoiceService } from '../userchoice.service';

@Component({
  selector: 'gm-speakers',
  templateUrl: './speakers.component.html',
  styleUrls: ['./speakers.component.css']
})
export class SpeakersComponent implements OnInit {

  speakerNames: string[];
  errorMessage: string;
  selectedSpeaker: number = 0;

  constructor(private _meetingService: MeetingService,
      private _userChoice: UserchoiceService) { }

  ngOnInit() {
    this.getSpeakerNames();
    this._userChoice.setSpeaker('SHOW ALL');
}

  getSpeakerNames() {
    this._meetingService.getMeeting()
    .subscribe(
    meeting => {
        this.speakerNames = meeting.speakerNames;
        // console.log(this.speakerNames);},
    },
    error => this.errorMessage = <any>error);
  }

  IsSelectedSpeaker(i: number) : boolean {
    return(this._userChoice.getSpeaker() === this.speakerNames[i]);
  }

  FilterBySpeaker(i: number) {
    this.selectedSpeaker = i;
    //console.log(this.speakerNames[i])
    this._userChoice.setSpeaker(this.speakerNames[i]);
    if (i!==0) {
        this._userChoice.setTopic('SHOW ALL');
    }
  }
}
