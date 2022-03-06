/////////////////// Modules - external ///////////////////////////////////
import { NgModule, LOCALE_ID } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

import { FetchDataComponent } from './fetch-data/fetch-data.component';

// APP
import { AppRoutingModule } from './app-routing.module';
import { AboutProjectModule } from './about-project/about-project.module';
import { AppComponent } from './app.component';
import { AppData } from './appdata';

// dashboard
import { DashboardModule } from './dashboard/dashboard.module';
import { DashMainComponent } from './dashboard/dash-main/dash-main';

// features
// These modules are used in the dashboard mat-cards
// You can change which cards are displayed by editing dashboard/dash-main/dash-main.html.
import { FeaturesModule } from './features/features.module';
import { EditTranscriptModule } from './features/edittranscript/edittranscript.module';
import { ViewTranscriptModule } from './features/viewtranscript/viewtranscript.module';
import { VirtualMeetingModule } from './features/virtual-meeting/virtual-meeting-module';
import { ChatModule } from './features/chat/chat.module';
// import { AmchartsModule } from './features/charts/charts.module';
import { DatafakeModule } from './work_experiments/datafake/datafake.module';

// sidenav
import { SidenavMenuModule } from './sidenav/sidenav-menu-module';

// header
import { HeaderModule } from './header/header.module';

// common
import { SharedModule } from './common/common.module';
import { ErrorHandlingService } from './common/error-handling/error-handling.service';
import { UserSettingsService, UserSettings, LocationType } from './common/user-settings.service';
import { DemoMaterialModule } from './common/material';

// services
import { ChatService } from './features/chat/chat.service';
import { DataFactoryService } from './work_experiments/datafake/data-factory.service';
// import { VideoService } from './common/video/video.service';
// import { VideoServiceStub } from './common/video/video.service-stub';
// import { VideoServiceReal } from './common/video/video.service-real';
import { EditTranscriptServiceReal } from './features/edittranscript/edittranscript.service-real';
import { EditTranscriptServiceStub } from './features/edittranscript/edittranscript.service-stub';
import { EditTranscriptService } from './features/edittranscript/edittranscript.service';
import { ViewTranscriptServiceReal } from './features/viewtranscript/viewtranscript.service-real';
import { ViewTranscriptServiceStub } from './features/viewtranscript/viewtranscript.service-stub';
import { ViewTranscriptService } from './features/viewtranscript/viewtranscript.service';
import { RegisterGovBodyService } from './features/register-gov-body/register-gov-body.service';
import { RegisterGovBodyServiceStub } from './features/register-gov-body/register-gov-body.service-stub';
import { RegisterGovBodyServiceReal } from './features/register-gov-body/register-gov-body.service-real';

// Swagger API
import { GovLocationClient, GovbodyClient } from './apis/api.generated.clients';

// EXPERIMENTS
import { PopupComponent } from './work_experiments/popup/popup.component';
import { DataFakeService } from './work_experiments/datafake/data-fake.service';
// import { loadConfiguration } from './work_experiments/configuration/loadConfiguration';
// import { ConfigService } from './work_experiments/configuration/config.service';
import { ShoutoutsComponent } from './work_experiments/shoutouts/shoutouts';

const isAspServerRunning = environment.useServer; // Is the Asp.Net server running?
const isBeta = environment.isBeta; // Use only beta release features?
const useLargeData = environment.useLargeData; // Are we using the large data (full length videos & transcripts)

@NgModule({
  imports: [
    // /////////////// external //////////////
    RouterModule.forRoot([], { relativeLinkResolution: 'legacy' }),
    CommonModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    FormsModule,
    ReactiveFormsModule,
    NgMaterialMultilevelMenuModule,
    HttpClientModule,

    // /////////////// internal //////////////
    ViewTranscriptModule,
    EditTranscriptModule,
    SharedModule,
    FlexLayoutModule,
    AboutProjectModule,
    AppRoutingModule,
    DashboardModule,
    ChatModule,
    AboutProjectModule,
    DatafakeModule,
    SidenavMenuModule,
    VirtualMeetingModule,
    HeaderModule,
    // AmchartsModule,
    FeaturesModule,
  ],
  declarations: [
    AppComponent,
    DashMainComponent,
    ShoutoutsComponent,
    PopupComponent,
    FetchDataComponent,
    // VideojsComponent,
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
    ErrorHandlingService,
    {
      provide: EditTranscriptService,
      useClass: isAspServerRunning ? EditTranscriptServiceReal : EditTranscriptServiceStub,
    },
    {
      provide: ViewTranscriptService,
      useClass: isAspServerRunning ? ViewTranscriptServiceReal : ViewTranscriptServiceStub,
    },
    {
      provide: RegisterGovBodyService,
      useClass: isAspServerRunning ? RegisterGovBodyServiceReal : RegisterGovBodyServiceStub,
    },
    // {
    //   provide: VideoService,
    //   useClass: isAspServerRunning ? VideoServiceReal : VideoServiceStub,
    // },
    {
      provide: AppData,
      useValue: { isBeta, useLargeData },
    },
    // { provide: LOCALE_ID, useValue: 'hi' },
    ChatService,
    DataFactoryService,
    DataFakeService,
    UserSettingsService,

    // Swagger API
    GovLocationClient,
    GovbodyClient,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
