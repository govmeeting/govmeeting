import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ViewTranscript } from '../../models/viewtranscript-view';

// our abstract class
@Injectable()
export abstract class ViewTranscriptService {
  abstract getMeeting(meetingId: number): Observable<ViewTranscript> | null;
}
