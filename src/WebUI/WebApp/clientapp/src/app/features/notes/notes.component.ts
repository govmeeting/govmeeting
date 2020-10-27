import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { UserSettingsService, UserSettings, LocationType } from '../../common/user-settings.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss'],
})
export class NotesComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  location = 'Lincoln County';

  constructor(private userSettingsService: UserSettingsService) {}

  ngOnInit() {
    this.userSettingsService.subscribeSettings((message) => {
      NoLog || console.log(this.ClassName + 'message=' + message);
      this.location = this.userSettingsService.settings.location;
    });
  }
}
