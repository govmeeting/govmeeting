import { provideRouter, RouterConfig } from '@angular/router';

import { AddtagsRoutes } from './addtags/index';
import { MeetingRoutes } from './meeting/index';
import { HomepageRoutes } from './homepage/index';
//  Sample app from angular2-seed
import { AboutRoutes } from './about/index';
import { HomeRoutes } from './home/index';

const routes: RouterConfig = [
  ...AddtagsRoutes,
  ...MeetingRoutes,
  ...HomeRoutes,
  ...AboutRoutes,
  ...HomepageRoutes
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes),
];
