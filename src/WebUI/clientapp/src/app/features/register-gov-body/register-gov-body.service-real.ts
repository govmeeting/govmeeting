import { Inject, Injectable } from '@angular/core';
import { GovbodyMapper } from '../../models/govbody-mapper';
import { GovbodyService } from '../../core/api/v1/api/govbody.service';
import { GovLocationService } from '../../core/api/v1/api/govLocation.service';
import { GovbodyDetailsDto, GovLocationDto } from '../../core/api/v1/model/models';
// import { RegisterGovbody_Cmd } from '../../apis/api.generated.clients';
import { IGovbody_Vm, IGovbodyDetails_Vm, IGovLocation_Vm, IOfficial_Vm } from '../../models/govbody-view';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { RegisterGovBodyService } from './register-gov-body.service';

// @Injectable({
//  providedIn: 'root',
// })
@Injectable()
export class RegisterGovBodyServiceReal implements RegisterGovBodyService {
  mapper: GovbodyMapper;
  govbodyService: GovbodyService;
  govLocationService: GovLocationService;

  // myGovlocationsDto: GovLocationDto[];
  // myGovlocationsVm: IGovLocation_Vm[] = [];

  // mygovDto: IGovLocationArray_Dto = new IGovLocationArray_Dto();
  //// mygovVm: IGovLocationArray_Vm = new IGovLocationArray_Vm();
  // mygovVm: IGovLocationArray_Vm;

  // observeVm: Observable<IGovLocation_Vm[]> = null;
  // observe: Observable<GovLocationDto[]> = null;
  // my1: IGovLocation_Vm;

  // returnofcall: any;

  constructor(
    // public http: HttpClient,
    _govbodyService: GovbodyService,
    _govLocationService: GovLocationService
  ) {
    this.mapper = new GovbodyMapper();
    this.govbodyService = _govbodyService;
    this.govLocationService = _govLocationService;
  }

  public getMyGovLocations(): Observable<IGovLocation_Vm[]> {
    return this.govLocationService.apiGovLocationGetMyGovLocationsGet().pipe(map((n) => this.mapMyGovLocations(n)));
  }

  mapMyGovLocations(n: any[]): IGovLocation_Vm[] {
    const vms: IGovLocation_Vm[] = [];
    n.forEach((value, index) => {
      vms.push(this.mapper.mapper.map(value, 'IGovLocation_Vm', 'GovLocationDto'));
    });
    return vms;
  }

  public getGovbodies(govLocationId: number): Observable<IGovbody_Vm[]> {
    return this.govbodyService.apiGovbodyGetGovbodiesIdGet(govLocationId).pipe(map((n) => this.mapGovbodies(n)));
  }

  mapGovbodies(n: any[]): IGovbody_Vm[] {
    const vms: IGovbody_Vm[] = [];
    n.forEach((value: any, index: any) => {
      vms.push(this.mapper.mapper.map(value, 'IGovbody_Vm', 'GovbodyDto'));
    });
    return vms;
  }

  public getGovbody(govbodyId: number): Observable<IGovbodyDetails_Vm> {
    return this.govbodyService.apiGovbodyGetGovbodyIdGet(govbodyId).pipe(map((n) => this.mapGovbodyDetails(n)));
  }

  mapGovbodyDetails(n: GovbodyDetailsDto): IGovbodyDetails_Vm {
    return this.mapper.mapper.map(n, 'IGovbodyDetails_Vm', 'GovbodyDetailsDto');
  }

  public registerGovbody(govbody: IGovbodyDetails_Vm) {
    // API: register(command: RegisterGovbody_Cmd): Observable<number> {
    //  let govbodyRegCmd: RegisterGovbody_Cmd;
    //  // TODO map vm to cmd
    //  this.govbodyService.register(govbodyRegCmd);
  }
}
