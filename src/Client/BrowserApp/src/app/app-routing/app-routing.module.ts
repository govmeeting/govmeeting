import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component'
import { MeetingComponent } from '../meeting/meeting.component'
import { AddtagsComponent } from '../addtags/addtags.component'
import { FixasrComponent } from '../fixasr/fixasr.component'

const routes: Routes = [
    {
      path: '',
      component: HomeComponent,
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
