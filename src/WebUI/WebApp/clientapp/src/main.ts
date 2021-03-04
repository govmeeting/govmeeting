import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import { API_BASE_URL } from './app/apis/api.generated.clients';

// export function getBaseUrl() {
//  return document.getElementsByTagName('base')[0].href;
// }
export function getApiUrl() {
  return environment.apiUrl;
}

const providers = [
  { provide: 'API_BASE_URL', useFactory: getApiUrl, deps: [] },
  { provide: API_BASE_URL, useFactory: getApiUrl },
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.log(err));
