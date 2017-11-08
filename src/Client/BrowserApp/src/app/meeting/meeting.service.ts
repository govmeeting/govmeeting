import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/share';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
//import {Headers, RequestOptions} from '@angular/http';

// AppData is configuration which is passed in from index.html.
import { AppData } from '../appdata';

@Injectable()
export class MeetingService {

// The code outlined in main.ts for checking the Name argument need to be used here.
  private _meetingUrl_NoServer = 'assets/BoothbayHarbor_Selectmen_2014-09-08.json';
    //private _meetingUrl = 'assets/data/USA_ME_LincolnCounty_BoothbayHarbor_Selectmen/2014-09-08/Step 5 - processed transcript.json';
    private _meetingUrl = 'api/meeting';
    //private _meetingUrl = 'api/meeting/BoothbayHarbor/Selectmen/2014-09-08';
    //private _meetingUrl = 'api/meeting/USA/ME/LincolnCounty/BoothbayHarbor/Selectmen/2014-09-08';

    // private _meetingData: any = {};
    private data: any;
    private observable: Observable<any>;
    private errorMessage: string;


    constructor(private http: Http, private appData: AppData) {
      console.log('MeetingService - ', appData);
    }

    public getMeeting(): Observable<any> {
      if (this.appData.isServerRunning) {
        return this.getData(this._meetingUrl);
      } else {
        return this.getData(this._meetingUrl_NoServer);
      }
    }

    public postMeeting(): Observable<any> {
        console.log('postMeeting in meeting.service');
        return this.postData(this._meetingUrl, 'my meeting data');
    }

    private getData(url: string): Observable<any> {
        // if `data` is available just return it as `Observable`
        if (this.data) {
            return Observable.of(this.data);

        // else if `this.observable` is set then the request is in progress
        // return the `Observable` for the ongoing request
        } else if (this.observable) {
            return this.observable;

        // else create the request, store the `Observable` for subsequent subscribers
        } else {
            this.observable = this.http.get(url)
                .map((res: any) => res.json())
                .do((val: any) => {
                    this.data = val;
                    // when the cached data is available we don't need the `Observable` reference anymore
                    this.observable = null;
                })
                // make it shared so more than one subscriber can get the result
                .share();
            return this.observable;
        }
    }

    private postData(url: string, data: any): Observable<any> {
    //private postData (url: string, data: any) {
    let body = JSON.stringify(data);
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    // This is the code from https://angular.io/docs/ts/latest/guide/server-communication.html
    //return this.http.post(url, body, options)
    //                .map(this.extractData)
    //                .catch(this.handleError);

    // This is what I wrote -- not tested.
    //return this.http.post(url, body, options)
    //    .map((res: any) => res.json());

    // From "asp.net core and angular2 - Part2"

    console.log('postData in meeting.service');
    return this.http.post(url, body, options);
        //.map(res => console.info(res))
        //.catch(this.handleError);


  }

/*
    getMeetingFromFile(): Observable<{}[]> {
        return this.http.get(this._meetingUrl)
        .map(this.extractData)
        .catch(this.handleError);
    }
*/
/*
    private extractData(res: Response) {
        if (res.status < 200 || res.status >= 300) {
        throw new Error('Bad response status: ' + res.status);
        }
        let body = res.json();
        return body.data || { };
    }
*/

    private handleError (error: any) {
        // In a real world app, we might send the error to remote logging infrastructure
        let errMsg = error.message || 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

}

