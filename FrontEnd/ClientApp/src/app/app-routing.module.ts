import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from './viewmeeting/viewmeeting'
import { AddtagsComponent } from './addtags/addtags'
import { FixasrComponent } from './fixasr/fixasr'
import { DashMainComponent } from './dash-main/dash-main';
import { PurposeComponent } from './about-project/purpose/purpose';
import { OverviewComponent } from './about-project/overview/overview';
import { WorkflowComponent } from './about-project/workflow/workflow';
import { Dev1Component } from './about-project/dev-1/dev-1';
import { Dev2Component } from './about-project/dev-2/dev-2';
import { Dev3Component } from './about-project/dev-3/dev-3';
import { Dev4Component } from './about-project/dev-4/dev-4';
import { Dev5Component } from './about-project/dev-5/dev-5';

const routes: Routes = [
    {
      path: 'login',
      redirectTo: 'account/login'
    },
    // { path: 'viewmeeting', component: ViewMeetingComponent },
    // { path: 'addtags', component: AddtagsComponent },
    // { path: 'fixasr', component: FixasrComponent },
    { path: 'dashboard', component: DashMainComponent},
    { path: 'purpose', component: PurposeComponent},
    { path: 'overview', component: OverviewComponent},
    { path: 'workflow', component: WorkflowComponent},
    { path: 'dev1', component: Dev1Component},
    { path: 'dev2', component: Dev2Component},
    { path: 'dev3', component: Dev3Component},
    { path: 'dev4', component: Dev4Component},
    { path: 'dev5', component: Dev5Component},
    { path: '**', redirectTo: 'purpose' }

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
