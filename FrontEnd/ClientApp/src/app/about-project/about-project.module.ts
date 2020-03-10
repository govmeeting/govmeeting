import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../material';
import { HttpClientModule } from '@angular/common/http'
import { MarkdownModule } from 'ngx-markdown';

import { AboutComponent } from './about-project';
// import { PurposeComponent } from './purpose/purpose';
import { VolunteerComponent } from './volunteer/volunteer';
import { OverviewComponent } from './overview/overview';
import { FlowchartsComponent } from './flowcharts/flowcharts'
// import { WorkflowComponent } from './workflow/workflow';

@NgModule({
  declarations: [
    AboutComponent,
    // PurposeComponent,
    VolunteerComponent,
    OverviewComponent,
    FlowchartsComponent
    // WorkflowComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    DemoMaterialModule,
    HttpClientModule,
    MarkdownModule.forRoot()
  ],
  exports: [
    DemoMaterialModule,
  ]
})
export class AboutProjectModule { }
