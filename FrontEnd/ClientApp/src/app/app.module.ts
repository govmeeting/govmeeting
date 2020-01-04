// from app.module.ts
import { FlexLayoutModule } from "@angular/flex-layout";
import { ViewMeetingModule } from './viewmeeting/viewmeeting.module';
import { AddtagsModule } from './addtags/addtags.module';
import { FixasrModule } from './fixasr/fixasr.module';
import { SharedModule } from './shared/shared.module';
import { ErrorHandlingService } from './shared/error-handling/error-handling.service';
import { ViewMeetingService } from './viewmeeting/viewmeeting.service';
import { ViewMeetingServiceStub } from './viewmeeting/viewmeeting.service-stub';
import { AddtagsService } from './addtags/addtags.service';
import { AddtagsServiceStub } from './addtags/addtags.service-stub';
import { FixasrService } from './fixasr/fixasr.service';
import { FixasrServiceStub } from './fixasr/fixasr.service-stub';
import { AppData } from './appdata';
import { AppRoutingModule } from './app-routing.module';

// Modules - external
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';

// Modules - internal
import { DemoMaterialModule } from './material';
import { ChatModule } from './chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { AboutProjectModule } from './about-project/about-project.module';
import { VirtualMeetingModule } from './virtual-meeting/virtual-meeting-module';
import { DashCardsModule } from './dash-cards/dash-cards.module';

/////////////////// Components ///////////////////////////////////

// Dashboard container
import { AppComponent } from './app.component';


// Main Container - contains small and large cards
// import { DashMainComponent } from './dash-main/dash-main';
import { MainContentComponent } from './dash-main/dash-main';

import { ShoutoutsComponent } from './shoutouts/shoutouts';

import { DashFooterComponent } from './dash-footer/dash-footer';

//////////////////////////////////////// Services /////////////////////////////////////
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from './testing/data-factory.service';
import { DataFakeService } from './testing/data-fake.service';

// import { AmchartsModule } from './amcharts/amcharts.module';
// import { PieChartComponent } from './amcharts/pie-chart/pie-chart';
// import { BarChartComponent } from './amcharts/bar-chart/bar-chart';

import { TestingModule } from './testing/testing.module';
import { SidenavMenuModule } from './dash-sidenav/sidenav-menu/sidenav-menu-module';
import { RegisterComponent } from './register/register';
import { OrganizationComponent } from './organization/organization';
// import { TopHeaderComponent } from './header/top-header/top-header/top-header';
// import { UserDropdownComponent } from './header/top-header/user-dropdown/user-dropdown';

// import { HeaderModule } from './header/header.module';
// import { UserdropdownModule } from './userdropdown/userdropdown.module';
import { HeaderModule } from './header/header.module';
import { GovInfoComponent } from './gov-info/gov-info.component';
import { BillsComponent } from './bills/bills.component';
import { MeetingsComponent } from './meetings/meetings.component';
import { NewsComponent } from './news/news.component';

const _isAspServerRunning = true;


@NgModule({
  imports: [
	// from app.module.ts
    ViewMeetingModule,
    AddtagsModule,
    FixasrModule,
    SharedModule,
    FlexLayoutModule,
    AboutProjectModule,
    AppRoutingModule,
    // RouterModule.forRoot([]),


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
    DashCardsModule,
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
    AppComponent,
    // TopHeaderComponent,
    // UserDropdownComponent,

    // DashMainComponent,
    MainContentComponent,

    DashFooterComponent,

    ShoutoutsComponent,
    RegisterComponent,
    OrganizationComponent,
    GovInfoComponent,
    BillsComponent,
    MeetingsComponent,
    NewsComponent
  ],
  exports: [
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
	// from app.module.ts
    ErrorHandlingService,
    AppData,
    {
      provide: AppData,
      // TODO - Read APP_DATA from the html.
      // useValue: window['APP_DATA']    // Get settings from html
      useValue: { isAspServerRunning: _isAspServerRunning },
    },

    // If you use the stubs for these services, it will not call the Asp.Net
    // server , but will instead return static data.
    { provide: ViewMeetingService, useClass: _isAspServerRunning ? ViewMeetingService : ViewMeetingServiceStub },
    { provide: AddtagsService, useClass: _isAspServerRunning ? AddtagsService : AddtagsServiceStub },
    { provide: FixasrService, useClass: _isAspServerRunning ? FixasrService : FixasrServiceStub },

    ChatService,
    MessagingService,
    DataFactoryService,
    DataFakeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
