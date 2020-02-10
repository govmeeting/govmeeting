import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { ViewMeeting } from '../models/viewmeeting-view';
import { ErrorHandlingService } from '../shared/error-handling/error-handling.service';
import { viewmeetingSample } from './viewmeeting-sample';

  const fromFile = true;
  const url = 'assets/stubdata/ToView.json';
  // Use the jsonplaceholder service to test post requests
  const viewmeetingUrl = 'https://jsonplaceholder.typicode.com/posts'
  const NoLog = true;  // set to false for console logging

@Injectable()
export class ViewMeetingServiceStub {
  private ClassName: string = this.constructor.name + ": ";
  viewMeeting: ViewMeeting = viewmeetingSample;

  private observable: Observable<ViewMeeting>;

  // Use the jsonplaceholder service to test post requests
  private postId;

  constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
    NoLog || console.log(this.ClassName + 'constructor');
  }

  public getMeeting(meetingId: number): Observable<ViewMeeting> {
    if (this.observable != null) {
      NoLog || console.log(this.ClassName + "getMeeting observable not null")
      return this.observable;
    }
    if (meetingId == null) {
      NoLog || console.log(this.ClassName + "getMeeting meetingId null")
      return this.observable;
  }
    if (this.http == null) {
      NoLog || console.log(this.ClassName + "getMeeting http null")
      this.observable = Observable.of(this.viewMeeting);
      return this.observable;
    }
    // else get data from file.
    else {
      NoLog || console.log(this.ClassName + "getMeeting getMeetingFromFile")
      return this.getMeetingFromFile();
    }
  }

  public getMeetingFromFile(): Observable<ViewMeeting> {
    if (fromFile) {
      NoLog || console.log(this.ClassName + 'get from file');
      // TODO - handle null return. Here we just cast to the correct object type.
      this.observable = <Observable<ViewMeeting>> this.http.get<ViewMeeting>(url)
          .pipe(catchError(this.errHandling.handleError))
          .share();     // make it shared so more than one subscriber can get the same result.
      return this.observable;
    } else {
      NoLog || console.log(this.ClassName + 'get from memory');
      return Observable.of(this.viewMeeting);
    }
  }

  public postChanges(viewmeeting: ViewMeeting) {
    NoLog || console.log(this.ClassName + 'postChanges');
    const headers = { 'Content-Type': 'application/json' }
      this.http.post<any>(viewmeetingUrl, viewmeeting, { headers }).subscribe({
        next: data => {
          this.postId = data.id;
          NoLog || console.log(this.ClassName, data);
        },
        error: error => console.error('There was an error!', error)
      })
    }

  }

