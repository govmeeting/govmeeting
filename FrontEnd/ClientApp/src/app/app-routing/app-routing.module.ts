import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ViewMeetingComponent } from '../viewmeeting/viewmeeting.component'
import { AddtagsComponent } from '../addtags/addtags.component'
import { FixasrComponent } from '../fixasr/fixasr.component'
import { MainContentComponent } from '../dashboard/main-content/main-content.component';
import { AboutProjectComponent } from '../about-project/about-project.component';

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
