import { createMetadataMap, pojos } from "@automapper/pojos";
import { Mapper } from '@automapper/types';
import {
  createMapper
  //  CamelCaseNamingConvention,
  //  mapFrom
} from "@automapper/core";

import {
  IGovbody_Vm,
  IGovbodyDetails_Vm,
  IGovLocation_Vm,
  IOfficial_Vm,
  IAppointedOfficial_Vm,
  IElectedOfficial_Vm
} from './govbody-view';

import {
  GovLocation_Dto,
  Govbody_Dto,
  GovbodyDetails_Dto,
  GovlocTypes,
  Official_Dto,
  ElectedOfficial_Dto,
  AppointedOfficial_Dto
} from '../apis/api.generated.clients';
import { Injectable } from "@angular/core";

export class IGovLocationArray_Dto {
  locations: GovLocation_Dto[];
}

export class IGovLocationArray_Vm {
  locations: IGovLocation_Vm[];
}

@Injectable({
  providedIn: 'root'
})
export class GovbodyMapper{

  mapper: Mapper;

  constructor() {
    this.mapper = createMapper({
      name: "GovbodyMapper",
      pluginInitializer: pojos
    });

    this.mapOfficial();

    this.mapGovLocation();

    this.mapGovLocationArray();

    this.mapGovbodyDetails();

    this.mapGovbody();
  }

  mapOfficial() {
    // Add metadata to members of IOfficial_Vm
    createMetadataMap<IOfficial_Vm>("Official_Vm", {
      name: String,
      title: String
    });

    // Add metadata to members of Official_Dto. Currently the members are the same as IOfficial_Vm.
    createMetadataMap<Official_Dto>("Official_Dto", "Official_Vm");

    // Create the mapping.
    this.mapper.createMap<Official_Dto, IOfficial_Vm>("GovOfficial_Dto", "IGovOfficial_Vm");
  }

  mapGovLocation(){
    createMetadataMap<IGovLocation_Vm>("IGovLocation_Vm", {
      id: Number,
      name: String,
      type: Number,
      parentLocationId: Number
    });

    createMetadataMap<GovLocation_Dto>("GovLocation_Dto", "IGovLocation_Vm");

    this.mapper.createMap<GovLocation_Dto, IGovLocation_Vm>("GovLocation_Dto", "IGovLocation_Vm");
  }

  mapGovbodyDetails() {
    createMetadataMap<IGovbodyDetails_Vm>("IGovbodyDetails_Vm", {
      name: String,
      parentLocationId: Number,
      officials: "IOfficial_Vm",
      officers: "IOfficial_Vm",
      recordingsUrl: String,
      transcriptsUrl: String
    });

    createMetadataMap<GovbodyDetails_Dto>("GovbodyDetails_Dto", "IGovbodyDetails_Vm");

    this.mapper.createMap<GovbodyDetails_Dto, IGovbodyDetails_Vm>("GovbodyDetails_Dto", "IGovbodyDetails_Vm");
  }

  mapGovbody() {
    createMetadataMap<IGovbody_Vm>("IGovbody_Vm", {
      id: Number,
      name: String,
      parentLocationId: Number,
    });

    createMetadataMap<GovbodyDetails_Dto>("Govbody_Dto", "IGovbody_Vm");

    this.mapper.createMap<Govbody_Dto, IGovbody_Vm>("Govbody_Dto", "IGovbody_Vm");
  }

  mapGovLocationArray() {
    createMetadataMap<IGovLocationArray_Dto>("IGovLocationArray_Dto", {
      locations: "GovLocation_Dto"
    });

    createMetadataMap<IGovLocationArray_Vm>("IGovLocationArray_Vm", {
      locations: "IGovLocation_Vm"
    });

    this.mapper.createMap<IGovLocationArray_Dto, IGovLocationArray_Vm>("IGovLocationArray_Dto", "IGovLocationArray_Vm");
  }

  /////////////////////////// TESTS CALLED FROM govbody-mapper.spec.tx ///////////////////

  testGovLocationMapper(): boolean {
    let g1: GovLocation_Dto = { id: 1, name: "me", type: 0, parentLocationId: 2 };
    let g2: IGovLocation_Vm = this.mapper.map(g1, "IGovLocation_Vm", "GovLocation_Dto");
    return true;
  }

  testGovbodyDetailsMapper(): boolean {
    let g1: GovbodyDetails_Dto = {
      name: "me", parentLocationId: 1,
      electedOfficials: [{ name: "Joe", title: "Mayor" }, { name: "Sam", title: "Councilman" }],
      appointedOfficials: [{ name: "Sally", title: "Manager" }, { name: "Jake", title: "Clerk" }],
      recordingsUrl: "http://us.org",
      transcriptsUrl: "http://them.org"
    }
    let g2: IGovbodyDetails_Vm = this.mapper.map(g1, "IGovbodyDetails_Vm", "GovbodyDetails_Dto");
    return true;
    };

  testGovbodyMapper(): boolean {
    let g1: Govbody_Dto = { id: 1, name: "me", parentLocationId: 2 };
    let g2: IGovbody_Vm = this.mapper.map(g1, "IGovbody_Vm", "Govbody_Dto");
    return true;
  }
}
