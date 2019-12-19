import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
//import { Headers, RequestOptions, Response } from '@angular/http';
import { FixasrText, AsrSegment } from '../models/fixasr-view';
import { Observable } from 'rxjs';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';
import { ErrorHandlingService } from '../shared/error-handling/service';

@Injectable()
export class FixasrService {
    private fixasrUrl = 'api/fixasr';
    private asrtext: FixasrText;
    private error = { message: 'not defined yet' };

    // Normally the meetingId & part will be passed to the getAsr method.
    // But we did not yet write the component for the user to select a meeting.
    // Meeting "3" is BBH 2/15/2017.
    // Meeting "5" is BBH 1/09/2017..
    private meetingId = 5;
    private part = 1;

    constructor(private http: HttpClient, private errHandling: ErrorHandlingService) {
        console.log('FixasrService - constructor');
    }

    getAsr(): Observable<FixasrText> {
        // See notes above for meetingId & part.
        let url: string = this.fixasrUrl;
        url = url + '/' + this.meetingId + '/' + this.part;

        console.log('get data from ' + url);
        // TODO - handle null return. Here we just cast to the correct object type.
        return <Observable<FixasrText>> this.http.get<FixasrText>(url)
            .pipe(catchError(this.errHandling.handleError));
    }

    postChanges(asrtext: FixasrText): Observable < any > {
        // See notes above for meetingId & part.
        let url: string = this.fixasrUrl;
        url = url + '/' + this.meetingId + '/' + this.part;

        console.log('postChanges in fixasr.service  ' + url);
        return this.postData(url, asrtext);
    }

    private postData(url: string, asrtext: FixasrText): Observable<FixasrText> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            })
        };
        console.log('postData in fixasr.service');
        // TODO - handle null return. Here we just cast to the correct object type.
        return <Observable<FixasrText>> this.http.post<FixasrText>(url, asrtext, httpOptions)
            .pipe(catchError(this.errHandling.handleError));
    }
}

