// Modules - external
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';

// Modules - internal
import { DemoMaterialModule } from '../material';
import { ChatModule } from './chat/module';
import { ConversationModule } from './conversation/module';
import { AboutProjectModule } from '../about-project/module';
import { VirtualMeetingModule } from './virtual-meeting/module';
import { CardsModule } from './cards/module';

/////////////////// Components ///////////////////////////////////

// Dashboard container
import { DashboardComponent } from './component';

// Top Header
import { TopHeaderComponent } from './dash-header/top-header/top-header/component';
import { DashSearchComponent } from './dash-header/top-header/dash-search/component';
import { UserDropdownComponent } from './dash-header/top-header/user-dropdown/component';

// Main Header
import { MainHeaderComponent } from './dash-header/main-header/main-header/component';
import { MainWelcomeComponent } from './dash-header/main-header/main-welcome/component';
import { FastFactsComponent } from './dash-header/main-header/fast-facts/component';
import { FastFactComponent } from './dash-header/main-header/fast-fact/component';

// Main Container - contains small and large cards
import { DashMainComponent } from './dash-main/component';
import { MainContentComponent } from './dash-main/main-content/component';

// Small Cards
// import { SmallCardsComponent } from './small-cards/component';
// import { SmallCardComponent } from './small-cards/small-card/component';

// // Large Cards
// import { LargeCardsComponent } from './large-cards/component';
// import { LargeCardComponent } from './large-cards/large-card/component';

import { ShoutoutsComponent } from './shoutouts/component';

import { DashFooterComponent } from './dash-footer/component';

// Sidenav
// import { SidenavHeaderComponent } from './dash-sidenav/component';
// import { SidenavComponent } from './dash-sidenav/sidenav-container/component';
import { SidenavMenuTestComponent } from './dash-sidenav/sidenav-menu-test/component'

//////////////////////////////////////// Services /////////////////////////////////////
import { ChatService } from './chat/service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from '../services/data-factory.service';
import { DataFakeService } from '../services/data-fake.service';

// import { AmchartsModule } from './amcharts/amcharts.module';
// import { PieChartComponent } from './amcharts/pie-chart/pie-chart.component';
// import { BarChartComponent } from './amcharts/bar-chart/bar-chart.component';

import { TestingModule } from '../testing/module';
// import { SidenavMenu4Component } from './dash-sidenav/sidenav-menu4/sidenav-menu4.component';
import { SidenavMenuModule } from './dash-sidenav/sidenav-menu/module';
import { RegisterComponent } from './register/component';
import { OrganizationComponent } from './organization/organization.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    FormsModule,
    ReactiveFormsModule,
    NgMaterialMultilevelMenuModule,

    CardsModule,
    ChatModule,
    ConversationModule,
    AboutProjectModule,
    // AmchartsModule,
    TestingModule,
    SidenavMenuModule,
    VirtualMeetingModule
    ],
  declarations: [
    DashboardComponent,

    TopHeaderComponent,
    DashSearchComponent,
    UserDropdownComponent,

    MainHeaderComponent,
    MainWelcomeComponent,
    FastFactsComponent,
    FastFactComponent,

    DashMainComponent,
    MainContentComponent,

    // SmallCardsComponent,
    // SmallCardComponent,

    // LargeCardsComponent,
    // LargeCardComponent,

    ShoutoutsComponent,

    DashFooterComponent,

    // SidenavHeaderComponent,
    // SidenavComponent,
    SidenavMenuTestComponent,
    RegisterComponent,
    // SidenavMenu4Component

    OrganizationComponent
  ],
  exports: [
    DashboardComponent,

    // The exports below are just for testing that compnent in app.component.html
    // SmallCardsComponent,
    // SmallCardComponent,
    TopHeaderComponent,
    DashSearchComponent,
    UserDropdownComponent,
    // SidenavHeaderComponent,
    // SidenavComponent,
    // LargeCardComponent,
    // PieChartComponent,
    // BarChartComponent
  ],
  providers: [
    ChatService,
    MessagingService,
    DataFactoryService,
    DataFakeService
  ]
})
export class DashboardModule { }
