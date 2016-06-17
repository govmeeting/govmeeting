import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';
import {Talk} from './talk.ts';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/catch';

@Injectable()
export class TalksService {
    //private _talksUrl = 'assets/talks.json'; // URL to web api
    private _talksUrl = 'assets/Philadelphia_CityCouncil_09-25-2014.json';

    constructor (private http: Http) {}

    getTalks() : Talk[] {
        return [
            {speaker: 'Joe', said: 'Waz up', section: 'Invocation', topic: null, showSetTopic: false},
            {speaker: 'Mary', said: 'nutten', section: null, topic: null, showSetTopic: false},
            {speaker: 'Jo', said: 'haiyall', section: null, topic: null, showSetTopic: false},
            {speaker: 'Joe', said: '1111', section: 'Reports', topic: null, showSetTopic: false},
            {speaker: 'Mary', said: '1111111', section: null, topic: 'Topic1', showSetTopic: false},
            {speaker: 'Jo', said: '11111111', section: null, topic: null, showSetTopic: false},
            {speaker: 'Jose', said: '22', section: null, topic: null, showSetTopic: false},
            {speaker: 'Mary', said: '2222', section: null, topic: null, showSetTopic: false},
            {speaker: 'Jo', said: '2222222', section: null, topic: null, showSetTopic: false},
            {speaker: 'Joe', said: '33', section: 'Public Comment', topic: null, showSetTopic: false},
            {speaker: 'Mary', said: '33333', section: null, topic: 'Topic2', showSetTopic: false},
            {speaker: 'Jo', said: '33333333', section: null, topic: null, showSetTopic: false}
            ];
    }

    getTalksFromFile(): Observable<Talk[]> {
        return this.http.get(this._talksUrl)
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

