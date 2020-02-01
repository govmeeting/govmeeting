import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { ViewMeeting } from '../models/viewmeeting-view';
import { ErrorHandlingService } from '../shared/error-handling/error-handling.service';
import { viewmeetingSample } from './viewmeeting-sample';


@Injectable()
export class ViewMeetingServiceStub {
  private observable: Observable<ViewMeeting>;

  viewMeeting: ViewMeeting = viewmeetingSample;

    constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
      console.log('ViewMeetingService - stub constructor');
    }


    public getMeeting(meetingId: number): Observable<ViewMeeting> {
      if (this.observable != null) {
          return this.observable;
      }
      if (meetingId == null) {
        return this.observable;
    }
    // If null is passed for http, return static data
      if (this.http == null) {
        this.observable = Observable.of(this.viewMeeting);
        return this.observable;
      }
      // else get data from file.
      else {
        return this.getMeetingFromFile();
      }
    }

    public getMeetingFromFile(): Observable<ViewMeeting> {
      // console.log('getMeeting from memory');
      // return Observable.of(this.viewMeeting);

    const url = 'assets/stubdata/1 tagged.json';
      // TODO - handle null return. Here we just cast to the correct object type.
      this.observable = <Observable<ViewMeeting>> this.http.get<ViewMeeting>(url)
          .pipe(catchError(this.errHandling.handleError))
          .share();     // make it shared so more than one subscriber can get the same result.
      return this.observable;
  }

}

