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
import { ChatModule } from '../dashboard/chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { AboutProjectModule } from '../about-project/about-project.module';

/////////////////// Components ///////////////////////////////////

// Dashboard container
import { DashboardComponent } from './dashboard.component';

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
import { SmallCardsComponent } from './small-cards/small-cards.component';
import { SmallCardComponent } from './small-cards/small-card/small-card.component';

// Large Cards
import { MainCardsComponent } from './main-cards/main-cards.component';
import { MainCardComponent } from './main-cards/main-card/main-card.component';
import { ShoutoutsComponent } from './shoutouts/shoutouts.component';

import { DashFooterComponent } from './dash-footer/dash-footer.component';

// Sidenav
import { SidenavHeaderComponent } from './dash-sidenav/sidenav-header/sidenav-header.component';
import { SidenavComponent } from './dash-sidenav/sidenav-container/sidenav.component';
import { SidenavMenuComponent } from './dash-sidenav/sidenav-menu/sidenav-menu.component';
import { SidenavMenu2Component } from './dash-sidenav/sidenav-menu2/sidenav-menu2.component'
import { SidenavMenu3Component } from './dash-sidenav/sidenav-menu3/sidenav-menu3.component'

//////////////////////////////////////// Services /////////////////////////////////////
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from '../services/data-factory.service';
import { DataFakeService } from '../services/data-fake.service';
import { MainContentComponent } from './main-content/main-content.component';

import { AmchartsModule } from './amcharts/amcharts.module';
import { PieChartComponent } from './amcharts/pie-chart/pie-chart.component';
// import { BarChartComponent } from './amcharts/bar-chart/bar-chart.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    FormsModule,
    NgMaterialMultilevelMenuModule,

    ChatModule,
    ConversationModule,
    AboutProjectModule,
    AmchartsModule
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

    SmallCardsComponent,
    SmallCardComponent,

    MainCardsComponent,
    MainCardComponent,
    ShoutoutsComponent,

    DashFooterComponent,

    SidenavHeaderComponent,
    SidenavComponent,
    MainContentComponent,
    SidenavMenuComponent,
    SidenavMenu2Component,
    SidenavMenu3Component,
  ],
  exports: [
    DashboardComponent,

    // The exports below are just for testing that compnent in app.component.html
    // SmallCardsComponent,
    // SmallCardComponent,
    TopHeaderComponent,
    DashSearchComponent,
    UserDropdownComponent,
    SidenavMenu2Component,
    SidenavHeaderComponent,
    SidenavComponent,
    MainCardComponent,
    PieChartComponent,
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
