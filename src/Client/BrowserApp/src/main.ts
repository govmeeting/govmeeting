import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

// Data passed in from index.html
import { AppData } from './app/appdata';

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.log(err));
