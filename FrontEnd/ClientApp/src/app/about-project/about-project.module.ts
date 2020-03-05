import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../material';

import { PurposeComponent } from './purpose/purpose';
import { VolunteerComponent } from './volunteer/volunteer';
import { OverviewComponent } from './overview/overview';
import { AutoProcessingComponent } from './auto-processing/auto-processing';
import { ManualProcessingComponent } from './manual-processing/manual-processing';
import { WorkflowComponent } from './workflow/workflow';
import { DeveloperNotesComponent } from './developer-notes/developer-notes'

@NgModule({
  declarations: [
    PurposeComponent,
    VolunteerComponent,
    OverviewComponent,
    AutoProcessingComponent,
    ManualProcessingComponent,
    WorkflowComponent,
    DeveloperNotesComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    DemoMaterialModule
  ],
  exports: [
    DemoMaterialModule,
  ]
})
export class AboutProjectModule { }
