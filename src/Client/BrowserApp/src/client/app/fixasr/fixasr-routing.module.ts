import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FixasrComponent } from './fixasr.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'fixasr', component: FixasrComponent }
    ])
  ],
  exports: [RouterModule]
})
export class FixasrRoutingModule { }
