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

// services
import { ChatService } from './features/chat/chat.service';
import { DataFactoryService } from './work_experiments/datafake/data-factory.service';

// Swagger API
import { GovLocationClient, GovbodyClient } from './apis/api.generated.clients';

// EXPERIMENTS
import { PopupComponent } from './work_experiments/popup/popup.component';
import { DataFakeService } from './work_experiments/datafake/data-fake.service';
// import { loadConfiguration } from './work_experiments/configuration/loadConfiguration';
// import { ConfigService } from './work_experiments/configuration/config.service';
import { ShoutoutsComponent } from './work_experiments/shoutouts/shoutouts';

///// Initialization service and ServiceManager Module
import { AppInitService } from './appinit/appinit.service';
import { ServiceManagerModule } from './appinit/service-manager.module';
export function pingFactory(appInitService: AppInitService) {
  return () => appInitService.pingServer();

}

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
    ServiceManagerModule.forRoot(),
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
    FeaturesModule,
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
    //AppData,
    // The APP_INITIALIZER runs before application start.
    // It checks if the server is running. ServiceManager uses its result
    // to decide whether to provide real or stub API services.
    {
      provide: APP_INITIALIZER,
      useFactory: pingFactory,
      deps: [AppInitService],
      multi: true,
    },
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
