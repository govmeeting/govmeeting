import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from '../material';
import { LayoutModule } from '@angular/cdk/layout';

import { AboutModule } from './about/about.module';
import { VolunteerModule } from './volunteer/volunteer.module';
import { HomeModule } from './home/home.module';

import { SampleCardComponent } from './sample-card/sample-card.component';
import { GMDashboardComponent } from './gmdashboard.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    AboutModule,
    VolunteerModule,
    HomeModule
    ],
  declarations: [
    SampleCardComponent,
    GMDashboardComponent
  ],
  exports: [
    GMDashboardComponent,
  ]
})
export class GmDashboardModule { }
