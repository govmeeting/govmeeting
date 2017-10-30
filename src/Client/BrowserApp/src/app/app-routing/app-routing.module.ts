import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component'
import { MeetingComponent } from '../meeting/meeting.component'

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
    },
    {
      path: 'meeting',
      component: MeetingComponent,
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
