import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EditTranscript, Talk, Word } from '../../models/edittranscript-view';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';
import { EditTranscriptSample } from './edittranscript-sample';
import { AppData } from '../../appdata';

  const UseHttpForData = true;  // Get data using Http or from the sample in EditTranscriptSample
  const addtagsUrl = 'https://jsonplaceholder.typicode.com/posts'   // Use  jsonplaceholder service to test post requests
  const NoLog = true;  // set to false for console logging

  @Injectable()
export class EdittranscriptServiceStub {
  private ClassName: string = this.constructor.name + ": ";
  postId;
  observable: Observable<EditTranscript>;
  url: string = 'assets/stubdata/ToEditTranscript.json';
  isLargeEditData: boolean;

  public constructor(
    private appData: AppData,
    private http: HttpClient,
    private errHandling: ErrorHandlingService
  ) {
    NoLog || console.log(this.ClassName + 'constructor');
      this.isLargeEditData = appData.isLargeEditData;
  }

  public getTalks(): Observable<EditTranscript> {
    if (UseHttpForData) {
      if (this.isLargeEditData){
        this.url = 'assets/stubdata/LARGE/USA_NJ_Passaic_LittleFalls_TownshipCouncil_en_2020-06-20.json';
      }
      NoLog || console.log(this.ClassName + 'get from file');
      // TODO - handle null return. Here we just cast to the correct object type.
      this.observable = <Observable<EditTranscript>> this.http.get<EditTranscript>(this.url)
          .pipe(catchError(this.errHandling.handleError))
          .share();     // make it shared so more than one subscriber can get the same result.
      return this.observable;
    } else {
      NoLog || console.log(this.ClassName + 'get from memory');
      return of(EditTranscriptSample);
    }
  }

  public postChanges(addtags: EditTranscript) {
    NoLog || console.log(this.ClassName + 'postChanges');
    const headers = { 'Content-Type': 'application/json' }
      this.http.post<any>(addtagsUrl, addtags, { headers }).subscribe({
        next: data => {
          this.postId = data.id;
          NoLog || console.log(this.ClassName + data);
        },
        error: error => console.error('There was an error!', error)
      })
    }

}
