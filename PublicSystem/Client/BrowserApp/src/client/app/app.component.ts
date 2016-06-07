import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES, Routes } from '@angular/router';
import { HTTP_PROVIDERS} from '@angular/http';
import { AboutComponent } from './+about/index';
import { HomeComponent } from './+home/index';
import { MeetingComponent } from './+meeting/index';
import { AddtagsComponent } from './+addtags/index';

import { NameListService, NavbarComponent, ToolbarComponent} from './shared/index';

/**
 * This class represents the main application component. Within the @Routes annotation is the configuration of the
 * applications routes, configuring the paths for the lazy loaded components (HomeComponent, AboutComponent).
 */
@Component({
  moduleId: module.id,
  selector: 'sd-app',
  viewProviders: [NameListService, HTTP_PROVIDERS],
  templateUrl: 'app.component.html',
  directives: [ROUTER_DIRECTIVES, NavbarComponent, ToolbarComponent]
})
@Routes([
  {
    path: '/',
    component: HomeComponent
  },
  {
    path: '/about',
    component: AboutComponent
  },
  {
    path: '/meeting',
    component: MeetingComponent
  },
  {
    path: '/addtags',
    component: AddtagsComponent
  }
])
export class AppComponent {}
