import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from './viewmeeting/viewmeeting'
import { AddtagsComponent } from './addtags/addtags'
import { FixasrComponent } from './fixasr/fixasr'
import { DashMainComponent } from './dash-main/dash-main';
import { AboutProjectComponent } from './about-project/about-project';
import { PurposeComponent } from './about-project/purpose/purpose';
import { OverviewComponent } from './about-project/overview/overview';
import { WorkflowComponent } from './about-project/workflow/workflow';
import { AutoProcessingComponent } from './about-project/auto-processing/auto-processing';
import { ManualProcessingComponent } from './about-project/manual-processing/manual-processing';
import { ExtendGovmeetingComponent } from './about-project/extend-govmeeting/extend-govmeeting';

// import { GovInfoComponent } from './gov-info/gov-info.component';
// import { BillsComponent } from './bills/bills.component';
// import { MeetingsComponent } from './meetings/meetings.component';
// import { NewsComponent } from './news/news.component';


const routes: Routes = [

    // { path: '', redirectTo: 'about' },
    {
      path: 'login',
      redirectTo: 'account/login'
    },

    { path: 'viewmeeting', component: ViewMeetingComponent },
    { path: 'addtags', component: AddtagsComponent },
    { path: 'fixasr', component: FixasrComponent },
    { path: 'dashboard', component: DashMainComponent},
    { path: 'purpose', component: PurposeComponent},
    { path: 'overview', component: OverviewComponent},
    { path: 'workflow', component: WorkflowComponent},
    { path: 'autoprocessing', component: AutoProcessingComponent},
    { path: 'manualprocessing', component: ManualProcessingComponent},
    { path: 'extendgovmeeting', component: ExtendGovmeetingComponent},
    { path: 'about', component: AboutProjectComponent},
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
