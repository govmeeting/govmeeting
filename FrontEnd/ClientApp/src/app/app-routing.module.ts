import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from './viewmeeting/viewmeeting'
import { AddtagsComponent } from './addtags/addtags'
import { FixasrComponent } from './fixasr/fixasr'
import { DashMainComponent } from './dash-main/dash-main';

import { AboutComponent } from './about-project/about-project';
// import { PurposeComponent } from './about-project/purpose/purpose';
import { OverviewComponent } from './about-project/overview/overview';
// import { WorkflowComponent } from './about-project/workflow/workflow';

// "Routing in Angular using Routerlink, Navigate and NavigateByUrl"
// https://www.codecompiled.com/angular/routing-in-angular-using-routerlink-navigate-and-navigatebyurl/

const routes: Routes = [
    {
      path: 'login',
      redirectTo: 'account/login'
    },
    // { path: 'viewmeeting', component: ViewMeetingComponent },
    // { path: 'addtags', component: AddtagsComponent },
    // { path: 'fixasr', component: FixasrComponent },
    { path: 'dashboard', component: DashMainComponent},
    // { path: 'category/:id/:subid', component: categoryComponent },
    { path: 'about', component: AboutComponent},
    // { path: 'purpose', component: PurposeComponent},
    { path: 'overview', component: OverviewComponent},
    // { path: 'workflow', component: WorkflowComponent},
    { path: '**', redirectTo: 'about' }

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
