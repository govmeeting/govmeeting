import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

/**
 * This is part of the sample code that came with angular-seed. See the description for HomeModule for why we are keeping this.
 */
@NgModule({
  imports: [
    RouterModule.forChild([
      { path: '', component: HomeComponent }
    ])
  ],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
