import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
// import { Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, share } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';
import { ViewTranscript } from '../../models/viewtranscript-view';
import { ViewTranscriptSample } from '../../models/sample-data/viewtranscript-sample';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';
import { ViewTranscriptService } from './viewtranscript.service';

const NoLog = true; // set to false for console logging

@Injectable()
export class ViewTranscriptServiceReal implements ViewTranscriptService {
  private ClassName: string = this.constructor.name + ': ';
  private meetingUrl = 'api/viewtranscript';
  private observable: Observable<ViewTranscript>;
  // private requestInProgress = false;
  // private requestComplete = false;
  private errorMessage: string;
  viewMeeting: ViewTranscript = ViewTranscriptSample;

  constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
    NoLog || console.log(this.ClassName + 'constructor');
  }

  getMeeting(meetingId: number): Observable<ViewTranscript> {
    if (this.observable != null) {
      return this.observable;
    }
    if (meetingId == null) {
      return this.observable;
    }
    let url: string = this.meetingUrl;
    url = url + '/' + meetingId;
    // this.observable = this.http.get<ViewTranscript>(url).pipe(catchError(this.errHandling.handleError)).share();
    this.observable = this.http.get<ViewTranscript>(url).pipe(catchError(this.errHandling.handleError), share());

    // observable is shared so more than one subscriber can get the same result.
    return this.observable;
  }
}
