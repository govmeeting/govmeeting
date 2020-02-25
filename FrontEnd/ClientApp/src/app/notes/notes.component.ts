import { Component, OnInit, OnDestroy, Input} from '@angular/core';
import {Router} from '@angular/router';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';

@Component({
  selector: 'gm-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  subscription: Subscription;
  location: string = "Lincoln County";
  userSettingsService: UserSettingsService;

  constructor(private _userSettingsService: UserSettingsService) {
    this.userSettingsService = _userSettingsService;
   }

  ngOnInit() {
    this.userSettingsService.SettingsChangeAsObservable().subscribe(message => {
      console.log("notes: mesage=" + message);
      this.location = this.userSettingsService.settings.location;
    })

  }

  private changeLocation(item: UserSettings) {
    this.location = item.location;

    // this.isCounty = (this.location == "Lincoln County")
  }

}
