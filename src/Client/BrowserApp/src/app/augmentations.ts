// This can be used to fix the compiler error:
//     TS2415: Class 'Subject' incorrectly extends base class 'Observable'
// It is an alternative to using the option:
//     "noStrictGenericChecks": true,
// in tsconfig.json.

// augmentations.ts
import {Operator} from 'rxjs/Operator';
import {Observable} from 'rxjs/Observable';

// TODO: Remove this when a stable release of RxJS without the bug is available.
declare module 'rxjs/Subject' {
  interface Subject<T> {
    lift<R>(operator: Operator<T, R>): Observable<R>;
  }
}
