/////////////////// Modules - external ///////////////////////////////////
import { APP_INITIALIZER } from '@angular/core';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { FlexLayoutModule } from "@angular/flex-layout";
import { HttpClientModule, HttpClient } from '@angular/common/http';
// import { map } from 'rxjs/operators';
// import { Observable, ObservableInput, of } from 'rxjs';
// import { catchError } from 'rxjs/operators/catchError.js';

/////////////////// Modules - internal ///////////////////////////////////
import { AppRoutingModule } from './app-routing.module';
import { DemoMaterialModule } from './material';
import { ChatModule } from './chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { AboutProjectModule } from './about-project/about-project.module';
import { VirtualMeetingModule } from './virtual-meeting/virtual-meeting-module';
import { DashboardModule } from './dashboard/dashboard.module';
import { ViewMeetingModule } from './viewmeeting/viewmeeting.module';
import { AddtagsModule } from './addtags/addtags.module';
import { FixasrModule } from './fixasr/fixasr.module';
import { FixTagViewModule } from './fixtagview/fixtagview.module';

import { SharedModule } from './shared/shared.module';
import { TestingModule } from './testing/testing.module';
import { SidenavMenuModule } from './sidenav/sidenav-menu-module';
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
import { FixtagviewService } from './fixtagview/fixtagview.service';
import { FixtagviewServiceStub } from './fixtagview/fixtagview.service-stub';
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from './testing/data-factory.service';
import { DataFakeService } from './testing/data-fake.service';
import { ConfigService } from './configuration/config.service';
import { UserSettingsService, UserSettings, LocationType } from './user-settings.service';

/////////////////// Components ///////////////////////////////////

import { AppComponent } from './app.component';
import { DashMainComponent } from './dashboard/dash-main/dash-main';
import { ShoutoutsComponent } from './shoutouts/shoutouts';
// import { DashFooterComponent } from './dash-footer/dash-footer';
import { RegisterComponent } from './register/register';
import { GovInfoComponent } from './gov-info/gov-info.component';
import { BillsComponent } from './bills/bills.component';
import { MeetingsComponent } from './meetings/meetings.component';
import { NewsComponent } from './news/news.component';

import { AppData } from './appdata';
import { CalendarComponent } from './calendar/calendar.component';
import { PopupComponent } from './popup/popup.component';
import { NotesComponent } from './notes/notes.component';
import { MinutesComponent } from './minutes/minutes.component';
import { AlertsComponent } from './alerts/alerts.component';
import { WorkitemsComponent } from './workitems/workitems.component';
import { IssuesComponent } from './issues/issues.component';
import { OfficialsComponent } from './officials/officials.component';
// import { CalendarComponent } from './calendar/calendar';

import { loadConfiguration } from './configuration/loadConfiguration';

let isAspServerRunning = false;

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
    HttpClientModule,

    /////////////// internal //////////////
    ViewMeetingModule,
    AddtagsModule,
    FixasrModule,
    FixTagViewModule,
    SharedModule,
    FlexLayoutModule,
    AboutProjectModule,
    AppRoutingModule,
    DashboardModule,
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
    // DashFooterComponent,
    ShoutoutsComponent,
    RegisterComponent,
    GovInfoComponent,
    BillsComponent,
    MeetingsComponent,
    NewsComponent,
    CalendarComponent,
    PopupComponent,
    NotesComponent,
    MinutesComponent,
    AlertsComponent,
    WorkitemsComponent,
    IssuesComponent,
    OfficialsComponent
    // CalendarComponent,

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
    // {
      // This loads the ConfigureService with the contents of assets/config.json
      // Uses APP_INITIALIZER forces the app to wait until the loading is complete.
    //   provide: APP_INITIALIZER,
    //   useFactory: loadConfiguration,
    //   deps: [
    //     HttpClient,
    //     ConfigService
    //   ],
    //   multi: true
    // },
    ErrorHandlingService,
    AppData,
    {
      provide: AppData,
      // TODO - Read APP_DATA from the html.
      // useValue: window['APP_DATA']    // Get settings from html
      useValue: { isAspServerRunning: isAspServerRunning },
    },

    // If you use the stubs for these services, they will not call the Asp.Net server,
    // but will instead return static data.
    { provide: ViewMeetingService, useClass: isAspServerRunning ? ViewMeetingService : ViewMeetingServiceStub },
    { provide: AddtagsService, useClass: isAspServerRunning ? AddtagsService : AddtagsServiceStub },
    { provide: FixasrService, useClass: isAspServerRunning ? FixasrService : FixasrServiceStub },
    { provide: FixtagviewService, useClass: isAspServerRunning ? FixtagviewService : FixtagviewServiceStub },

    // { provide: ViewMeetingService, useClass: ViewMeetingServiceStub },
    // { provide: AddtagsService, useClass: AddtagsServiceStub },
    // { provide: FixasrService, useClass: FixasrServiceStub },


    ChatService,
    MessagingService,
    DataFactoryService,
    DataFakeService,
    UserSettingsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {

 }
