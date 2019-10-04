import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './material';
import { FlexLayoutModule } from "@angular/flex-layout";

import { AppComponent } from './app.component';
import { NavMenu2Component } from './nav-menu2/nav-menu2.component';

import { ErrorHandlingService } from './gmshared/error-handling/error-handling.service';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { ViewMeetingModule } from './viewmeeting/viewmeeting.module';
import { AddtagsModule } from './addtags/addtags.module';
import { FixasrModule } from './fixasr/fixasr.module';
import { GmSharedModule } from './gmshared/gmshared.module';
import { TemppagesModule } from './temppages/temppages.module';

import { ViewMeetingService } from './viewmeeting/viewmeeting.service';
import { ViewMeetingServiceStub } from './viewmeeting/viewmeeting.service-stub';
import { AddtagsService } from './addtags/addtags.service';
import { AddtagsServiceStub } from './addtags/addtags.service-stub';
import { FixasrService } from './fixasr/fixasr.service';
import { FixasrServiceStub } from './fixasr/fixasr.service-stub';
import { AppData } from './appdata';
import { TestModule } from './test/test.module';
import { GmDashboardModule } from './gmdashboard/gmdashboard.module';

// Is the Asp.Net server running
const _isAspServerRunning = true;

@NgModule({
  declarations: [
    AppComponent,
    NavMenu2Component
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    NgbModule.forRoot(),
    DemoMaterialModule,
    AppRoutingModule,
    ViewMeetingModule,
    AddtagsModule,
    FixasrModule,
    TemppagesModule,
    GmSharedModule,
    TestModule,
    FlexLayoutModule,
    GmDashboardModule
  ],
  exports: [
    //DemoMaterialModule
  ],
  providers: [
    ErrorHandlingService,

    // If you use the stubs for these services, it will not call the Asp.Net
    // server , but will instead return static data.
    { provide: ViewMeetingService, useClass: _isAspServerRunning ? ViewMeetingService : ViewMeetingServiceStub },
    { provide: AddtagsService, useClass: _isAspServerRunning ? AddtagsService : AddtagsServiceStub },
    { provide: FixasrService, useClass: _isAspServerRunning ? FixasrService : FixasrServiceStub },

    AppData,
    {
      provide: AppData,
      // We can read APP_DATA from the html.
      // useValue: window['APP_DATA']    // Get settings from html
      useValue: { isAspServerRunning: _isAspServerRunning },
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

