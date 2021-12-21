// export const environment = {
//   apiUrl: 'http://localhost:6578/',
//   production: false,
// };

import { IEnvironment } from './ienvironment';

const apiHost = 'localhost:6578';
const apiUrl = `https://${apiHost}`;
const useServer = null;

export const environment: IEnvironment = {
  production: false,
  enableDebugTools: true,
  logLevel: 'debug',
  apiHost,
  apiUrl,
  useServer,
};
