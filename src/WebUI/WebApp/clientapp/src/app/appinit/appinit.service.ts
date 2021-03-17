import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { replaySubjectLog } from '../logger-service';

const server = 'https://localhost:44333/api/HealthCheck/Get';
// let server = "http://no-such-web-server.org";
// let server = "https://api.stackexchange.com/2.2/search?order=desc&sort=activity&intitle=perl&site=stackoverflow";

interface HealthCheck {
  status: string;
}

@Injectable({ providedIn: 'root' })
export class AppInitService {
  constructor(private httpClient: HttpClient) {}

  isRunning: boolean | null = null;
  pingNumber = 2;

  pingServer(): Promise<any> {
    logMsg('pingServer. Enter');

    const promise = this.httpClient
      .get(server)
      .toPromise()
      .then((healthy: HealthCheck) => {
        if (healthy.status !== 'healthy') {
          throw new Error('Server not healthy.');
        }
        logMsg('pingServer Got server response');
        this.isRunning = true;
        return true;
      })
      .catch((err) => {
        console.log(err);
        logMsg('pingServer No server Response');
        this.isRunning = false;
        // this.startAnotherPing();
        err;
      });
    return promise;
  }

  startAnotherPing() {
    logMsg('pingServer' + this.pingNumber++ + '. Enter');
    const promise = this.httpClient
      .get(server)
      .toPromise()
      .then((settings) => {
        logMsg('pingServer' + this.pingNumber + ' Got server response');
        return true;
      })
      .catch((err) => {
        logMsg('pingServer' + this.pingNumber + ' No server Response');
        // this.startAnotherPing();
        err;
      });
  }
}

function logMsg(msg: string) {
  // console.log("AppInitService:", msg, getNow());
  const fullmsg = 'AppInitService:' + msg + ' ' + getNow();
  console.log(fullmsg);
  replaySubjectLog.next(fullmsg);
}

function getNow() {
  const now = Date.now();
  const sec = Math.floor(now / 1000) % 100;
  const ms = now % 1000;
  return sec.toString() + ':' + ms.toString();
}
