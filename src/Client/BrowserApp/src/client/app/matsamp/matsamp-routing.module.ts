import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatsampComponent } from './matsamp.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'matsamp', component: MatsampComponent }
    ])
  ],
  exports: [RouterModule]
})
export class MatsampRoutingModule { }
