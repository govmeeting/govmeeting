import { Component, OnInit, OnDestroy, Input} from '@angular/core';
import {Router} from '@angular/router';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../../user-settings.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-dash-main',
  templateUrl: './dash-main.html',
  styleUrls: ['./dash-main.scss']
})
export class DashMainComponent implements OnInit, OnDestroy {
  private ClassName: string = this.constructor.name + ": ";
  subscription: Subscription;
  location: string;
  agency: string;
  isMunicipal: boolean;
  isCounty: boolean;
  isState: boolean;
  isCountry: boolean;

  // TODO These titles should be set from within the individual components (gov-info, bills, calendar, etc)
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
  notesTitle: string = "Notes";
  minutesTitle: string = "Meeting Minutes";
  workitemsTitle: string = "Work Items";
  alertsTitle: string = "Alerts";

  constructor(private userSettingsService: UserSettingsService) {
   }

   ngOnInit() {
    this.userSettingsService.subscribeSettings(message => {
      // NoLog || console.log(this.ClassName + "receive message: " + message)
      let newSettings = this.userSettingsService.settings;
      NoLog || console.log(this.ClassName + "SCAO ", newSettings);
      this.changeLocation(newSettings);
    })
  }

  ngOnDestroy() {
    // TODO - unsubscribe to ensure no memory leaks
    // this.subscription.unsubscribe();
  }

  private changeLocation(item: UserSettings) {
    this.location = item.location;
    this.agency = item.agency;
    NoLog || console.log(this.ClassName + "location:" + this.location);

    this.isCounty = (this.location == "Lincoln County")
  }

}
