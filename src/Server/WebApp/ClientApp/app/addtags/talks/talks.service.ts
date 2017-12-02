import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Talk } from './talk';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Addtags } from '../addtags';

// AppData is configuration which is passed in from index.html.
import { AppData } from '../../appdata';

@Injectable()
export class TalksService {

    // Todo-g - change to use this query string.
    //private getUrl = 'api/addtags/USA/PA/Philadelphia/Philadelphia/CityCouncil/2014-09-25';

    private getUrl : string = 'api/addtags';
    private putUrl : string = 'api/addtags';

    private _Url_NoServer : string = 'assets/Philadelphia_CityCouncil_2014-09-25.json';

    private testData: Addtags = {
        data: [
            { speaker: 'Joe', said: 'Waz up', section: 'Invocation', topic: null, showSetTopic: false },
            { speaker: 'Mary', said: 'nutten', section: null, topic: null, showSetTopic: false },
            { speaker: 'Jo', said: 'haiyall', section: null, topic: null, showSetTopic: false },
            { speaker: 'Joe', said: '1111', section: 'Reports', topic: null, showSetTopic: false },
            { speaker: 'Mary', said: '1111111', section: null, topic: 'Topic1', showSetTopic: false },
            { speaker: 'Jo', said: '11111111', section: null, topic: null, showSetTopic: false },
            { speaker: 'Jose', said: '22', section: null, topic: null, showSetTopic: false },
            { speaker: 'Mary', said: '2222', section: null, topic: null, showSetTopic: false },
            { speaker: 'Jo', said: '2222222', section: null, topic: null, showSetTopic: false },
            { speaker: 'Joe', said: '33', section: 'Public Comment', topic: null, showSetTopic: false },
            { speaker: 'Mary', said: '33333', section: null, topic: 'Topic2', showSetTopic: false },
            { speaker: 'Jo', said: '33333333', section: null, topic: null, showSetTopic: false }
        ]
    };

    //private appData: AppData = {isServerRunning: false, isDataFromMemory: false};

    constructor(private http: Http, private appData: AppData) {
        console.log('TalksService - ', appData);
    }
    //constructor(private http: Http) {

    //}

    // The property "IsServerRunning" on AppData tells us if the ASP.NET
    // server is running. If so we will call the API to get the data.
    // Otherwise, we will get the data via a file read from our assets folder.
    // If "isDataFromMemory" is set, we will uese in-memory data.

    getTalks(): Observable<Addtags> {
        // if data from memory, just return data as an `Observable`
        if (this.appData.isDataFromMemory) {
            console.log('getTalksFromMemory');
            return Observable.of(this.testData);
        } else if (this.appData.isServerRunning) {
            return this.http.get(this.getUrl)
            .map(this.extractData)
            .catch(this.handleError);
        } else {
            return this.http.get(this._Url_NoServer)
            .map(this.extractData)
            .catch(this.handleError);
        }
    }

    //postChanges(): Observable<any> {
    //    console.log('postChanges in talks.service');
    //    //return this.postData(this._talksUrl, 'my addtags data');
    //    return this.postData(this._talksUrl, this.getTalksFromMemory());
    //}

    postChanges(addtags: Addtags): Observable<any> {
        if (this.appData.isDataFromMemory) {
            return Observable.of(this.testData);
        }
        console.log('postChanges in talks.service');
        return this.postData(this.putUrl, addtags);
    }

    // The way that HTTP Post works in Asp.Net Core has changed from prior Asp.Net.
    // Some good sources of information are:
    //    http://andrewlock.net/model‐binding‐json‐posts‐in‐asp‐net‐core/
    //    https://docs.asp.net/en/latest/mvc/models/model-binding.html
    //    https://lbadri.wordpress.com/2014/11/23/web-api-model-binding-in-asp-net-mvc-6-asp-net-5/

    // The following will post string data to an Asp.Net MVC 6 controller
    // On the server side, you must do the followiing.
    // In startup.cs, add this to ConfigureServices:
    //     services.AddMvc().AddXmlSerializerFormatters();
    // In the controller, define the action method as:
    //     [HttpPost]
    //     public void Post([FromForm]string value) { ... }
    public postStringData(url: string, data: string): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        // console.log('postStringData in talks.service');
        return this.http.post(url, 'value=' + data, options)
        .map(res => console.info(res))
        .catch(this.handleError);
    }

    // The following will post JSON data (Addtags instance) to an Asp.Net MVC 6 controller
    // On the server side, you must do the following.
    // In startup.cs, add this to ConfigureServices:
    //     services.AddMvc().AddXmlSerializerFormatters();
    // In the controller, define the action method as:
    //     [HttpPost]
    //     public void Post([FromBody]Addtags value) { ... }
    postData(url: string, data: any): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log('postData in talks.service');
        //return this.http.post(url, data, headers)
        return this.http.post(url, data, options)
        .map(res => console.info(res))
        .catch(this.handleError);
    }

    private extractData(res: Response) {
        if (res.status < 200 || res.status >= 300) {
        throw new Error('Bad response status: ' + res.status);
        }
        let body = res.json();
        //return body.data || { };
        return body || { };
    }

    private handleError (error: any) {
        // In a real world app, we might send the error to remote logging infrastructure
        let errMsg = error.message || 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}

