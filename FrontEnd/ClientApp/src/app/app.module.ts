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

// dashboard_XXX
import { DashboardModule } from './dashboard_XXX/dashboard.module';
import { DashMainComponent } from './dashboard_XXX/dash-main/dash-main';

// sidenav_XXX
import { SidenavMenuModule } from './sidenav_XXX/sidenav-menu-module';

// header_XXX
import { HeaderModule } from './header_XXX/header.module';

// common_XXX
import { SharedModule } from './common_XXX/common.module';
import { ErrorHandlingService } from './common_XXX/error-handling/error-handling.service';
import { UserSettingsService, UserSettings, LocationType } from './common_XXX/user-settings.service';
import { DemoMaterialModule } from './common_XXX/material';

// features_XXX
// These modules/components are used in the dashboard mat-cards
// You can change which cards are displayed by editing dashboard_XXX/dash-main/dash-main.html.
import { ChatModule } from './features_XXX/chat/chat.module';
import { VirtualMeetingModule } from './features_XXX/virtual-meeting/virtual-meeting-module';
import { ViewTranscriptModule } from './features_XXX/viewtranscript/viewtranscript.module';
import { EditTranscriptModule } from './features_XXX/edittranscript/edittranscript.module';
import { ViewTranscriptService } from './features_XXX/viewtranscript/viewtranscript.service';
import { ViewTranscriptServiceStub } from './features_XXX/viewtranscript/viewtranscript.service-stub';
import { EdittranscriptService } from './features_XXX/edittranscript/edittranscript.service';
import { EdittranscriptServiceStub } from './features_XXX/edittranscript/edittranscript.service-stub';
import { ChatService } from './features_XXX/chat/chat.service';
import { NotesComponent } from './features_XXX/notes/notes.component';
import { MinutesComponent } from './features_XXX/minutes/minutes.component';
import { AlertsComponent } from './features_XXX/alerts/alerts.component';
import { WorkitemsComponent } from './features_XXX/workitems/workitems.component';
import { IssuesComponent } from './features_XXX/issues/issues.component';
import { OfficialsComponent } from './features_XXX/officials/officials.component';
import { GovInfoComponent } from './features_XXX/gov-info/gov-info.component';
import { BillsComponent } from './features_XXX/bills/bills.component';
import { DatafakeModule } from './work_experiments_XXX/datafake/datafake.module';
import { DataFactoryService } from './work_experiments_XXX/datafake/data-factory.service';
import { MeetingsComponent } from './features_XXX/meetings/meetings.component';
import { NewsComponent } from './features_XXX/news/news.component';
// import { AmchartsModule } from './features_XXX/charts/charts.module';

// EXPERIMENTS
import { WorkareaComponent } from './work_experiments_XXX/workarea/workarea.component';
import { PopupComponent } from './work_experiments_XXX/popup/popup.component';
import { DataFakeService } from './work_experiments_XXX/datafake/data-fake.service';
import { ConversationModule } from './work_experiments_XXX/conversation/conversation.module';
import { ConversationService } from './work_experiments_XXX/conversation/conversation.service';
import { loadConfiguration } from './work_experiments_XXX/configuration/loadConfiguration';
import { ConfigService } from './work_experiments_XXX/configuration/config.service';
import { ShoutoutsComponent } from './work_experiments_XXX/shoutouts/shoutouts';
import { RegisterComponent } from './work_experiments_XXX/register/register';

// PRIOR_WORK
import { AddtagsModule } from './work_prior_XXX/addtags/addtags.module';
import { FixasrModule } from './work_prior_XXX/fixasr/fixasr.module';
import { AddtagsService } from './work_prior_XXX/addtags/addtags.service';
import { AddtagsServiceStub } from './work_prior_XXX/addtags/addtags.service-stub';
import { FixasrService } from './work_prior_XXX/fixasr/fixasr.service';
import { FixasrServiceStub } from './work_prior_XXX/fixasr/fixasr.service-stub';


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
