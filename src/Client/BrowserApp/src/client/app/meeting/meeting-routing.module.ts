import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MeetingComponent } from './meeting.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'meeting', component: MeetingComponent }
    ])
  ],
  exports: [RouterModule]
})
export class MeetingRoutingModule { }
