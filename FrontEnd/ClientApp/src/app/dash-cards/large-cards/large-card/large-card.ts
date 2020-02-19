import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../../../user-settings.service';

const NoLog = false;  // set to false for console logging

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
  @Input() disableMunicipal: boolean = false;
  @Input() disableCounty: boolean = false;
  @Input() disableState: boolean = false;
  @Input() disableFederal: boolean = false;
  @Input() disableNonGovernment: boolean = false;
  userSettingsService: UserSettingsService;
  subscription: Subscription;
  enabled: boolean = true;


  constructor(private _userSettingsService: UserSettingsService) {
    this.userSettingsService = _userSettingsService;
   }

  ngOnInit() {
    this.subscription = this.userSettingsService.getSettings().subscribe(settings => {
      //NoLog || console.log(this.ClassName + "receive settings=", settings);
      NoLog || console.log(this.ClassName + "settings:inputs:"+this.title+":"+this.disableMunicipal);
      this.customizeHeader(settings);
    })
  }

  customizeHeader(settings: UserSettings) {
    switch (settings.locationType) {
      case LocationType.municipal:{
        if (this.disableMunicipal) this.enabled = false; break;
      }
      case LocationType.state:{
        if (this.disableState) this.enabled = false; break;
      }
      case LocationType.federal:{
        if (this.disableFederal) this.enabled = false; break;
      }
      case LocationType.nongovernment: {
        if (this.disableFederal) this.enabled = false; break;
      }
      default: {
        this.enabled = true;
      }
    }
  }
}
