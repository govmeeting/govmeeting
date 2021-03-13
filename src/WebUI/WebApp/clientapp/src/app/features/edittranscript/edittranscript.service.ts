import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { EditTranscript } from "../../models/edittranscript-view";

// our abstract class
@Injectable()
export abstract class EditTranscriptService {
  abstract getTalks(): Observable<EditTranscript>;
}
