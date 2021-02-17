//import { createMapper, mapFrom } from '@automapper/core';
//import { classes } from '@automapper/classes';
//import { createMetadataMap } from '@automapper/pojos';
//import "reflect-metadata";

import { createMetadataMap, pojos } from "@automapper/pojos";
import {
  createMapper,
  CamelCaseNamingConvention,
  mapFrom
} from "@automapper/core";

//import { EditMeeting_Dto } from '../apis/swagger-api';
//import { EditTranscript } from './edittranscript-view';

import { GovbodyDetails_Dto, ElectedOfficial_Dto, AppointedOfficial_Dto } from '../apis/api.generated.clients'
import { IGovbodyDetails } from './govbody-view'

createMetadataMap<GovbodyDetails_Dto>('GovbodyDetails_Dto', {
  name: String,
  parentLocationId: Number,
  electedOfficials: ElectedOfficial_Dto[],
  appointedOfficials: AppointedOfficial_Dto[],
  recordingsUrl: String,
  transcriptsUrl: String
});

createMetadataMap<ElectedOfficial_Dto>('ElectedOfficial_Dto', {
});

createMetadataMap<AppointedOfficial_Dto>('ElectedOfficial_Dto', {
});



export const mapper = createMapper({
  name: 'someName',
  pluginInitializer: pojos
});
