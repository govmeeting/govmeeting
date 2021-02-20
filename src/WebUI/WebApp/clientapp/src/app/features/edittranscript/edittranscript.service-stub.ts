import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EditTranscript, Talk, Word } from '../../models/edittranscript-view';
import { EditTranscriptSample } from '../../models/sample-data/edittranscript-sample';
import { ErrorHandlingService } from '../../common/error-handling/error-handling.service';
import { AppData } from '../../appdata';

//import { EditMeetingClient } from '../../apis/api.generated.clients';

const UseImportData = false; // If true, get data from sample in EditTranscriptSample.ts, else from assets folder
const urlTest = 'assets/stubdata/ToEdit.json';
const urlTestLarge = 'assets/stubdata/LARGE/USA_NJ_Passaic_LittleFalls_TownshipCouncil_en_2020-06-20.json';
const addtagsUrl = 'https://jsonplaceholder.typicode.com/posts'; // Use  jsonplaceholder service to test post requests

const NoLog = true; // set to false for console logging

@Injectable()
export class EdittranscriptServiceStub {
  private ClassName: string = this.constructor.name + ': ';
  postId;
  observable: Observable<EditTranscript>;
  isLargeEditData: boolean;
  url: string;

  public constructor(
    private appData: AppData,
    private http: HttpClient,
    private errHandling: ErrorHandlingService
  //  private editTranscript: EditMeetingClient
  ) {
    NoLog || console.log(this.ClassName + 'constructor');
    this.isLargeEditData = appData.isLargeEditData;
  }

  public getTalks(): Observable<EditTranscript> {
    if (UseImportData) {
      NoLog || console.log(this.ClassName + 'get from memory');
      return of(EditTranscriptSample);
    }
    NoLog || console.log(this.ClassName + 'get from file');
    this.url = this.isLargeEditData ? urlTestLarge : urlTest;
    // TODO - handle null return. Here we just cast to the correct object type.
    this.observable = this.http
      .get<EditTranscript>(this.url)
      .pipe(catchError(this.errHandling.handleError))
      .share() as Observable<EditTranscript>; // make it shared so more than one subscriber can get the same result.
    return this.observable;
  }

  public postChanges(addtags: EditTranscript) {
    NoLog || console.log(this.ClassName + 'postChanges');
    const headers = { 'Content-Type': 'application/json' };
    this.http
      .post<any>(addtagsUrl, addtags, { headers })
      .subscribe({
        next: (data) => {
          this.postId = data.id;
          NoLog || console.log(this.ClassName + data);
        },
        error: (error) => console.error('There was an error!', error),
      });
  }
}
