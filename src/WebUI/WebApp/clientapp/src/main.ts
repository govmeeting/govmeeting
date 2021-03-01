import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import { API_BASE_URL } from './app/apis/api.generated.clients';

// export function getBaseUrl() {
//  return document.getElementsByTagName('base')[0].href;
// }
export function getBaseUrl() {
  return 'https://localhost:44333';
}

const providers = [
  { provide: 'API_BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: API_BASE_URL, useFactory: getBaseUrl },
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.log(err));
