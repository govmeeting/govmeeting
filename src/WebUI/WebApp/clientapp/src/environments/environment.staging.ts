// export const environment = {
//   apiUrl: 'http://localhost:6578/',
//   production: false,
// };

import { IEnvironment } from './ienvironment';

const apiHost = 'localhost:6578';
const apiUrl = `https://${apiHost}`;

export const environment: IEnvironment = {
  production: false,
  enableDebugTools: true,
  logLevel: 'debug',
  apiHost,
  apiUrl,
  useServer: false, // Todo: switch to true when docker implemented
  isBeta: false,
  useLargeData: false,
};
