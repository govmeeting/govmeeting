/////////////////// Modules - external ///////////////////////////////////
import { APP_INITIALIZER } from '@angular/core';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule, HttpClient } from '@angular/common/http';
// import { map } from 'rxjs/operators';
// import { Observable, ObservableInput, of } from 'rxjs';
// import { catchError } from 'rxjs/operators/catchError.js';

// APP
import { AppRoutingModule } from './app-routing.module';
import { AboutProjectModule } from './about-project/about-project.module';
import { AppComponent } from './app.component';
import { AppData } from './appdata';

// dashboard
import { DashboardModule } from './dashboard/dashboard.module';
import { DashMainComponent } from './dashboard/dash-main/dash-main';

// sidenav
import { SidenavMenuModule } from './sidenav/sidenav-menu-module';

// header
import { HeaderModule } from './header/header.module';

// common
import { SharedModule } from './common/common.module';
import { ErrorHandlingService } from './common/error-handling/error-handling.service';
import { UserSettingsService, UserSettings, LocationType } from './common/user-settings.service';
import { DemoMaterialModule } from './common/material';

// features
// These modules/components are used in the dashboard mat-cards
// You can change which cards are displayed by editing dashboard/dash-main/dash-main.html.
import { ChatModule } from './features/chat/chat.module';
import { VirtualMeetingModule } from './features/virtual-meeting/virtual-meeting-module';
import { EditTranscriptModule } from './features/edittranscript/edittranscript.module';
import { EdittranscriptService } from './features/edittranscript/edittranscript.service';
import { EdittranscriptServiceStub } from './features/edittranscript/edittranscript.service-stub';
import { ViewTranscriptModule } from './features/viewtranscript/viewtranscript.module';
import { ViewTranscriptService } from './features/viewtranscript/viewtranscript.service';
import { ViewTranscriptServiceStub } from './features/viewtranscript/viewtranscript.service-stub';
import { ChatService } from './features/chat/chat.service';
import { NotesComponent } from './features/notes/notes.component';
import { MinutesComponent } from './features/minutes/minutes.component';
import { AlertsComponent } from './features/alerts/alerts.component';
import { WorkitemsComponent } from './features/workitems/workitems.component';
import { IssuesComponent } from './features/issues/issues.component';
import { OfficialsComponent } from './features/officials/officials.component';
import { GovInfoComponent } from './features/gov-info/gov-info.component';
import { BillsComponent } from './features/bills/bills.component';
import { DatafakeModule } from './work_experiments/datafake/datafake.module';
import { DataFactoryService } from './work_experiments/datafake/data-factory.service';
import { MeetingsComponent } from './features/meetings/meetings.component';
import { NewsComponent } from './features/news/news.component';
import { AmchartsModule } from './features/charts/charts.module';

// EXPERIMENTS
import { WorkareaComponent } from './work_experiments/workarea/workarea.component';
import { PopupComponent } from './work_experiments/popup/popup.component';
import { DataFakeService } from './work_experiments/datafake/data-fake.service';
import { ConversationModule } from './work_experiments/conversation/conversation.module';
import { ConversationService } from './work_experiments/conversation/conversation.service';
import { loadConfiguration } from './work_experiments/configuration/loadConfiguration';
import { ConfigService } from './work_experiments/configuration/config.service';
import { ShoutoutsComponent } from './work_experiments/shoutouts/shoutouts';
import { RegisterComponent } from './work_experiments/register/register';

const isAspServerRunning = false; // Is the Asp.Nnet server running?
const isBeta = false; // Is this the beta release version?
const isLargeEditData = false; // Are we using the large data for EditTranscript? (Little Falls, etc.)

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
    HeaderModule,
    AmchartsModule,
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
    WorkareaComponent,
    // CalendarComponent,
  ],
  exports: [
    DemoMaterialModule,

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
    // EXPERIMENTAL - trying to find a way to load config from a file and use
    //   the settings here in app.module.ts
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
      // This method works for reading config setting from index.html. We can define APP_DATA in index.html.
      // useValue: window['APP_DATA']    // Get settings from html
      useValue: { isAspServerRunning, isBeta, isLargeEditData },
    },
    {
      provide: EdittranscriptService,
      useClass: isAspServerRunning ? EdittranscriptService : EdittranscriptServiceStub,
    },

    // If you use the stubs for these services, they will not call the Asp.Net server,
    // but will instead return static data.
    {
      provide: ViewTranscriptService,
      useClass: isAspServerRunning ? ViewTranscriptService : ViewTranscriptServiceStub,
    },
    // { provide: ViewTranscriptService, useClass: ViewTranscriptServiceStub },

    ChatService,
    ConversationService,
    DataFactoryService,
    DataFakeService,
    UserSettingsService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
