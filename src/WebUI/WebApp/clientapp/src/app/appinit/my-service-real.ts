import { Injectable } from '@angular/core';
import { MyService } from './my-service';
import { HttpClient } from '@angular/common/http';

// must extend MyService which is an abstract class
@Injectable()
export class MyServiceReal extends MyService {
  http: HttpClient;
  constructor(private _http: HttpClient) {
    super();
    this.http = _http;
  }

  printTime(): void {
    const time = this.getNow();
    console.log('MyService:printTime ', time);
  }

  getNow(): string {
    const now = Date.now();
    const sec = Math.floor(now / 1000) % 100;
    const ms = now % 1000;
    return sec.toString() + ':' + ms.toString();
  }
}
