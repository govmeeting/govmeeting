import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from './viewmeeting/viewmeeting'
import { AddtagsComponent } from './addtags/addtags'
import { FixasrComponent } from './fixasr/fixasr'
import { MainContentComponent } from './dash-main/dash-main';
import { AboutProjectComponent } from './about-project/about-project';
import { GovInfoComponent } from './gov-info/gov-info.component';


import { BillsComponent } from './bills/bills.component';
import { MeetingsComponent } from './meetings/meetings.component';
import { NewsComponent } from './news/news.component';

const routes: Routes = [

    // { path: '', redirectTo: 'about' },
    { path: 'viewmeeting', component: ViewMeetingComponent },
    { path: 'addtags', component: AddtagsComponent },
    { path: 'fixasr', component: FixasrComponent },
    { path: 'dashboard', component: MainContentComponent},
    { path: 'about', component: AboutProjectComponent},
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
