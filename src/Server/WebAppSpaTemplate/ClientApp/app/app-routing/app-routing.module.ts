import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component'
import { AboutComponent } from '../about/about.component';
import { MeetingComponent } from '../meeting/meeting.component'
import { AddtagsComponent } from '../addtags/addtags.component'
import { FixasrComponent } from '../fixasr/fixasr.component'
//import { MatsampComponent } from '../matsamp/matsamp.component'

const routes: Routes = [
    {
      path: '',
      component: HomeComponent,
    },
    {
      path: 'about',
      component: AboutComponent,
    },
    {
      path: 'meeting',
      component: MeetingComponent,
    },
    {
      path: 'addtags',
      component: AddtagsComponent,
    },
    {
      path: 'fixasr',
      component: FixasrComponent,
    },
    //{
    //  path: 'matsamp',
    //  component: MatsampComponent,
    //},
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
