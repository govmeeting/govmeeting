import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// For testing without the dashboard
// import { ViewTranscriptComponent } from './viewtranscript/viewtranscript'
// import { AddtagsComponent } from './addtags/addtags'
// import { FixasrComponent } from './fixasr/fixasr'
// import { EdittranscriptComponent } from './fixasr/fixasr'

import { AboutComponent } from './about-project/about-project';
import { OverviewComponent } from './about-project/overview/overview';
// import { SysDesignComponent } from './about-project/sys-design/sys-design';
import { DashMainComponent } from './dashboard/dash-main/dash-main';

import { FetchDataComponent } from './fetch-data/fetch-data.component';

// "Routing in Angular using Routerlink, Navigate and NavigateByUrl"
// https://www.codecompiled.com/angular/routing-in-angular-using-routerlink-navigate-and-navigatebyurl/

const routes: Routes = [
  {
    path: 'login',
    redirectTo: 'account/login',
  },
  // { path: 'viewtranscript', component: ViewTranscriptComponent },
  // { path: 'addtags', component: AddtagsComponent },
  // { path: 'fixasr', component: FixasrComponent },
  { path: 'dashboard', component: DashMainComponent },
  { path: 'about', component: AboutComponent },
  { path: 'overview', component: OverviewComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  // { path: '**', redirectTo: 'overview' }
  { path: '**', redirectTo: 'dashboard' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule {}
