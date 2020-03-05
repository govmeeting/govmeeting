import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from './viewmeeting/viewmeeting'
import { AddtagsComponent } from './addtags/addtags'
import { FixasrComponent } from './fixasr/fixasr'
import { DashMainComponent } from './dash-main/dash-main';
import { PurposeComponent } from './about-project/purpose/purpose';
import { OverviewComponent } from './about-project/overview/overview';
import { WorkflowComponent } from './about-project/workflow/workflow';
import { AutoProcessingComponent } from './about-project/auto-processing/auto-processing';
import { ManualProcessingComponent } from './about-project/manual-processing/manual-processing';
import { DeveloperNotesComponent } from './about-project/developer-notes/developer-notes';

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
    { path: 'autoprocessing', component: AutoProcessingComponent},
    { path: 'manualprocessing', component: ManualProcessingComponent},
    { path: 'developernotes', component: DeveloperNotesComponent},
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
