import { Injectable } from '@angular/core';
import { MyService } from './my-service';
import { replaySubjectLog } from '../logger-service';

// This was used temporarily while debugging appinit\service-manager.module.ts
@Injectable()
export class MyServiceStub extends MyService {
  printTime(): void {
    const time = this.getNow();
    console.log('MyServiceStub:printTime ', time);
    replaySubjectLog.next('MyServiceStub:printTime ' + time);
  }

  getNow(): string {
    const now = Date.now();
    const sec = Math.floor(now / 1000) % 100;
    const ms = now % 1000;
    return sec.toString() + ':' + ms.toString();
  }
}
