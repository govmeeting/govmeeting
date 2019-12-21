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


// Main Container - contains small and large cards
import { DashMainComponent } from './dash-main/component';
import { MainContentComponent } from './dash-main/main-content/component';

import { ShoutoutsComponent } from './shoutouts/component';

import { DashFooterComponent } from './dash-footer/component';

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
import { SidenavMenuModule } from './dash-sidenav/sidenav-menu/module';
import { RegisterComponent } from './register/component';
import { OrganizationComponent } from './organization/organization.component';
// import { TopHeaderComponent } from './header/top-header/top-header/component';
// import { UserDropdownComponent } from './header/top-header/user-dropdown/component';

// import { HeaderModule } from './header/module';
// import { UserdropdownModule } from './userdropdown/userdropdown.module';
import { HeaderModule } from './header/module';


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
    SidenavMenuTestComponent,

    ShoutoutsComponent,
    RegisterComponent,
    OrganizationComponent
  ],
  exports: [
    DashboardComponent,

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
