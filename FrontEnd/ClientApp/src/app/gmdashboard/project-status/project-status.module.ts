import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../../material';

import { ProjectStatusComponent } from './project-status.component';



@NgModule({
  declarations: [ProjectStatusComponent],
  imports: [
    CommonModule,
    DemoMaterialModule
  ],
  exports: [
    ProjectStatusComponent
  ]
})
export class ProjectStatusModule { }
