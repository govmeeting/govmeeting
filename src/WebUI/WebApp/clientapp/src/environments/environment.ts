// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
// A good description of this method of using the environment.x.ts files is here:
//   https://stackoverflow.com/a/46059937/1978840

import { IEnvironment } from './ienvironment';

const apiHost = 'localhost:44333';
const apiUrl = `https://${apiHost}`;

export const environment: IEnvironment = {
  production: false,
  enableDebugTools: true,
  logLevel: 'debug',
  apiHost,
  apiUrl,
  useServer: false, // ToDo - this is temporary
  isBeta: false,
  isLargeEditData: false,
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error.
 * https://stackoverflow.com/questions/49873128/how-to-stop-errors-generated-by-zone-js-in-browser-console/49953454
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
