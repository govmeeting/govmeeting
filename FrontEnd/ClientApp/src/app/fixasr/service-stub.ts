import { Injectable } from '@angular/core';
import { FixasrText, AsrSegment } from '../models/fixasr-view';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ErrorHandlingService } from '../shared/error-handling/service';

@Injectable()
export class FixasrServiceStub {
    private asrtext: FixasrText = {
        'lastedit': 0,
        'asrsegments':     [
        { startTime: '0:00', said: 'the tuesday october $YEAR 11 selectmen' },
        { startTime: '0:02', said: 'meeting i will apologize apologize for' },
        { startTime: '0:06', said: 'my voice i can hardly speak i woke up' },
        { startTime: '0:08', said: 'Saturday with a terrible cold so if you' },
        { startTime: '0:10', said: 'can\'t hear me just speak up and i\'ll try' },
        { startTime: '0:13', said: 'to speak louder and you may want to stay' },
        { startTime: '0:14', said: 'in the back yeah you guys today in the' },
        { startTime: '0:17', said: 'background is yeah I\'m like have our' },
        { startTime: '0:20', said: 'full board with us tonight and we have' },
        { startTime: '0:24', said: 'our recording secretary Kelly the ghost' },
        { startTime: '0:26', said: 'town manager Tom women and selected' },
        { startTime: '0:30', said: 'Trish Warren wendy wolf myself Denise' }
   ]};

   constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
    console.log('FixasrServiceStub - constructor');
  }

  getAsr(): Observable<FixasrText> {
        // console.log('getAsr from memory');
        // return Observable.of(this.asrtext);
        const url = 'assets/stubdata/ToFix.json';
        // TODO - handle null return. Here we just cast to the correct object type.
        return <Observable<FixasrText>> this.http.get<FixasrText>(url)
            .pipe(catchError(this.errHandling.handleError));
    }

    postChanges(asrtext: FixasrText): Observable<any> {
        console.log('postChanges in fixasr.service stub');
        return Observable.of(this.asrtext);
    }
}

