import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../../../user-settings.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-large-card',
  templateUrl: './large-card.html',
  styleUrls: ['./large-card.scss']
})
export class LargeCardComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";

  @Input() title: string;
  @Input() icon: string;
  @Input() iconcolor: string;
  @Input() tooltip: string;
  userSettingsService: UserSettingsService;
  subscription: Subscription;
  // enabled: boolean = true;


  constructor(private _userSettingsService: UserSettingsService) {
    this.userSettingsService = _userSettingsService;
   }

  ngOnInit() {
    this.userSettingsService.SettingsChangeAsObservable().subscribe(message => {
      // NoLog || console.log(this.ClassName + "receive message: " + message)
      // let newSettings = this.userSettingsService.settings;
      // NoLog || console.log(this.ClassName + "SCAO " + this.title, newSettings);
      // this.customizeHeader(newSettings);
    })
  }
}
