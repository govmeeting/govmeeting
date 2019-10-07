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
import { ConversationModule } from './conversation/conversation.module';
import { FormsModule } from '@angular/forms';

import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { NavlistComponent } from './navlist/navlist.component';
import { QuickviewComponent } from './quickview/quickview.component';
import { UserDropdownComponent } from './user-dropdown/user-dropdown.component';
import { MainOverviewComponent } from './main-overview/main-overview.component';
import { YourEventsComponent } from './your-events/your-events.component';


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
    ChatModule,
    ConversationModule,
    FormsModule
    ],
  declarations: [
    SampleCardComponent,
    GMDashboardComponent,
    NavlistComponent,
    QuickviewComponent,
    UserDropdownComponent,
    MainOverviewComponent,
    YourEventsComponent
  ],
  exports: [
    GMDashboardComponent,
  ],
  providers: [
    ChatService,
    MessagingService
  ]
})
export class GmDashboardModule { }
