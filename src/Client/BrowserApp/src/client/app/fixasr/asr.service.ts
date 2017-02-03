import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { AsrSegment } from './asrsegment';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AsrService {

// The code outlined in main.ts for checking the Name argument need to be used here.

    //private _talksFileUrl = 'assets/talks.json'; // URL to web api
    private _asrFileUrl = 'assets/Philadelphia_CityCouncil_2014-09-25.json';
    //private _talksUrl = 'http://localhost:60366/api/addtags';
    private _asrUrl = 'http://localhost:60366/api/addtags/Philadelphia/CityCouncil/2014-09-25';

    constructor (private http: Http) {}

    getAsr(): Observable<AsrSegment[]> {

// The code outlined in main.ts for checking the Name argument need to be used here.
//        return this.http.get(this._talksUrl)

        return this.http.get(this._asrFileUrl)
        .map(this.extractData)
        .catch(this.handleError);
    }

    getAsrFromMemory(): any {
        console.log('getAsrFromMemory');
        return {
            data: [
                { startTime: '0:00', said: 'the tuesday october $YEAR 11 selectmen'},
                { startTime: '0:02', said: 'meeting i will apologize apologize for'},
                { startTime: '0:06', said: 'my voice i can hardly speak i woke up'},
                { startTime: '0:08', said: 'Saturday with a terrible cold so if you'},
                { startTime: '0:10', said: "can't hear me just speak up and i'll try"},
                { startTime: '0:13', said: 'to speak louder and you may want to stay'},
                { startTime: '0:14', said: 'in the back yeah you guys today in the'},
                { startTime: '0:17', said: "background is yeah I'm like have our"},
                { startTime: '0:20', said: 'full board with us tonight and we have'},
                { startTime: '0:24', said: 'our recording secretary Kelly the ghost'},
                { startTime: '0:26', said: 'town manager Tom women and selected'},
                { startTime: '0:30', said: 'Trish Warren wendy wolf myself Denise'}
            ]
        };
    }

    postChanges(): Observable<any> {
        console.log('postChanges in asr.service');
        //return this.postData(this._talksUrl, 'my addtags data');
        return this.postData(this._asrUrl, this.getAsrFromMemory());
    }

    private postData(url: string, data: any): Observable<any> {
        //private postData (url: string, data: any) {
        let body = JSON.stringify(data);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log('postData in talks.service');
        return this.http.post(url, body, options);
        //.map(res => console.info(res))
        //.catch(this.handleError);
    }

    private extractData(res: Response) {
        if (res.status < 200 || res.status >= 300) {
        throw new Error('Bad response status: ' + res.status);
        }
        let body = res.json();
        return body.data || { };
    }

    private handleError (error: any) {
        // In a real world app, we might send the error to remote logging infrastructure
        let errMsg = error.message || 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}

