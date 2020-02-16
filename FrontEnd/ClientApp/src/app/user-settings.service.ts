import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { UserSettings } from './models/user-settings';

export { UserSettings };

@Injectable({ providedIn: 'root' })
export class UserSettingsService {
  private subject = new Subject<any>();
  private settingsSubject = new Subject<UserSettings>();

  clearMessages() {
      this.subject.next();
  }

  sendSettings(settings: UserSettings) {
    this.settingsSubject.next(settings);
  }

  getSettings(): Observable<UserSettings> {
    return this.settingsSubject.asObservable();
  }


}
