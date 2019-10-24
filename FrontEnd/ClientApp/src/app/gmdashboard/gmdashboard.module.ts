// Modules - external
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';

// Modules - internal
import { DemoMaterialModule } from '../material';
import { AboutModule } from './about/about.module';
import { VolunteerModule } from './volunteer/volunteer.module';
import { HomeModule } from './home/home.module';
import { ProjectStatusModule } from './project-status/project-status.module';
import { NeededFeaturesModule } from './needed-features/needed-features.module';
import { ChatModule } from '../gmdashboard/chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { FormsModule } from '@angular/forms';

/////////////////// Components ///////////////////////////////////
// Unused
//import { NavlistComponent } from './navlist/navlist.component';
//import { SampleCardComponent } from './sample-card/sample-card.component';
//import { FinanceComponent } from './finance/finance.component';
//import { TestgridComponent } from './testgrid/testgrid.component';

// Dashboard container
import { GMDashboardComponent } from './gmdashboard.component';

// Top Header
import { TopHeaderComponent } from './top-header/top-header/top-header.component';
import { DashSearchComponent } from './top-header/dash-search/dash-search.component';
import { UserDropdownComponent } from './top-header/user-dropdown/user-dropdown.component';

// Main Header
import { MainHeaderComponent } from './main-header/main-header/main-header.component';
import { MainWelcomeComponent } from './main-header/main-welcome/main-welcome.component';
import { FastFactsComponent } from './main-header/fast-facts/fast-facts.component';
import { FastFactComponent } from './main-header/fast-fact/fast-fact.component';

// Main Container - contains small and large cards
import { DashMainComponent } from './dash-main/dash-main.component';

// Small Cards
import { SmallCardsComponent } from './small-cards/small-cards/small-cards.component';
import { SmallCardComponent } from './small-cards/small-card/small-card.component';

// Large Cards
import { MainCardsComponent } from './main-cards/main-cards.component';
import { MainCardComponent } from './main-card/main-card.component';
import { YourEventsComponent } from './your-events/your-events.component';
import { RecentDocumentsComponent } from './recent-documents/recent-documents.component';
import { AmguageComponent } from './amguage/amguage.component';
import { ShoutoutsComponent } from './shoutouts/shoutouts.component';

import { DashFooterComponent } from './dash-footer/dash-footer.component';

// Sidenav
import { SidenavMenuComponent } from './sidenav-menu/sidenav-menu.component';
import { SidenavHeaderComponent } from './sidenav-header/sidenav-header.component';
import { SidenavComponent } from './sidenav/sidenav.component';

//////////////////////////////////////// Services /////////////////////////////////////
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from './data-factory.service';
import { DataFakeService } from './data-fake.service';


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
    //SampleCardComponent,
    //NavlistComponent,
    //FinanceComponent,
    //TestgridComponent,

    GMDashboardComponent,

    TopHeaderComponent,
    DashSearchComponent,
    UserDropdownComponent,

    MainHeaderComponent,
    MainWelcomeComponent,
    FastFactsComponent,
    FastFactComponent,

    DashMainComponent,

	SmallCardsComponent,
    SmallCardComponent,

    MainCardsComponent,
    MainCardComponent,
    YourEventsComponent,
    ShoutoutsComponent,
    RecentDocumentsComponent,
    AmguageComponent,

    DashFooterComponent,

    SidenavMenuComponent,
    SidenavHeaderComponent,
    SidenavComponent
  ],
  exports: [
    GMDashboardComponent,
  ],
  providers: [
    ChatService,
    MessagingService,
    DataFactoryService,
    DataFakeService
  ]
})
export class GmDashboardModule { }
