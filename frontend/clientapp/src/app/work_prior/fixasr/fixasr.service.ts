import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
// import { Headers, RequestOptions, Response } from '@angular/http';
import { FixasrView, AsrSegment } from '../../models/fixasr-view';
import { Observable } from 'rxjs';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';

const NoLog = true; // set to false for console logging

@Injectable()
export class FixasrService {
  private ClassName: string = this.constructor.name + ': ';
  private fixasrUrl = 'api/fixasr';
  private asrtext: FixasrView;
  private error = { message: 'not defined yet' };

  // Normally the meetingId & part will be passed to the getAsr method.
  // But we did not yet write the component for the user to select a meeting.
  // Meeting "3" is BBH 2/15/2017.
  // Meeting "5" is BBH 1/09/2017..
  private meetingId = 3;
  private part = 1;

  constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
    NoLog || console.log(this.ClassName + 'constructor');
  }

  getAsr(): Observable<FixasrView> {
    // See notes above for meetingId & part.
    let url: string = this.fixasrUrl;
    url = url + '/' + this.meetingId + '/' + this.part;

    NoLog || console.log(this.ClassName + 'get data from ' + url);
    // TODO - handle null return. Here we just cast to the correct object type.
    return this.http.get<FixasrView>(url).pipe(catchError(this.errHandling.handleError)) as Observable<FixasrView>;
  }

  public postChanges(asrtext: FixasrView) {
    NoLog || console.log(this.ClassName + 'postChanges');
    const url = this.fixasrUrl + '/' + this.meetingId + '/' + this.part;
    NoLog || console.log(this.ClassName + 'postChanges  ' + url);
    const headers = { 'Content-Type': 'application/json' };
    this.http
      .post<any>(url, asrtext, { headers })
      .subscribe({
        // next: data => this.postId = data.id,
        next: (success) => {
          NoLog || console.log(this.ClassName, success);
          if (!success) {
            // TODO handle errs here and below - tell user their save did not succeed.
            NoLog || console.log(this.ClassName, 'false was returned from Post');
          }
        },
        error: (error) => console.error('There was an error!', error),
      });
  }
}
