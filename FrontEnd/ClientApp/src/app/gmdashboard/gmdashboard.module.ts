import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
//import { GmSharedModule } from '../gmshared/gmshared.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from '../material';
import { LayoutModule } from '@angular/cdk/layout';

import { AboutModule } from '../about/about.module';
import { VolunteerModule } from '../volunteer/volunteer.module';
import { HomeModule } from '../home/home.module';



import { SampleCardComponent } from './sample-card.component';
import { GMDashboardComponent } from './gmdashboard.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    //GmSharedModule,
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
    SampleCardComponent,
    GMDashboardComponent,
    DemoMaterialModule
  ]
})
export class GmDashboardModule { }
