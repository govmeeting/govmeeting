import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
// import { Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/share';
import { catchError } from 'rxjs/operators';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';

import { Addtags, Talk } from '../../models/addtags-view';

const NoLog = true; // set to false for console logging

@Injectable()
export class AddtagsService {
  private ClassName: string = this.constructor.name + ': ';

  private addtagsUrl = 'api/addtags';
  private postId;

  private addtags: Addtags;
  private observable: Observable<Addtags>;

  // Normally the meetingId will be passed to the getTalks method.
  // But we did not yet write the component for the user to select a meeting.
  // We will use id "2" for now. This maps to a meeting of Philadelphia on the server.
  private meetingId = 2;

  constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
    NoLog || console.log(this.ClassName + 'constructor');
  }

  getTalks(): Observable<Addtags> {
    if (this.observable != null) {
      return this.observable;
    }
    // See notes above for "meetingId".
    let url: string = this.addtagsUrl;
    url = url + '/' + this.meetingId;
    // TODO - handle null return. Here we just cast to the correct object type.
    this.observable = this.http
      .get<Addtags>(url)
      .pipe(catchError(this.errHandling.handleError))
      .share() as Observable<Addtags>; // make it shared so more than one subscriber can get the same result.
    return this.observable;
  }

  // postChanges(addtags: Addtags) {
  //   // postChanges(addtags: Addtags): Observable<any> {
  //     NoLog || console.log(this.ClassName + 'postChanges');
  //     // return Observable.of(this.addtags);
  //     // return this.postData(this.addtagsUrl, addtags);
  //     this.postData(this.addtagsUrl, addtags);
  // }

  public postChanges(addtags: Addtags) {
    NoLog || console.log(this.ClassName + 'postChanges');
    const url = this.addtagsUrl + '/' + this.meetingId;

    const headers = { 'Content-Type': 'application/json' };
    this.http
      .post<any>(url, addtags, { headers })
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

// private postData(url: string, addtags: Addtags): Observable<Addtags> {
// const httpOptions = {
//     headers: new HttpHeaders({
//         'Content-Type': 'application/json',
//     })
// };
// NoLog || console.log(this.ClassName + 'postData');
// // TODO - handle null return. Here we just cast to the correct object type.
// return <Observable<Addtags>> this.http.post<Addtags>(url, addtags, httpOptions)
//     .pipe(catchError(this.errHandling.handleError));
// }

// postData(url: string, addtags: Addtags) {
//   const headers = new HttpHeaders()
//       .set("Content-Type", "application/json");

//   this.http.put(

//     url, addtags, {headers}

//     // "/courses/-KgVwECOnlc-LHb_B0cQ.json",
//     //   {
//     //       "courseListIcon": ".../main-page-logo-small-hat.png",
//     //       "description": "Angular Tutorial For Beginners TEST",
//     //       "iconUrl": ".../angular2-for-beginners.jpg",
//     //       "longDescription": "...",
//     //       "url": "new-value-for-url"
//     //   },
//     //   {headers}

//       )
//       .subscribe(
//           val => {
//               NoLog || console.log(this.ClassName + "PUT call successful value returned in body",
//                           val);
//           },
//           response => {
//               NoLog || console.log(this.ClassName + "PUT call in error", response);
//           },
//           () => {
//               NoLog || console.log(this.ClassName + "The PUT observable is now completed.");
//           }
//       );
//   }

// TODO - This needs to call the WebApi for the data.
// getSections(): Observable<string[]> {
//    return Observable.of(this.sections);
// }

// TODO - This needs to call the WebApi for the data.
// getTopics(): Observable<string[]> {
//    return Observable.of(this.topics);
// }

// private topics: string[] = [
//      "",
//      "Pavxe 4th St.",
//      "Hire business manager",
//      "Parking ordinaces",
//      "Ice skating rink"
//  ];

// private sections: string[] = [
//    'Approval of Journal',
//    'Leaves of Absense',
//    'Presentations',
//    'Communications',
//    'Introductions of Bills',
//    'Reports',
//    'Bills on Second Reading',
//    'Public Comment',
//    'Second Reading',
//    'Speeches',
//    'Adjournment'
// ];

// The way that HTTP Post works in Asp.Net Core has changed from prior Asp.Net.
// Some good sources of information are:
//    http://andrewlock.net/model‐binding‐json‐posts‐in‐asp‐net‐core/
//    https://docs.asp.net/en/latest/mvc/models/model-binding.html
//    https://lbadri.wordpress.com/2014/11/23/web-api-model-binding-in-asp-net-mvc-6-asp-net-5/
