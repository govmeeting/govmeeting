import { Component, OnInit, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-meetings',
  templateUrl: './meetings.component.html',
  styleUrls: ['./meetings.component.scss']
})
export class MeetingsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
  public location = '';
  public agency = '';
  subscription: Subscription;
  userSettingsService: UserSettingsService;

  // @Input()
  //   set location(location: string) {
  //     this._location = location;
  //     NoLog || console.log(this.ClassName + "bills set location=" + location)
  //   }
  //   get location(): string { return this._location; }

  //   @Input()
  //   set agency(agency: string) {
  //     this._agency = agency;
  //     NoLog || console.log(this.ClassName + "bills set agency=" + agency)
  //   }
  //   get agency(): string { return this._agency; }

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
