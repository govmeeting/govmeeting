import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserSettings, LocationType } from '../models/user-settings';

export { UserSettings, LocationType };

@Injectable({ providedIn: 'root' })
export class UserSettingsService {

  private _settings: UserSettings = new UserSettings('en', "Boothbay Harbor",  null);
  private settingsChange = new BehaviorSubject<string>("Initial");
  public get settings(): UserSettings {
    let copy = Object.assign({}, this._settings);
    return copy;
  }
  public set settings(value: UserSettings) {
    this._settings = Object.assign({}, value);
    this.sendSettingsChange();
  }
  // subscribe to changes in settings
  public subscribeSettings(func: any) {
    this.settingsChange.subscribe(func);
  }
  private sendSettingsChange(){
    this.settingsChange.next("SettingsChange");
  }

  private _language = "en";
  public bLanguage = new BehaviorSubject<string>(this.language);
  public get language(): string {
    return this._language;
  }
  public set language(value: string) {
    this._language = value;
    this.bLanguage.next(this.language);
    this._settings.language = value;
    this.sendSettingsChange();
  }
  // subscribe to changes in language
  public subscribeLanguage(func: any){
    this.bLanguage.subscribe(func);
  }

}
