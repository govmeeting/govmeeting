import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { UserSettings, LocationType } from './models/user-settings';

export { UserSettings, LocationType };

@Injectable({ providedIn: 'root' })
export class UserSettingsService {
  private settingsChange = new BehaviorSubject<string>("Initial");

  private _settings: UserSettings;
  public get settings(): UserSettings {
    let copy = Object.assign({}, this._settings);
    return copy;
  }
  public set settings(value: UserSettings) {
    // TODO return private value read-only?
    this._settings = Object.assign({}, value);
    this.sendSettingsChange();
  }

  public setLanguage(language: string){
    let copy = Object.assign({}, this._settings);
    copy.language = language;
    this._settings = Object.assign({}, copy);
    this.sendSettingsChange();
  }

  public SettingsChangeAsObservable() {
    return this.settingsChange.asObservable();
  }

  private sendSettingsChange(){
    this.settingsChange.next("SettingsChange");
  }

  private language = "en";
  public bLanguage = new BehaviorSubject<string>(this.language);

  public changeLanguage(language: string) {
    this.language = language;
    this.bLanguage.next(this.language);
  }

}
