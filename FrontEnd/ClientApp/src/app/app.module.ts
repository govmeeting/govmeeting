/////////////////// Modules - external ///////////////////////////////////
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { FlexLayoutModule } from "@angular/flex-layout";

/////////////////// Modules - internal ///////////////////////////////////
import { AppRoutingModule } from './app-routing.module';
import { DemoMaterialModule } from './material';
import { ChatModule } from './chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { AboutProjectModule } from './about-project/about-project.module';
import { VirtualMeetingModule } from './virtual-meeting/virtual-meeting-module';
import { DashCardsModule } from './dash-cards/dash-cards.module';
import { ViewMeetingModule } from './viewmeeting/viewmeeting.module';
import { AddtagsModule } from './addtags/addtags.module';
import { FixasrModule } from './fixasr/fixasr.module';
import { SharedModule } from './shared/shared.module';
import { TestingModule } from './testing/testing.module';
import { SidenavMenuModule } from './dash-sidenav/sidenav-menu/sidenav-menu-module';
import { HeaderModule } from './header/header.module';
// import { AmchartsModule } from './amcharts/amcharts.module';

/////////////////// Services ///////////////////////////////////
// Services
import { ErrorHandlingService } from './shared/error-handling/error-handling.service';
import { ViewMeetingService } from './viewmeeting/viewmeeting.service';
import { ViewMeetingServiceStub } from './viewmeeting/viewmeeting.service-stub';
import { AddtagsService } from './addtags/addtags.service';
import { AddtagsServiceStub } from './addtags/addtags.service-stub';
import { FixasrService } from './fixasr/fixasr.service';
import { FixasrServiceStub } from './fixasr/fixasr.service-stub';
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from './testing/data-factory.service';
import { DataFakeService } from './testing/data-fake.service';

/////////////////// Components ///////////////////////////////////

import { AppComponent } from './app.component';
import { DashMainComponent } from './dash-main/dash-main';
import { ShoutoutsComponent } from './shoutouts/shoutouts';
import { DashFooterComponent } from './dash-footer/dash-footer';
import { RegisterComponent } from './register/register';
import { GovInfoComponent } from './gov-info/gov-info.component';
import { BillsComponent } from './bills/bills.component';
import { MeetingsComponent } from './meetings/meetings.component';
import { NewsComponent } from './news/news.component';
import { ConfigComponent } from './config/config.component';

import { AppData } from './appdata';
import { CalendarComponent } from './calendar/calendar.component';
// import { CalendarComponent } from './calendar/calendar';
const _isAspServerRunning = false;

//////// for testing/////////////////////////////////

// import { PieChartComponent } from './amcharts/pie-chart/pie-chart';
// import { BarChartComponent } from './amcharts/bar-chart/bar-chart';


@NgModule({
  imports: [
    /////////////// external //////////////
    // RouterModule.forRoot([]),
    RouterModule,
    CommonModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    FormsModule,
    ReactiveFormsModule,
    NgMaterialMultilevelMenuModule,

    /////////////// internal //////////////
    ViewMeetingModule,
    AddtagsModule,
    FixasrModule,
    SharedModule,
    FlexLayoutModule,
    AboutProjectModule,
    AppRoutingModule,
    DashCardsModule,
    ChatModule,
    ConversationModule,
    AboutProjectModule,
    TestingModule,
    SidenavMenuModule,
    VirtualMeetingModule,
    HeaderModule
    // AmchartsModule,
  ],
  declarations: [
    AppComponent,
    DashMainComponent,
    DashFooterComponent,
    ShoutoutsComponent,
    RegisterComponent,
    GovInfoComponent,
    BillsComponent,
    MeetingsComponent,
    NewsComponent,
    ConfigComponent,
    CalendarComponent
    // CalendarComponent
  ],
  exports: [
    DemoMaterialModule

    // The exports below are just for testing that component standalone in app.component.html
    // SmallCardsComponent,
    // SmallCardComponent,
    // SidenavHeaderComponent,
    // SidenavComponent,
    // LargeCardComponent,
    // PieChartComponent,
    // BarChartComponent
  ],
  providers: [
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
