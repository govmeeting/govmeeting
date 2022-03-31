import { GovlocTypes } from '../apis/api.generated.clients';

export interface IGovbody_Vm {
  id: number;
  name: string;
  parentLocationId: number;
}

export interface IGovbodyDetails_Vm {
  name: string;
  parentLocationId: number;
  officials: IOfficial_Vm[];
  officers: IOfficial_Vm[];
  recordingsUrl: string;
  transcriptsUrl: string;
}

export interface IGovLocation_Vm {
  id: number;
  name: string | undefined;
  type: GovlocTypes;
  parentLocationId: number;
}

export interface IOfficial_Vm {
  name: string;
  title: string | undefined;
}

export interface IElectedOfficial_Vm extends IOfficial_Vm {}

export interface IAppointedOfficial_Vm extends IOfficial_Vm {}
