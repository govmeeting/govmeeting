import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { ViewTranscript } from '../../models/viewtranscript-view';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';
import { ViewTranscriptSample } from '../../models/sample-data/viewtranscript-sample';
import { ViewTranscriptService } from './viewtranscript.service';

const fromFile = true;
const url = 'assets/stubdata/ToView.json';
// Use the jsonplaceholder service to test post requests
const viewtranscriptUrl = 'https://jsonplaceholder.typicode.com/posts';
const NoLog = true; // set to false for console logging

@Injectable()
export class ViewTranscriptServiceStub implements ViewTranscriptService {
  private ClassName: string = this.constructor.name + ': ';
  viewMeeting: ViewTranscript = ViewTranscriptSample;
  private observable: Observable<ViewTranscript>;
  // Use the jsonplaceholder service to test post requests
  private postId;

  constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
    NoLog || console.log(this.ClassName + 'constructor');
  }

  public getMeeting(meetingId: number): Observable<ViewTranscript> {
    if (this.observable != null) {
      NoLog || console.log(this.ClassName + 'getMeeting observable not null');
      return this.observable;
    }
    if (meetingId == null) {
      NoLog || console.log(this.ClassName + 'getMeeting meetingId null');
      return this.observable;
    }
    if (this.http == null) {
      NoLog || console.log(this.ClassName + 'getMeeting http null');
      this.observable = Observable.of(this.viewMeeting);
      return this.observable;
    }
    // else get data from file.
    else {
      NoLog || console.log(this.ClassName + 'getMeeting getMeetingFromFile');
      return this.getMeetingFromFile();
    }
  }

  public getMeetingFromFile(): Observable<ViewTranscript> {
    if (fromFile) {
      NoLog || console.log(this.ClassName + 'get from file');
      // TODO - handle null return. Here we just cast to the correct object type.
      this.observable = this.http
        .get<ViewTranscript>(url)
        .pipe(catchError(this.errHandling.handleError))
        .share() as Observable<ViewTranscript>; // make it shared so more than one subscriber can get the same result.
      return this.observable;
    } else {
      NoLog || console.log(this.ClassName + 'get from memory');
      return Observable.of(this.viewMeeting);
    }
  }

  public postChanges(viewtranscript: ViewTranscript) {
    NoLog || console.log(this.ClassName + 'postChanges');
    const headers = { 'Content-Type': 'application/json' };
    this.http
      .post<any>(viewtranscriptUrl, viewtranscript, { headers })
      .subscribe({
        next: (data) => {
          this.postId = data.id;
          NoLog || console.log(this.ClassName, data);
        },
        error: (error) => console.error('There was an error!', error),
      });
  }
}
