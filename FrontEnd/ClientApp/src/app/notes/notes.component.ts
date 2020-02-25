import { Component, OnInit, OnDestroy, Input} from '@angular/core';
import {Router} from '@angular/router';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
  subscription: Subscription;
  location: string = "Lincoln County";
  userSettingsService: UserSettingsService;

  constructor(private _userSettingsService: UserSettingsService) {
    this.userSettingsService = _userSettingsService;
   }

  ngOnInit() {
    this.userSettingsService.SettingsChangeAsObservable().subscribe(message => {
      NoLog || console.log(this.ClassName + "message=" + message);
      this.location = this.userSettingsService.settings.location;
    })

  }
}
