import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { NavService } from '../sidenav/nav.service';
import { UserSettingsService, UserSettings } from '../common/user-settings.service';
import { getBackgroundUrl } from './background.service-stub';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-header',
  templateUrl: './header.html',
  styleUrls: ['./header.scss'],
})
export class HeaderComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  messages: any[] = [];
  usSubscription: Subscription;
  location: string;
  backgroundStyle: any;

  constructor(private navService: NavService, private userSettingsService: UserSettingsService) {}

  ngOnInit() {
    this.userSettingsService.subscribeSettings((message) => {
      const newSettings = this.userSettingsService.settings;
      NoLog || console.log(this.ClassName + 'SCAO ', newSettings);
      this.changeLocation(newSettings);
    });
    this.changeBackground('generic');
  }

  openNav() {
    this.navService.openNav();
  }

  private changeLocation(item: UserSettings) {
    this.location = item.location;
    NoLog || console.log(this.ClassName + 'location:' + this.location);
    this.changeBackground(this.location);
  }

  private changeBackground(location: string) {
    const background = getBackgroundUrl(location);
    this.backgroundStyle = { 'background-image': background };
  }
}
