import { Inject, Injectable } from '@angular/core';
import { GovbodyMapper } from '../../models/govbody-mapper';
import { GovbodyClient, GovLocationClient } from '../../apis/api.generated.clients';
import { GovbodyDetails_Dto, GovLocation_Dto, Official_Dto } from '../../apis/api.generated.clients';
import { RegisterGovbody_Cmd } from '../../apis/api.generated.clients';
import { IGovbody_Vm, IGovbodyDetails_Vm, IGovLocation_Vm, IOfficial_Vm } from '../../models/govbody-view';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class RegisterGovBodyService {
  mapper: GovbodyMapper;
  govbodyClient: GovbodyClient;
  govLocationClient: GovLocationClient;

  // myGovlocationsDto: GovLocation_Dto[];
  // myGovlocationsVm: IGovLocation_Vm[] = [];

  // mygovDto: IGovLocationArray_Dto = new IGovLocationArray_Dto();
  //// mygovVm: IGovLocationArray_Vm = new IGovLocationArray_Vm();
  // mygovVm: IGovLocationArray_Vm;

  // observeVm: Observable<IGovLocation_Vm[]> = null;
  // observe: Observable<GovLocation_Dto[]> = null;
  // my1: IGovLocation_Vm;

  // returnofcall: any;

  constructor(
    // public http: HttpClient,
    _govbodyClient: GovbodyClient,
    _govLocationClient: GovLocationClient
  ) {
    this.mapper = new GovbodyMapper();
    this.govbodyClient = _govbodyClient;
    this.govLocationClient = _govLocationClient;
  }

  public getMyGovLocations(): Observable<IGovLocation_Vm[]> {
    return this.govLocationClient.getMyGovLocations().pipe(map((n) => this.mapMyGovLocations(n)));
  }

  mapMyGovLocations(n): IGovLocation_Vm[] {
    const vms: IGovLocation_Vm[] = [];
    n.forEach((value, index) => {
      vms.push(this.mapper.mapper.map(value, 'IGovLocation_Vm', 'GovLocation_Dto'));
    });
    return vms;
  }

  public getGovbodies(govLocationId: number): Observable<IGovbody_Vm[]> {
    return this.govbodyClient.getGovbodies(govLocationId).pipe(map((n) => this.mapGovbodies(n)));
  }

  mapGovbodies(n): IGovbody_Vm[] {
    const vms: IGovbody_Vm[] = [];
    n.forEach((value, index) => {
      vms.push(this.mapper.mapper.map(value, 'IGovbody_Vm', 'Govbody_Dto'));
    });
    return vms;
  }

  public getGovbody(govbodyId: number): Observable<IGovbodyDetails_Vm> {
    return this.govbodyClient.getGovbody(govbodyId).pipe(map((n) => this.mapGovbodyDetails(n)));
  }

  mapGovbodyDetails(n): IGovbodyDetails_Vm {
    return this.mapper.mapper.map(n, 'IGovbodyDetails_Vm', 'GovbodyDetails_Dto');
  }

  public registerGovbody(govbody: IGovbodyDetails_Vm) {
    // API: register(command: RegisterGovbody_Cmd): Observable<number> {
    //  let govbodyRegCmd: RegisterGovbody_Cmd;
    //  // TODO map vm to cmd
    //  this.govbodyClient.register(govbodyRegCmd);
  }
}
