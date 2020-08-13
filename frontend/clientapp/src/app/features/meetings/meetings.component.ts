import { Component, OnInit, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../../common/user-settings.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-meetings',
  templateUrl: './meetings.component.html',
  styleUrls: ['./meetings.component.scss'],
})
export class MeetingsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  public location = '';
  public agency = '';
  subscription: Subscription;

  constructor(private userSettingsService: UserSettingsService) {}

  ngOnInit() {
    this.userSettingsService.subscribeSettings((message) => {
      // NoLog || console.log(this.ClassName + "receive message: " + message)
      const newSettings = this.userSettingsService.settings;
      NoLog || console.log(this.ClassName + 'SCAO ', newSettings);
      this.location = newSettings.location;
      this.agency = newSettings.agency;
    });
  }
}
