import { Component } from '@angular/core';
import { Config } from './shared/index';
import './operators';

// Data passed in from index.html
import { AppData } from './appdata';

/**
 * This class represents the main application component.
 */
@Component({
  moduleId: module.id,
  selector: 'sd-app',
  templateUrl: 'app.component.html',
  styles: ['app.component.css']
})
export class AppComponent {
  constructor(appData:AppData) {
    console.log('Environment config', Config);
    console.log("AppComponent - ", appData);
  }
}
