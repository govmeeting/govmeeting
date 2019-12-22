import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
//import { Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';
import { ViewMeeting } from '../models/viewmeeting-view';

import { ErrorHandlingService } from '../shared/error-handling/error-handling.service';

@Injectable()
export class ViewMeetingService {
    private meetingUrl = 'api/viewmeeting';
    private observable: Observable<ViewMeeting>;
    // private requestInProgress = false;
    // private requestComplete = false;
    private errorMessage: string;

    // Normally the meetingId will be passed to the getMeeting method.
    // But we did not yet write the component for the user to select a meeting.
    // We will use id "1" for now. This maps to a meeting of BBH on the server.
    // On the server, we will get information about this meeting from the database via the meetingId.
    // For development, this means calling a routine in DatabaseRepsitories_Lib/MeetingRepository_Stub.cs.
    // If you look at this file, you will see that meetingId "1" maps to a meeting of the
    // Boothbay Harbor Selectmen on 9/8/2014.
    private meetingId = 1;

    constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
      console.log('ViewMeetingService - constructor');
    }

    getMeeting(): Observable<ViewMeeting> {
        if (this.observable != null) {
            return this.observable;
        }
        // See notes above for "meetingId".
        let url: string = this.meetingUrl;
        url = url + '/' + this.meetingId;
         this.observable = this.http.get<ViewMeeting>(url)
            .pipe(catchError(this.errHandling.handleError))
            .share();     // make it shared so more than one subscriber can get the same result.
        return this.observable;
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
}

