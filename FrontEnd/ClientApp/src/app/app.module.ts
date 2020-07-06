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

// APP
import { AppRoutingModule } from './app-routing.module';
import { AboutProjectModule } from './about-project/about-project.module';
import { AppComponent } from './app.component';
import { AppData } from './appdata';

// DASHBOARD
import { DashboardModule } from './DASHBOARD/dashboard.module';
import { DashMainComponent } from './DASHBOARD/dash-main/dash-main';

// SIDENAV
import { SidenavMenuModule } from './SIDENAV/sidenav-menu-module';

// HEADER
import { HeaderModule } from './HEADER/header.module';

// COMMON
import { SharedModule } from './COMMON/common.module';
import { ErrorHandlingService } from './COMMON/error-handling/error-handling.service';
import { UserSettingsService, UserSettings, LocationType } from './COMMON/user-settings.service';
import { DemoMaterialModule } from './COMMON/material';

// FEATURES
// These modules/components are used in the dashboard mat-cards
// You can change which cards are displayed by editing DASHBOARD/dash-main/dash-main.html.
import { ChatModule } from './FEATURES/chat/chat.module';
import { VirtualMeetingModule } from './FEATURES/virtual-meeting/virtual-meeting-module';
import { ViewTranscriptModule } from './FEATURES/viewtranscript/viewtranscript.module';
import { EditTranscriptModule } from './FEATURES/edittranscript/edittranscript.module';
import { ViewTranscriptService } from './FEATURES/viewtranscript/viewtranscript.service';
import { ViewTranscriptServiceStub } from './FEATURES/viewtranscript/viewtranscript.service-stub';
import { EdittranscriptService } from './FEATURES/edittranscript/edittranscript.service';
import { EdittranscriptServiceStub } from './FEATURES/edittranscript/edittranscript.service-stub';
import { ChatService } from './FEATURES/chat/chat.service';
import { NotesComponent } from './FEATURES/notes/notes.component';
import { MinutesComponent } from './FEATURES/minutes/minutes.component';
import { AlertsComponent } from './FEATURES/alerts/alerts.component';
import { WorkitemsComponent } from './FEATURES/workitems/workitems.component';
import { IssuesComponent } from './FEATURES/issues/issues.component';
import { OfficialsComponent } from './FEATURES/officials/officials.component';
import { GovInfoComponent } from './FEATURES/gov-info/gov-info.component';
import { BillsComponent } from './FEATURES/bills/bills.component';
import { DatafakeModule } from './WORK_EXPERIMENTS/datafake/datafake.module';
import { DataFactoryService } from './WORK_EXPERIMENTS/datafake/data-factory.service';
import { MeetingsComponent } from './FEATURES/meetings/meetings.component';
import { NewsComponent } from './FEATURES/news/news.component';
// import { AmchartsModule } from './FEATURES/charts/charts.module';

// EXPERIMENTS
import { WorkareaComponent } from './WORK_EXPERIMENTS/workarea/workarea.component';
import { PopupComponent } from './WORK_EXPERIMENTS/popup/popup.component';
import { DataFakeService } from './WORK_EXPERIMENTS/datafake/data-fake.service';
import { ConversationModule } from './WORK_EXPERIMENTS/conversation/conversation.module';
import { ConversationService } from './WORK_EXPERIMENTS/conversation/conversation.service';
import { loadConfiguration } from './WORK_EXPERIMENTS/configuration/loadConfiguration';
import { ConfigService } from './WORK_EXPERIMENTS/configuration/config.service';
import { ShoutoutsComponent } from './WORK_EXPERIMENTS/shoutouts/shoutouts';
import { RegisterComponent } from './WORK_EXPERIMENTS/register/register';

// PRIOR_WORK
import { AddtagsModule } from './WORK_PRIOR/addtags/addtags.module';
import { FixasrModule } from './WORK_PRIOR/fixasr/fixasr.module';
import { AddtagsService } from './WORK_PRIOR/addtags/addtags.service';
import { AddtagsServiceStub } from './WORK_PRIOR/addtags/addtags.service-stub';
import { FixasrService } from './WORK_PRIOR/fixasr/fixasr.service';
import { FixasrServiceStub } from './WORK_PRIOR/fixasr/fixasr.service-stub';


let isAspServerRunning = false;   // Is the Asp.Nnet server running?
let isBeta = false;               // Is this the beta release version?
let isLargeEditData = false;       // Are we using the large data for EditTranscript? (Little Falls, etc.)

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
    ViewTranscriptModule,
    AddtagsModule,
    FixasrModule,
    EditTranscriptModule,
    SharedModule,
    FlexLayoutModule,
    AboutProjectModule,
    AppRoutingModule,
    DashboardModule,
    ChatModule,
    ConversationModule,
    AboutProjectModule,
    DatafakeModule,
    SidenavMenuModule,
    VirtualMeetingModule,
    HeaderModule
    // AmchartsModule,
  ],
  declarations: [
    AppComponent,
    DashMainComponent,
    ShoutoutsComponent,
    RegisterComponent,
    GovInfoComponent,
    BillsComponent,
    MeetingsComponent,
    NewsComponent,
    PopupComponent,
    NotesComponent,
    MinutesComponent,
    AlertsComponent,
    WorkitemsComponent,
    IssuesComponent,
    OfficialsComponent,
    WorkareaComponent
    // CalendarComponent,

  ],
  exports: [
    DemoMaterialModule

    // The exports below are for testing the component standalone in app.component.html
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
    // EXPERIMENTAL
    // This loads the ConfigureService with the contents of assets/config.json
    // Using APP_INITIALIZER forces the app to wait until the loading is complete.
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
      useValue: { isAspServerRunning: isAspServerRunning, isBeta: isBeta, isLargeEditData: isLargeEditData },
    },

    // If you use the stubs for these services, they will not call the Asp.Net server,
    // but will instead return static data.
    { provide: ViewTranscriptService, useClass: isAspServerRunning ? ViewTranscriptService : ViewTranscriptServiceStub },
    { provide: AddtagsService, useClass: isAspServerRunning ? AddtagsService : AddtagsServiceStub },
    { provide: FixasrService, useClass: isAspServerRunning ? FixasrService : FixasrServiceStub },
    { provide: EdittranscriptService, useClass: isAspServerRunning ? EdittranscriptService : EdittranscriptServiceStub },

    // { provide: ViewTranscriptService, useClass: ViewTranscriptServiceStub },
    // { provide: AddtagsService, useClass: AddtagsServiceStub },
    // { provide: FixasrService, useClass: FixasrServiceStub },


    ChatService,
    ConversationService,
    DataFactoryService,
    DataFakeService,
    UserSettingsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {

 }
