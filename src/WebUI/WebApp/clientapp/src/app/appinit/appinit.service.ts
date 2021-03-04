import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

let server = "http://no-such-web-server.org";
//
// let server = "https://api.stackexchange.com/2.2/search?order=desc&sort=activity&intitle=perl&site=stackoverflow";

// I remove some static methods here only
@Injectable({ providedIn: "root" })
export class AppInitService {
  constructor(private httpClient: HttpClient) {}

  isRunning: boolean | null = null;

  //async isWebServerRunning() {
  //  logMsg("isWebServerRunning Enter");
  //  const delay = ms => new Promise(res => setTimeout(res, ms));

  //  // check every 50 milliseconds for change in "isRunning" status
  //  while (this.isRunning === null) {
  //    logMsg("isWebServerRunning in delay loop");
  //    await delay(50);
  //  }
  //  let isrunning = this.isRunning;
  //  logMsg("isWebServerRunning Exit -isRunnning = " + String(isrunning));
  //  return isrunning;
  //}

  pingServer(): Promise<any> {
    logMsg("pingServer. Enter");

    const promise = this.httpClient
      .get(server)
      .toPromise()
      .then(settings => {
        logMsg("pingServer Got server response");
        this.isRunning = true;
        return true;
      })
      .catch(err => {
        logMsg("pingServer No server Response");
        this.isRunning = false;
        err;
      });
    return promise;
  }
}

function logMsg(msg: string) {
  console.log("AppInitService:", msg, getNow());
}

function getNow() {
  let now = Date.now();
  let sec = Math.floor(now / 1000) % 100;
  let ms = now % 1000;
  return sec.toString() + ":" + ms.toString();
}
