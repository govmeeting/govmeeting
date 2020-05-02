import { Component, OnInit, Input } from '@angular/core';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-bills',
  templateUrl: './bills.component.html',
  styleUrls: ['./bills.component.scss']
})
export class BillsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
  location = '';
  agency = '';
  userSettingsService: UserSettingsService;

    constructor(private _userSettingsService: UserSettingsService) {
      this.userSettingsService = _userSettingsService;
     }

     ngOnInit() {
      this.userSettingsService.SettingsChangeAsObservable().subscribe(message => {
        // NoLog || console.log(this.ClassName + "receive message: " + message)
        let newSettings = this.userSettingsService.settings;
        NoLog || console.log(this.ClassName + "SCAO ", newSettings);
        this.location = newSettings.location;
        this.agency = newSettings.agency;
      })
    }


}
