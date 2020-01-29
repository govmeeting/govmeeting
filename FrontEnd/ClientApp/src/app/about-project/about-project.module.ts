import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../material';

import { AboutProjectComponent } from './about-project';
import { PurposeComponent } from './purpose/purpose';
import { VolunteerComponent } from './volunteer/volunteer';
import { AboutTemplateComponent } from './about-template/about-template';
import { OverviewComponent } from './overview/overview';
import { AutoProcessingComponent } from './auto-processing/auto-processing';
import { ManualProcessingComponent } from './manual-processing/manual-processing';
import { WorkflowComponent } from './workflow/workflow';
import { ExtendGovmeetingComponent } from './extend-govmeeting/extend-govmeeting'

@NgModule({
  declarations: [
    AboutProjectComponent,
    PurposeComponent,
    VolunteerComponent,
    AboutTemplateComponent,
    OverviewComponent,
    AutoProcessingComponent,
    ManualProcessingComponent,
    WorkflowComponent,
	ExtendGovmeetingComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    DemoMaterialModule
  ],
  exports: [
    DemoMaterialModule,
    AboutProjectComponent
  ]
})
export class AboutProjectModule { }
