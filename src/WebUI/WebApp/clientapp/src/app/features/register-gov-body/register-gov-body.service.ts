import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { IGovbodyDetails_Vm, IGovbody_Vm, IGovLocation_Vm } from "../../models/govbody-view";

// our abstract class
@Injectable()
export abstract class RegisterGovBodyService {
  abstract getMyGovLocations(): Observable<IGovLocation_Vm[]>
  abstract getGovbodies(govLocationId: number): Observable<IGovbody_Vm[]>;
  abstract getGovbody(govbodyId: number): Observable<IGovbodyDetails_Vm>;
}
