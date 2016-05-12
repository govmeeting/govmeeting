import {Injectable} from 'angular2/core';
import {Http, Response} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import {Headers, RequestOptions} from 'angular2/http';

@Injectable()
export class BackendService {
    private _meetingUrl = 'app/testdata/BBH-2014-09-08.json';
    private _topicDiscussionsUrl = 'app/testdata/topicDiscussions.json';
    private _meetingData: any = {};
    
    constructor (private http: Http) {}
    
    getTopicDiscussions() {
        return [
            {name: "topic1", speakers: [{name: "Joe", text: "Hi all."}, {name: "Pat", text: "Hi all."}]},
            {name: "topic2", speakers: [{name: "Pat", text: "Hi Joe."}, {name: "Mac", text: "Hi all."}]},
            {name: "topic3", speakers: [{name: "Mac", text: "Hi Mac."}, {name: "Liz", text: "Hi all."}]},
            {name: "topic4", speakers: [{name: "Liz", text: "Hi Liz."}, {name: "Joe", text: "Hi all."}]},
        ]
    }
       
    getTopicDiscussionsFromFile(): Observable<{}[]> {
        return this.http.get(this._topicDiscussionsUrl)
        .map(this.extractData)
        .catch(this.handleError);
    }
       
    getMeetingFromFile(): Observable<{}[]> {
        return this.http.get(this._meetingUrl)
        .map(this.extractData)
        .catch(this.handleError);
    }
    
    getTopics(): Observable<string[]> {
        return this.http.get('app/topics/topics.json')
        .map(this.extractData)
        .catch(this.handleError);
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

