import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class TopicsService {

    private _topicsUrl = 'assets/topics.json';
    // private _topics: string[] = null;
    // private _topicsTest: string[] = ["topic1", "topic2", "topic3"];
    // private _topics$: Observable<string[]> = null;

    private data: any;
    private observable: Observable<any>;


    constructor (private http: Http) {}

    getTopics(): Observable<any> {
    if(this.data) {
      // if `data` is available just return it as `Observable`
      return Observable.of(this.data);
    } else if(this.observable) {
      // if `this.observable` is set then the request is in progress
      // return the `Observable` for the ongoing request
      return this.observable;
    } else {
      // create the request, store the `Observable` for subsequent subscribers
      this.observable = this.http.get(this._topicsUrl)
          .map(res => res.json())
          .do(val => {
            this.data = val;
            // when the cached data is available we don't need the `Observable` reference anymore
            this.observable = null;
          })
          // make it shared so more than one subscriber can get the result
          .share();
      return this.observable;
    }
}

/*      
    xgetTopics(): Observable<string[]> {
        // if topics are in memory, return them.
        if (this._topics != null) {
            console.log("from mem");
            return this.getTopicsTFromMem();
            
        // otherwise get them from the file.
        } else {
            return this.getTopicsFromFile();
        }
    }

    // return topics from memory. Actually return an observable which will return them.
    getTopicsTFromMem(): Observable<string[]> {
        let topics$ = new Observable(observer => {
            observer.next(this._topics);
        });
        return topics$;
    }

    // return topics from file. Actually return an observable which will return them.
    getTopicsFromFile(): Observable<string[]> {
        
        // If someone already started the http GET, then return existing observable.
        if (this._topics$ != null) {
            console.log("return observable");
            return this._topics$;
        }

        // otherwise start the GET
        console.log("HTTP GET");
        let topics$ = this.http.get(this._topicsUrl)
            .map(this.extractData)
            .catch(this.handleError);
        topics$.subscribe(topics => {this._topics = topics; console.log("fill topics")});
        this._topics$ = topics$;       
        return topics$;              
    }

      getTopicsForTest(): Observable<string[]> {
        let topics$ = new Observable(observer => {
            observer.next(this._topicsTest);
        });
        return topics$;
    }
*/

// The new approach does not handle errors. These are unused. I need to add error handling.
/*
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
*/
}
