// This can be used to fix the compiler error:
//     TS2415: Class 'Subject' incorrectly extends base class 'Observable'
// It is an alternative to using the option:
//     "noStrictGenericChecks": true,
// in tsconfig.json.

// Other solution to this error from https://github.com/videogular/videogular2/issues/609
// Solution 1
//   Downgrade the rxjs to V5.1.0 (This is what videogular now uses.)
//   Downgrade the typescript to V2.3.4
// Solution 2
//    Add this to compilerOptions in tsconfig.json:
//      "skipLibCheck": true


// augmentations.ts
import {Operator} from 'rxjs/Operator';
import {Observable} from 'rxjs/Observable';

// TODO: Remove this when a stable release of RxJS without the bug is available.
declare module 'rxjs/Subject' {
  interface Subject<T> {
    lift<R>(operator: Operator<T, R>): Observable<R>;
  }
}
