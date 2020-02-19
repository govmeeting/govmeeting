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
  location: string;

  constructor(private userSettingsService: UserSettingsService) {
    this.subscription = this.userSettingsService.getSettings().subscribe(settings => {
      this.changeLocation(settings);
    })
   }

  ngOnInit() {
  }

  private changeLocation(item: UserSettings) {
    this.location = item.location;

    // this.isCounty = (this.location == "Lincoln County")
  }

}
