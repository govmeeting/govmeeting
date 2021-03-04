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
import { AmchartsModule } from './features/charts/charts.module';
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
//import { AppInitModule } from './appinit/appinit.module';

// services
import { EditTranscriptService } from './features/edittranscript/edittranscript.service';
import { EditTranscriptServiceStub } from './features/edittranscript/edittranscript.service-stub';
import { ViewTranscriptService } from './features/viewtranscript/viewtranscript.service';
import { ViewTranscriptServiceStub } from './features/viewtranscript/viewtranscript.service-stub';
import { ChatService } from './features/chat/chat.service';
import { DataFactoryService } from './work_experiments/datafake/data-factory.service';
import { RegisterGovBodyService } from './features/register-gov-body/register-gov-body.service';

// Swagger API
// import { ViewMeetingClient, EditMeetingClient, GovLocationClient, GovbodyClient } from './apis/swagger-api';
import { GovLocationClient, GovbodyClient } from './apis/api.generated.clients';

// EXPERIMENTS
import { PopupComponent } from './work_experiments/popup/popup.component';
import { DataFakeService } from './work_experiments/datafake/data-fake.service';
// import { loadConfiguration } from './work_experiments/configuration/loadConfiguration';
// import { ConfigService } from './work_experiments/configuration/config.service';
import { ShoutoutsComponent } from './work_experiments/shoutouts/shoutouts';

////////////////////////////////////
import { AppInitService } from './appinit/appinit.service';
import { MyServiceManagerModule } from "./appinit/my-service-manager.module";
export function pingFactory(appInitService: AppInitService) {
  return () => appInitService.pingServer();
}
////////////////////////////////////

// const isAspServerRunning = AppInitService.isWebServerRunning();
let isAspServerRunning = false; // Is the Asp.Net server running?
const isBeta = false; // Is this the beta release version?
const isLargeEditData = false; // Are we using the large data for EditTranscript? (Little Falls, etc.)

//function useServer() {
//  // Use value if specified in environment file.
//  if (environment.useServer != null) {
//    return environment.useServer;
//  }
//  // Otherwise use server if it is running.
//  let x = AppInitService.isWebServerRunning();

//  const wait = (ms) => new Promise((resolve) => setTimeout(resolve, ms));

//  function failureCallback() {
//    console.log('This is failure callback');
//  }

//  wait(4 * 1000)
//    .then(() => {
//      console.log('waited for 4 seconds');
//      throw new Error('error occurred');
//    })
//    .catch(() => {
//      failureCallback();
//    });

//  wait(2 * 1000).then(() => console.log('waited for 2 seconds'));

//  isAspServerRunning = !!x;
//  //let y = !x;
//  //isAspServerRunning = !y;
//  console.log('useServer=' + isAspServerRunning);
//  return isAspServerRunning;
//}

@NgModule({
  imports: [
    // /////////////// external //////////////
    RouterModule.forRoot([]),
    CommonModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    FormsModule,
    ReactiveFormsModule,
    NgMaterialMultilevelMenuModule,
    HttpClientModule,
    //////////////////////////////////////////
    MyServiceManagerModule.forRoot(),
    //////////////////////////////////////////

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
    AmchartsModule,
    FeaturesModule
  //  AppInitModule,
  ],
  declarations: [AppComponent, DashMainComponent, ShoutoutsComponent, PopupComponent, FetchDataComponent],
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
    AppData,
    ////////////////////////////////////////////////////
    // our APP_INITIALIZER must be imported on our root module too
    {
      provide: APP_INITIALIZER,
      useFactory: pingFactory,
      deps: [AppInitService],
      multi: true
    },
    //////////////////////////////////////////////////////
    {
      provide: AppData,
      useValue: { isAspServerRunning, isBeta, isLargeEditData },
      // The window method works for reading config setting from index.html. We can define APP_DATA in index.html.
      // useValue: window['APP_DATA']    // Get settings from html
    },

    // If you use the stubs for the following services, they will not call the Asp.Net server,
    // but will instead return static data.

    {
      provide: EditTranscriptService,
      useClass: isAspServerRunning ? EditTranscriptService : EditTranscriptServiceStub,
      // useClass: useServer() ? EditTranscriptService : EditTranscriptServiceStub,
      //  useClass: EditTranscriptServiceStub,
    },
    {
      provide: ViewTranscriptService,
      useClass: isAspServerRunning ? ViewTranscriptService: ViewTranscriptServiceStub
      // useClass: useServer() ? ViewTranscriptService: ViewTranscriptServiceStub
      //  useClass: ViewTranscriptServiceStub,
    },
    {
      provide: RegisterGovBodyService,
      useClass: RegisterGovBodyService,
      deps: [GovbodyClient, GovLocationClient],
    },
    ChatService,
    DataFactoryService,
    DataFakeService,
    UserSettingsService,

    // Swagger API
    // ViewMeetingClient,
    // EditMeetingClient,
    GovLocationClient,
    GovbodyClient,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
