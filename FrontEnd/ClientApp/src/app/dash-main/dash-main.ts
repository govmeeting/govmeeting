import { Component, OnInit, OnDestroy, Input} from '@angular/core';
import {Router} from '@angular/router';
import { Subscription } from 'rxjs';
import { UserSettingsService } from '../user-settings.service';

const NoLog = false;  // set to false for console logging

@Component({
  selector: 'gm-dash-main',
  templateUrl: './dash-main.html',
  styleUrls: ['./dash-main.scss']
})
export class DashMainComponent implements OnInit, OnDestroy {
  private ClassName: string = this.constructor.name + ": ";
  messages: any[] = [];
  subscription: Subscription;
  defaultLocation: string = "Boothbay Harbor";
  location: string = this.defaultLocation;
  agency: string;
  isCounty: boolean;

  // TODO These titles need to be set from within the individual components (gov-info, bills, calendar, etc)
  govinfoTitle: string = "Politics";
  billsTitle: string = "Legislation";
  meetingsTitle: string = "Meetings";
  newsTitle: string = "Govmeeting News";
  fixasrTitle: string = "Proofread Transcript";
  addtagsTitle: string = "Add Tags to Transcript"
  viewMeetingTitle: string = "View Latest Meeting";
  issuesTitle: string = "Issues";
  officialsTitle: string = "Officials";
  virtualMeetingTitle: string = "Virtual Meeting";
  chatTitle: string = "Chat";
  chartsTitle: string = "Charts";

  constructor(public router: Router, private LocationService: UserSettingsService) {
    // constructor(private LocationService: LocationService) {

    this.subscription = this.LocationService.getLocation().subscribe(message => {
      if (message) {
        this.messages.push(message);
        NoLog || console.log(this.ClassName + "receive location message=" + message.text)
        this.parseMessage(message.text);
        // this.setTitles();
      } else {
        // clear messages when empty message received
        this.messages = [];
      }
    });
   }

   ngOnInit() {
    NoLog || console.log(this.ClassName + "ngOnInit send location message")
    // this.LocationService.sendMessage('LocationSelected:' + this.defaultLocation + ':x');
    }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
}

  parseMessage(message: string) {
    let mes = message.split(':');
    if (mes[0] == 'LocationSelected') {
      this.location = mes[1];
      this.agency = mes[2];

      this.isCounty = (this.location == "Lincoln County")
      NoLog || console.log(this.ClassName + "location:" + this.location);
    }
  }

  // TODO These titles need to be set from within the individual components (gov-info, bills, calendar, etc)
  // setTitles() {
  //   // this.govinfoTitle = this.location + " Politics"
  //   // this.billsTitle = this.location + " Legislation"
  //   this.govinfoTitle = "Politics"
  //   this.billsTitle =  "Legislation"
  //   this.meetingsTitle = this.agency + " Meetings"
  //   this.newsTitle = "Govmeeting News";
  //   this.viewMeetingTitle = "View " + this.agency + " meetings";
  //   this.issuesTitle = this.agency + " Issues";
  //   this.officialsTitle = this.agency + " Officials";
  //   this.virtualMeetingTitle = "Virtual Meeting";
  //   this.chatTitle = "Chat";
  //   this.chartsTitle = this.agency + " Charts";
  //   if ((this.agency.startsWith("All") || (this.agency.startsWith("Both")))) {
  //     this.fixasrTitle = "Proofread Transcripts";
  //     this.addtagsTitle = "Add Tags to Transcripts";
  //   } else {
  //     // These titles need to be set to the current transcript being worked on.
  //     this.fixasrTitle = "Proof " + this.agency + " transcript";
  //     this.addtagsTitle = "Add tags to " + this.agency + " transcript";
  //   }
  // }

}
