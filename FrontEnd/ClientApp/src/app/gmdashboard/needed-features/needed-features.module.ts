import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../../material';

import { NeededFeaturesComponent } from './needed-features.component';



@NgModule({
  declarations: [NeededFeaturesComponent],
  imports: [
    CommonModule,
    RouterModule,
    DemoMaterialModule
  ],
  exports: [
    NeededFeaturesComponent
  ]
})
export class NeededFeaturesModule { }
