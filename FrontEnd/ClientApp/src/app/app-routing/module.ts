import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from '../viewmeeting/component'
import { AddtagsComponent } from '../addtags/component'
import { FixasrComponent } from '../fixasr/component'
import { MainContentComponent } from '../dashboard/dash-main/main-content/component';
import { AboutProjectComponent } from '../about-project/component';

const routes: Routes = [

    { path: 'viewmeeting', component: ViewMeetingComponent },
    { path: 'addtags', component: AddtagsComponent },
    { path: 'fixasr', component: FixasrComponent },
    { path: 'dashboard', component: MainContentComponent },
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
