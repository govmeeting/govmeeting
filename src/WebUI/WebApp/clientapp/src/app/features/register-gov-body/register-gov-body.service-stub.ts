import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGovbody_Vm, IGovbodyDetails_Vm, IGovLocation_Vm, IOfficial_Vm } from '../../models/govbody-view';
import { RegisterGovBodyService } from './register-gov-body.service';

@Injectable()
export class RegisterGovBodyServiceStub implements RegisterGovBodyService {

  locations: IGovLocation_Vm[] = [
    {
      "id": 8,
      "name": "Boothbay Harbor",
      "type": 3,
      "parentLocationId": 7
    },
    {
      "id": 7,
      "name": "Lincoln County",
      "type": 4,
      "parentLocationId": 6
    },
    {
      "id": 6,
      "name": "Maine",
      "type": 5,
      "parentLocationId": 5
    },
    {
      "id": 5,
      "name": "United States",
      "type": 7,
      "parentLocationId": 0
    }
  ];

  // GovBodies for Boothbay Harbor, location 8.
  govbodies: IGovbody_Vm[] = [
      {
        "id": 4,
        "name": "Board of Selectmen",
        "parentLocationId": 8
      },
      {
        "id": 5,
        "name": "Planning Board",
        "parentLocationId": 8
      }
  ]

  govbody: IGovbodyDetails_Vm[] = [
    {
      name: "Board of Selectmen",
      parentLocationId: 8,
      officials: [
        { name: "Wendy Wolf", title: "Selectperson" },
        { name: "Michael Tomko", title: "Chair" },
        { name: "Denise Griffin ", title: "Councilman" },
        { name: "Tricia Warren ", title: "Vice Chair" }
       ],
      officers: [

        { name: "Charles Cuccia", title: "Township Administrator" },
        { name: "Cynthia Kraus, RMC", title: "Township Clerk" },
        { name: "Steven Post", title: "Chief of Police" },
        { name: "Richard Hamilton", title: "Tax Assessor" },
        { name: "James Di Maria", title: "Construction Official" },
        { name: "Charles Cuccia", title: "CMFO/Treasurer" },
        { name: "John E. Biegel III", title: "Health Officer" },
        { name: "Ronald Campbell", title: "DPW Superintendent" }

      ],
      recordingsUrl: "www.youtube.com/xxxxx",
      transcriptsUrl: "www.bbh.org/documents"
    },
    {
      name: "Zoning Board",
      parentLocationId: 8,
      officials: [],
      officers: [],
      recordingsUrl: "",
      transcriptsUrl: ""
    }
  ]



  // get my locations
  public getMyGovLocations(): Observable<IGovLocation_Vm[]> {
    return Observable.of(this.locations);
  }

  // Only location 8 has some govbodies
  public getGovbodies(govLocationId: number): Observable<IGovbody_Vm[]> {
    if (govLocationId != 8) {
      return Observable.of([]);
    }
    return Observable.of(this.govbodies);
  }

  // get GovBody details
  public getGovbody(govbodyId: number): Observable<IGovbodyDetails_Vm> {
    switch (govbodyId) {
      case 4: 
        return Observable.of(this.govbody[0]);
      case 5:
        return Observable.of(this.govbody[1]);
      default:
        return Observable.of(null);
    }
  }
}
