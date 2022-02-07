import { IEnvironment } from './ienvironment';

const apiHost = 'govmeeting.com';
const apiUrl = `https://${apiHost}/api`;

export const environment: IEnvironment = {
  production: true,
  enableDebugTools: false,
  logLevel: 'error',
  apiHost,
  apiUrl,
  useServer: false, // In production, we will run without server for now.
  isBeta: false,
  isLargeEditData: false,
};
