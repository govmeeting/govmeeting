import { Component, OnInit, OnDestroy, Input} from '@angular/core';
import {Router} from '@angular/router';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';

const NoLog = false;  // set to false for console logging

@Component({
  selector: 'gm-dash-main',
  templateUrl: './dash-main.html',
  styleUrls: ['./dash-main.scss']
})
export class DashMainComponent implements OnInit, OnDestroy {
  private ClassName: string = this.constructor.name + ": ";
  subscription: Subscription;
  defaultLocation: string = "Boothbay Harbor";
  location: string = this.defaultLocation;
  agency: string;
  isCounty: boolean;

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

  constructor(public router: Router, private userSettingsService: UserSettingsService) {
    this.subscription = this.userSettingsService.getSettings().subscribe(settings => {
      NoLog || console.log(this.ClassName + "receive settings=", settings);
      this.changeLocation(settings);
    })
   }

   ngOnInit() {

    NoLog || console.log(this.ClassName + "ngOnInit send location message")
    let userSettings: UserSettings = new UserSettings('en', "Boothbay Harbor", LocationType.municipal, null);
    this.changeLocation(userSettings);
    this.userSettingsService.sendSettings(userSettings)
    }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  private changeLocation(item: UserSettings) {
    this.location = item.location;
    this.agency = item.agency;
    NoLog || console.log(this.ClassName + "location:" + this.location);

    this.isCounty = (this.location == "Lincoln County")
  }

}
