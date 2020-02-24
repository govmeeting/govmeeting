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
    this.userSettingsService.getBSubject().subscribe(settings => {
      NoLog || console.log(this.ClassName + this.title, settings);
      NoLog || console.log(this.ClassName +  "disable muni/cty:", this.disableMunicipal, this.disableCounty);
      this.customizeHeader(settings);
      NoLog || console.log(this.ClassName +  "enabled: ", this.enabled)
    })

  }

  customizeHeader(settings: UserSettings) {
    this.enabled = true;

    switch (settings.locationType) {
      case LocationType.municipal: {
        if (this.disableMunicipal) {
        this.enabled = false;
        }
        break;
      }
      case LocationType.county: {
        if (this.disableCounty) {
        this.enabled = false;
        }
        break;
      }
      case LocationType.state:{
        if (this.disableState) {
          this.enabled = false;
        }
        break;
      }
      case LocationType.federal:{
        if (this.disableFederal) {
          this.enabled = false;
        }
        break;
      }
      case LocationType.nongovernment: {
        if (this.disableFederal) {
          this.enabled = false;
        }
        break;
      }
    }
  }
}
