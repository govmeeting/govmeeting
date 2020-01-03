import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from './viewmeeting/component'
import { AddtagsComponent } from './addtags/addtags'
import { FixasrComponent } from './fixasr/fixasr'
import { MainContentComponent } from './dash-main/dash-main';
import { AboutProjectComponent } from './about-project/about-project';
import { GovInfoComponent } from './gov-info/gov-info.component';

import {InfoCityComponent} from './dash-sidenav/sidenav-info/info-city/info-city';
import {InfoCountyComponent} from './dash-sidenav/sidenav-info/info-county/info-county';

const routes: Routes = [

    { path: 'viewmeeting', component: ViewMeetingComponent },
    { path: 'addtags', component: AddtagsComponent },
    { path: 'fixasr', component: FixasrComponent },
    { path: 'dashboard', component: MainContentComponent,
    children: [
      // { path: '', redirectTo: 'infocity', pathMatch: 'full' },
      // { path: 'infocity', component: InfoCityComponent },
      // { path: 'infocounty', component: InfoCountyComponent }
      { path: 'govinfo/:item', component: GovInfoComponent }
    ]
     },
    { path: 'about', component: AboutProjectComponent},
    { path: '**', redirectTo: 'dashboard' }

];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    declarations: []
})
export class AppRoutingModule { }
