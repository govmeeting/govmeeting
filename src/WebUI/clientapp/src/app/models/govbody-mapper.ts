import { PojosMetadataMap, pojos } from '@automapper/pojos';
import {
  createMap,
  createMapper,
  Mapper,
  //  CamelCaseNamingConvention,
  //  mapFrom
} from '@automapper/core';

import {
  IGovbody_Vm,
  IGovbodyDetails_Vm,
  IGovLocation_Vm,
  IOfficial_Vm,
  IAppointedOfficial_Vm,
  IElectedOfficial_Vm,
} from './govbody-view';

import {
  GovLocationDto,
  GovbodyDto,
  GovbodyDetailsDto,
  GovlocTypes,
  // OfficialDto,    // TODO - why isn't openapi-generator defining this.
  ElectedOfficialDto,
  AppointedOfficialDto,
  // } from '../apis/api.generated.clients';
} from '../core/api/v1/model/models';
import { Injectable } from '@angular/core';

// copied from prior nswag generated code
class OfficialDto {
  name!: string | undefined; // "!" means whenever we use 'name' it will NOT be null.
  title!: string | undefined;
}
// export class IGovLocationArray_Dto {
//  locations: GovLocationDto[];
// }

// export class IGovLocationArray_Vm {
//  locations: IGovLocation_Vm[];
// }

@Injectable({
  providedIn: 'root',
})
export class GovbodyMapper {
  mapper: Mapper;

  constructor() {
    this.mapper = createMapper({
      // name: 'GovbodyMapper',
      // pluginInitializer: pojos,
      strategyInitializer: pojos(),
    });

    this.mapOfficial();

    this.mapGovLocation();

    // this.mapGovLocationArray();

    this.mapGovbodyDetails();

    this.mapGovbody();
  }

  mapOfficial() {
    // Add metadata to members of IOfficial_Vm
    PojosMetadataMap.create<IOfficial_Vm>('Official_Vm', {
      name: String,
      title: String,
    });

    // Add metadata to members of OfficialDto. Currently the members are the same as IOfficial_Vm.
    PojosMetadataMap.create<OfficialDto>('OfficialDto', {
      name: String,
      title: String,
    });

    // Create the mapping.
    // this.mapper.createMap<OfficialDto, IOfficial_Vm>('GovOfficialDto', 'IGovOfficial_Vm');
    createMap<OfficialDto, IOfficial_Vm>(this.mapper, 'GovOfficialDto', 'IGovOfficial_Vm');
  }

  mapGovLocation() {
    PojosMetadataMap.create<IGovLocation_Vm>('IGovLocation_Vm', {
      id: Number,
      name: String,
      type: Number,
      parentLocationId: Number,
    });

    // PojosMetadataMap.create<GovLocationDto>('GovLocationDto', 'IGovLocation_Vm');
    PojosMetadataMap.create<GovLocationDto>('GovLocationDto', {
      id: Number,
      name: String,
      type: Number,
      parentLocationId: Number,
    });

    createMap<GovLocationDto, IGovLocation_Vm>(this.mapper, 'GovLocationDto', 'IGovLocation_Vm');
  }

  mapGovbodyDetails() {
    PojosMetadataMap.create<IGovbodyDetails_Vm>('IGovbodyDetails_Vm', {
      name: String,
      parentLocationId: Number,
      officials: 'IOfficial_Vm',
      officers: 'IOfficial_Vm',
      recordingsUrl: String,
      transcriptsUrl: String,
    });

    PojosMetadataMap.create<GovbodyDetailsDto>('IGovbodyDetailsDto', {
      name: String,
      parentLocationId: Number,
      electedOfficials: 'IOfficialDto',
      appointedOfficials: 'IOfficialDto',
      recordingsUrl: String,
      transcriptsUrl: String,
    });

    createMap<GovbodyDetailsDto, IGovbodyDetails_Vm>(this.mapper, 'GovbodyDetailsDto', 'IGovbodyDetails_Vm');
  }

  mapGovbody() {
    PojosMetadataMap.create<IGovbody_Vm>('IGovbody_Vm', {
      id: Number,
      name: String,
      parentLocationId: Number,
    });

    PojosMetadataMap.create<GovbodyDetailsDto>('GovbodyDto', {
      // id: Number,
      name: String,
      parentLocationId: Number,
    });

    createMap<GovbodyDto, IGovbody_Vm>(this.mapper, 'GovbodyDto', 'IGovbody_Vm');
  }

  // mapGovLocationArray() {
  //  createMetadataMap<IGovLocationArray_Dto>('IGovLocationArray_Dto', {
  //    locations: 'GovLocationDto',
  //  });

  //  createMetadataMap<IGovLocationArray_Vm>('IGovLocationArray_Vm', {
  //    locations: 'IGovLocation_Vm',
  //  });

  //  this.mapper.createMap<IGovLocationArray_Dto, IGovLocationArray_Vm>('IGovLocationArray_Dto', 'IGovLocationArray_Vm');
  // }

  /////////////////////////// TESTS CALLED FROM govbody-mapper.spec.ts ///////////////////

  //  testGovLocationMapper(): boolean {
  //    const g1: GovLocationDto = { id: 1, name: 'me', type: 0, parentLocationId: 2 };
  //    const g2: IGovLocation_Vm = this.mapper.map(g1, 'IGovLocation_Vm', 'GovLocationDto');
  //    return true;
  //  }

  //  testGovbodyDetailsMapper(): boolean {
  //    const g1: GovbodyDetailsDto = {
  //      name: 'me',
  //      parentLocationId: 1,
  //      electedOfficials: [
  //        { name: 'Joe', title: 'Mayor' },
  //        { name: 'Sam', title: 'Councilman' },
  //      ],
  //      appointedOfficials: [
  //        { name: 'Sally', title: 'Manager' },
  //        { name: 'Jake', title: 'Clerk' },
  //      ],
  //      recordingsUrl: 'http://us.org',
  //      transcriptsUrl: 'http://them.org',
  //    };
  //    const g2: IGovbodyDetails_Vm = this.mapper.map(g1, 'IGovbodyDetails_Vm', 'GovbodyDetailsDto');
  //    return true;
  //  }

  //  testGovbodyMapper(): boolean {
  //    const g1: GovbodyDto = { id: 1, name: 'me', parentLocationId: 2 };
  //    const g2: IGovbody_Vm = this.mapper.map(g1, 'IGovbody_Vm', 'GovbodyDto');
  //    return true;
  //  }
}
