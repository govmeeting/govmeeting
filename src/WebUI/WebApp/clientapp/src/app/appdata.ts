import { Injectable } from '@angular/core';
@Injectable({ providedIn: "root" })
export class AppData {
  public isAspServerRunning: boolean;
  public isBeta: boolean;
  public isLargeEditData: boolean;
  // public isDataFromMemory: boolean;
}
