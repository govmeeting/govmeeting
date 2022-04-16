import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';


// export function getBaseUrl() {
//  return document.getElementsByTagName('base')[0].href;
// }

// export function getApiUrl() {
//   return environment.apiUrl;
// }

// const providers = [
//   // Providing API_BASE_URL allows us to inject the base href into our components:
//   //   constructor(@Inject(APP_BASE_HREF) public apiBaseUrl:string) { ...
//   // and then use it in the HTML:
//   //   <img [src]="apiBaseUrl + '/assets/img/myimage.jpg'"
//   // PS: We are currently only doing this in the sample FetchDataComponent.
//   { provide: 'API_BASE_URL', useFactory: getApiUrl, deps: [] },
//   // { provide: API_BASE_URL, useFactory: getApiUrl },
// ];


if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
