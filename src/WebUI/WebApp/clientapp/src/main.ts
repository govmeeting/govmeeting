/***************************************************************************************************
 * Load `$localize` onto the global scope - used if i18n tags appear in Angular templates.
 */
import '@angular/localize/init';
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
  // Providing API_BASE_URL allows us to inject the base href into our components:
  //   constructor(@Inject(APP_BASE_HREF) public apiBaseUrl:string) { ...
  // and then use it in the HTML:
  //   <img [src]="apiBaseUrl + '/assets/img/myimage.jpg'"
  // PS: We are currently only doing this in the sample FetchDataComponent.
  { provide: 'API_BASE_URL', useFactory: getApiUrl, deps: [] },
  // { provide: API_BASE_URL, useFactory: getApiUrl },
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.log(err));
