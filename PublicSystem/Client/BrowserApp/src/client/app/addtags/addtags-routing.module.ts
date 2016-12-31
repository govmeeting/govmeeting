import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AddtagsComponent } from './addtags.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'addtags', component: AddtagsComponent }
    ])
  ],
  exports: [RouterModule]
})
export class AddtagsRoutingModule { }
