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
import { ProjectStatusModule } from './project-status/project-status.module';
import { NeededFeaturesModule } from './needed-features/needed-features.module';
import { ChatModule } from '../gmdashboard/chat/chat.module';

import { ChatService } from './chat/chat.service';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    AboutModule,
    VolunteerModule,
    HomeModule,
    ProjectStatusModule,
    NeededFeaturesModule,
    ChatModule
    ],
  declarations: [
    SampleCardComponent,
    GMDashboardComponent
  ],
  exports: [
    GMDashboardComponent,
  ],
  providers: [ChatService]
})
export class GmDashboardModule { }
