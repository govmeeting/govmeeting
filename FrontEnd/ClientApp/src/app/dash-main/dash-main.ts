import { Component, OnInit, OnDestroy } from '@angular/core';
import {Router} from '@angular/router';
import { Subscription } from 'rxjs';

import { MessageService } from '../message.service';

console.log = function() {}  // comment this out for console logging

@Component({
  selector: 'gm-dash-main',
  templateUrl: './dash-main.html',
  styleUrls: ['./dash-main.scss']
})
export class DashMainComponent implements OnInit, OnDestroy {
  private ClassName: string = this.constructor.name;
  messages: any[] = [];
  subscription: Subscription;

  location: string;
  agency: string;

  govinfoTitle: string = "Politics";
  billsTitle: string = "Legislation";
  meetingsTitle: string = "Calendar";
  newsTitle: string = "Govmeeting News";
  fixasrTitle: string = "Proofread Transcripts";
  addtagsTitle: string = "Add Tags to Transcripts"
  viewMeetingTitle: string = "View Meetings";
  issuesTitle: string = "Issues";
  officialsTitle: string = "Officials";
  virtualMeetingTitle: string = "Virtual Meeting";
  chatTitle: string = "Chat Meeting";
  chartsTitle: string = "Charts Meeting";

  constructor(public router: Router, private messageService: MessageService) {
    // constructor(private messageService: MessageService) {

    this.subscription = this.messageService.getMessage().subscribe(message => {
      if (message) {
        this.messages.push(message);
        console.log(this.ClassName +"message=" + message.text)
        this.parseMessage(message.text);
        this.setTitles();
      } else {
        // clear messages when empty message received
        this.messages = [];
      }
    });
   }

  ngOnInit() {
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
}

  parseMessage(message: string) {
    let mes = message.split(':');
    if (mes[0] == 'AgencySelected') {
      this.location = mes[1];
      this.agency = mes[2];
      console.log(this.ClassName +"location:" + this.location);
    }
  }

  // These titles need to be set from within the individual components (gov-info, bills, calendar, etc)
  setTitles() {
    this.govinfoTitle = this.location + " Politics"
    this.billsTitle = this.location + " Legislation"
    this.meetingsTitle = this.agency + " Calendar"
    this.newsTitle = "Govmeeting News";
    this.fixasrTitle = "Proof 2/14 " + this.agency + " transcript";
    this.addtagsTitle = "Add tags to 2/21 " + this.agency + " transcript";
    this.viewMeetingTitle = "View " + this.agency + " meetings";
    this.issuesTitle = this.agency + " Issues";
    this.officialsTitle = this.agency + " Officials";
    this.virtualMeetingTitle = "Virtual Meeting";
    this.chatTitle = "Chat";
    this.chartsTitle = this.agency + " Charts";
    if ((this.agency.startsWith("All") || (this.agency.startsWith("Both")))) {
      this.fixasrTitle = "Proofread Transcripts";
      this.addtagsTitle = "Add Tags to Transcripts";
    } else {
      // These titles need to be set to the current transcript being worked on.
      this.fixasrTitle = "Proof 2/14 " + this.agency + " transcript";
      this.addtagsTitle = "Add tags to 2/21 " + this.agency + " transcript";
    }

  }

}
