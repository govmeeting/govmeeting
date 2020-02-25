import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { UserSettings, LocationType } from './models/user-settings';

export { UserSettings, LocationType };

@Injectable({ providedIn: 'root' })
export class UserSettingsService {
  //private subject = new Subject<any>();
  private settingsSubject = new Subject<UserSettings>();
  // private bSubject = new BehaviorSubject<UserSettings>(new UserSettings());
  private settingsChange = new BehaviorSubject<string>("Initial");

  private _settings: UserSettings;
  public get settings(): UserSettings {
    let copy = Object.assign({}, this._settings);
    return copy;
  }
  public set settings(value: UserSettings) {
    this._settings = Object.assign({}, value);
    this.sendSettingsChange();
  }

  clearMessages() {
      this.settingsSubject.next();
  }

  sendSettings(settings: UserSettings) {
    this.settingsSubject.next(settings);
  }

  getSettings(): Observable<UserSettings> {
    return this.settingsSubject.asObservable();
  }

  // sendBSubject(settings: UserSettings){
  //   this.bSubject.next(settings);
  // }

  // getBSubject() {
  //   return this.bSubject;
  // }

  sendSettingsChange(){
    this.settingsChange.next("SettingsChange");
  }

  SettingsChangeAsObservable() {
    return this.settingsChange.asObservable();
  }



}
