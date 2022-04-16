import { Injectable } from '@angular/core';
@Injectable({ providedIn: 'root' })
export class AppData {
  public isBeta: boolean;
  public useLargeData: boolean;
  // public isDataFromMemory: boolean;
}
