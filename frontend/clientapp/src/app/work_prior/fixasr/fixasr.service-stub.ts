import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';
import { FixasrView, AsrSegment } from '../../models/fixasr-view';
import { fixasrSample } from '../../models/sample-data/fixasr-sample';

const NoLog = true; // set to false for console logging {}

// Use the jsonplaceholder service to test post requests
const fixasrUrl = 'https://jsonplaceholder.typicode.com/posts';

@Injectable()
export class FixasrServiceStub {
  private ClassName: string = this.constructor.name + ': ';
  private asrtext: FixasrView = fixasrSample;
  private postId;
  private observable: Observable<FixasrView>;

  public constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
    NoLog || console.log(this.ClassName + 'constructor');
  }

  public getAsr(): Observable<FixasrView> {
    // Another way to return the stub data
    // this.observable = Observable.of(fixasrSample);
    // return this.observable;

    NoLog || console.log(this.ClassName + 'getAsr from memory');
    // console.trace('trace: getAsr from memory')
    // return Observable.of(this.asrtext);
    const url = 'assets/stubdata/ToFix.json';
    // TODO - handle null return. Here we just cast to the correct object type.
    return this.http.get<FixasrView>(url).pipe(catchError(this.errHandling.handleError)) as Observable<FixasrView>;
  }

  public postChanges(fixasr: FixasrView) {
    NoLog || console.log(this.ClassName + 'postChanges');
    const headers = { 'Content-Type': 'application/json' };
    this.http
      .post<any>(fixasrUrl, fixasr, { headers })
      .subscribe({
        next: (data) => {
          this.postId = data.id;
          NoLog || console.log(this.ClassName, data);
        },
        error: (error) => console.error('There was an error!', error),
      });
  }

  // postChanges(asrtext: FixasrView): Observable<any> {
  //     NoLog || console.log(this.ClassName + 'postChanges in fixasr.service stub');
  //     return Observable.of(this.asrtext);
  // }
}
