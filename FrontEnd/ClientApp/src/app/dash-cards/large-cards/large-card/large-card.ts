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
  @Input() enableNonLocal: boolean;
  subscription: Subscription;
  enabled: boolean = true;


  constructor(private userSettingsService: UserSettingsService) {
    this.subscription = this.userSettingsService.getSettings().subscribe(settings => {
      NoLog || console.log(this.ClassName + "receive settings=", settings);
      this.customizeHeader(settings);
    })
   }

  ngOnInit() {
  }

  customizeHeader(settings: UserSettings) {
    if (this.enableNonLocal == false) {
      switch (settings.locationType) {
        case LocationType.state:
        case LocationType.federal:
        case LocationType.nongovernment: {
          this.enabled = false;
          break;
        }
        default: {
          this.enabled = true;
        }
      }
    }
  }
}
