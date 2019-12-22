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
import { ChatModule } from './chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { AboutProjectModule } from '../about-project/about-project.module';
import { VirtualMeetingModule } from './virtual-meeting/virtual-meeting-module';
import { CardsModule } from './cards/module';

/////////////////// Components ///////////////////////////////////

// Dashboard container
import { DashboardComponent } from './dashboard';


// Main Container - contains small and large cards
import { DashMainComponent } from './dash-main/dash-main';
import { MainContentComponent } from './dash-main/main-content/main-content';

import { ShoutoutsComponent } from './shoutouts/shoutouts';

import { DashFooterComponent } from './dash-footer/dash-footer';

//////////////////////////////////////// Services /////////////////////////////////////
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from '../services/data-factory.service';
import { DataFakeService } from '../services/data-fake.service';

// import { AmchartsModule } from './amcharts/amcharts.module';
// import { PieChartComponent } from './amcharts/pie-chart/pie-chart';
// import { BarChartComponent } from './amcharts/bar-chart/bar-chart';

import { TestingModule } from '../testing/testing.module';
import { SidenavMenuModule } from './dash-sidenav/sidenav-menu/sidenav-menu-module';
import { RegisterComponent } from './register/register';
import { OrganizationComponent } from './organization/organization';
// import { TopHeaderComponent } from './header/top-header/top-header/top-header';
// import { UserDropdownComponent } from './header/top-header/user-dropdown/user-dropdown';

// import { HeaderModule } from './header/header.module';
// import { UserdropdownModule } from './userdropdown/userdropdown.module';
import { HeaderModule } from './header/header.module';


@NgModule({
  imports: [
    // external
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    FormsModule,
    ReactiveFormsModule,
    NgMaterialMultilevelMenuModule,

    // internal
    CardsModule,
    ChatModule,
    ConversationModule,
    AboutProjectModule,
    // AmchartsModule,
    TestingModule,
    SidenavMenuModule,
    VirtualMeetingModule,

    HeaderModule
    //UserdropdownModule
    ],
  declarations: [
    DashboardComponent,
    // TopHeaderComponent,
    // UserDropdownComponent,

    DashMainComponent,
    MainContentComponent,

    DashFooterComponent,

    ShoutoutsComponent,
    RegisterComponent,
    OrganizationComponent
  ],
  exports: [
    DashboardComponent,
    DemoMaterialModule

    // The exports below are just for testing that compnent in app.component.html
    // SmallCardsComponent,
    // SmallCardComponent,
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
