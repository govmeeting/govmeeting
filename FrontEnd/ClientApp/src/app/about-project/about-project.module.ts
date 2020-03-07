import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../material';
import { HttpClientModule } from '@angular/common/http'
// import { NgxMdModule } from 'ngx-md';
import { MarkdownModule } from 'ngx-markdown';

import { AboutComponent } from './about-project';
import { PurposeComponent } from './purpose/purpose';
import { VolunteerComponent } from './volunteer/volunteer';
import { OverviewComponent } from './overview/overview';
import { WorkflowComponent } from './workflow/workflow';
import { Dev1Component } from './dev-1/dev-1';
import { Dev2Component } from './dev-2/dev-2';
import { Dev3Component } from './dev-3/dev-3'
import { Dev4Component } from './dev-4/dev-4'
import { Dev5Component } from './dev-5/dev-5'

@NgModule({
  declarations: [
    AboutComponent,
    PurposeComponent,
    VolunteerComponent,
    OverviewComponent,
    WorkflowComponent,
    Dev1Component,
    Dev2Component,
    Dev3Component,
    Dev4Component,
    Dev5Component
  ],
  imports: [
    CommonModule,
    RouterModule,
    DemoMaterialModule,
    HttpClientModule,
    MarkdownModule.forRoot()
    // NgxMdModule.forRoot()
  ],
  exports: [
    DemoMaterialModule,
  ]
})
export class AboutProjectModule { }
