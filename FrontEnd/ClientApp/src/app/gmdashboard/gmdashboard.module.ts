// Modules - external
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule } from '@angular/forms';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';

// Modules - internal
import { DemoMaterialModule } from '../material';
import { ProjectStatusModule } from './project-status/project-status.module';
import { ChatModule } from '../gmdashboard/chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { AboutProjectModule } from '../about-project/about-project.module';

/////////////////// Components ///////////////////////////////////
// Unused
//import { SampleCardComponent } from './sample-card/sample-card.component';
//import { FinanceComponent } from './finance/finance.component';
//import { TestgridComponent } from './testgrid/testgrid.component';

// Dashboard container
import { GMDashboardComponent } from './gmdashboard.component';

// Top Header
import { TopHeaderComponent } from './dash-header/top-header/top-header/top-header.component';
import { DashSearchComponent } from './dash-header/top-header/dash-search/dash-search.component';
import { UserDropdownComponent } from './dash-header/top-header/user-dropdown/user-dropdown.component';

// Main Header
import { MainHeaderComponent } from './dash-header/main-header/main-header/main-header.component';
import { MainWelcomeComponent } from './dash-header/main-header/main-welcome/main-welcome.component';
import { FastFactsComponent } from './dash-header/main-header/fast-facts/fast-facts.component';
import { FastFactComponent } from './dash-header/main-header/fast-fact/fast-fact.component';

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
import { SidenavMenuComponent } from './dash-sidenav/sidenav-menu/sidenav-menu.component';
import { SidenavHeaderComponent } from './dash-sidenav/sidenav-header/sidenav-header.component';
import { SidenavComponent } from './dash-sidenav/sidenav-container/sidenav.component';
import { DashSidenav2Component } from './dash-sidenav2/dash-sidenav2.component'
import { DashSidenav3Component } from './dash-sidenav3/dash-sidenav3.component'

//////////////////////////////////////// Services /////////////////////////////////////
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from './data-factory.service';
import { DataFakeService } from './data-fake.service';
import { MainContentComponent } from './main-content/main-content.component';

import {AmchartsModule } from './amcharts/amcharts.module';
import { PieChart } from '@amcharts/amcharts4/charts';
import { PieChartComponent } from './amcharts/pie-chart/pie-chart.component';
import { BarChartComponent } from './amcharts/bar-chart/bar-chart.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    FormsModule,
    NgMaterialMultilevelMenuModule,

    ProjectStatusModule,
    ChatModule,
    ConversationModule,
    AboutProjectModule,
    AmchartsModule
    ],
  declarations: [
    //SampleCardComponent,
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
    SidenavComponent,
    MainContentComponent,
    DashSidenav2Component,
    DashSidenav3Component,

  ],
  exports: [
    GMDashboardComponent,

    // The ones below are just for testing that compnent in app.component.html
    // SmallCardsComponent,
    // SmallCardComponent,
    TopHeaderComponent,
    DashSearchComponent,
    UserDropdownComponent,
    DashSidenav2Component,
    SidenavHeaderComponent,
    SidenavComponent,
    AmguageComponent,
    MainCardComponent,
    PieChartComponent,
    BarChartComponent
  ],
  providers: [
    ChatService,
    MessagingService,
    DataFactoryService,
    DataFakeService
  ]
})
export class GmDashboardModule { }
