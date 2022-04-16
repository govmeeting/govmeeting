import { Injectable } from '@angular/core';
@Injectable({ providedIn: 'root' })
export class AppData {
  public isBeta: boolean = false;
  public useLargeData: boolean = false;
  // public isDataFromMemory: boolean;
}
