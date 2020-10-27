import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
// import { Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';
import { ViewTranscript } from '../../models/viewtranscript-view';
import { ViewTranscriptSample } from '../../models/sample-data/viewtranscript-sample';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';

const NoLog = true; // set to false for console logging

@Injectable()
export class ViewTranscriptService {
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
    this.observable = this.http.get<ViewTranscript>(url).pipe(catchError(this.errHandling.handleError)).share(); // make it shared so more than one subscriber can get the same result.
    return this.observable;
  }
}

//// This method is copied from https://angular.io/guide/http
// private handleError(error: HttpErrorResponse) {
//    if (error.error instanceof ErrorEvent) {
//        // A client-side or network error occurred. Handle it accordingly.
//        console.error('An error occurred:', error.error.message);
//    } else {
//        // The backend returned an unsuccessful response code.
//        // The response body may contain clues as to what went wrong,
//        console.error(
//            `Backend returned code ${error.status}, ` +
//            `body was: ${error.error}`);
//    }
//    // return an ErrorObservable with a user-facing error message
//    return new ErrorObservable(
//        'Something bad happened; please try again later.');
// };
