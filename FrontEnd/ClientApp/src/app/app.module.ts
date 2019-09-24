import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { MainNavComponent } from './main-nav/main-nav.component'

import { ErrorHandlingService } from './gmshared/error-handling/error-handling.service';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { ViewMeetingModule } from './viewmeeting/viewmeeting.module';
import { AddtagsModule } from './addtags/addtags.module';
import { FixasrModule } from './fixasr/fixasr.module';
import { GmSharedModule } from './gmshared/gmshared.module';
import { HomeModule } from './home/home.module';
import { AboutModule } from './about/about.module';
import { VolunteerModule } from './volunteer/volunteer.module';
import { TemppagesModule } from './temppages/temppages.module';

import { ViewMeetingService } from './viewmeeting/viewmeeting.service';
import { ViewMeetingServiceStub } from './viewmeeting/viewmeeting.service-stub';
import { AddtagsService } from './addtags/addtags.service';
import { AddtagsServiceStub } from './addtags/addtags.service-stub';
import { FixasrService } from './fixasr/fixasr.service';
import { FixasrServiceStub } from './fixasr/fixasr.service-stub';
import { AppData } from './appdata';
import { TestModule } from './test/test.module';
//import { LayoutModule } from '@angular/cdk/layout';
//import { MatToolbarModule } from '@angular/material/toolbar';
//import { MatButtonModule } from '@angular/material/button';
//import { MatSidenavModule } from '@angular/material/sidenav';
//import { MatIconModule } from '@angular/material/icon';
//import { MatListModule } from '@angular/material/list';
import { GMLayoutModule } from './gmlayout/gm-layout.module'

// Is the Asp.Net server running
const _isAspServerRunning = true;

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MainNavComponent,
    //CheckboxGroupComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    NgbModule.forRoot(),
    MaterialModule,
    AppRoutingModule,
    HomeModule,
    AboutModule,
    ViewMeetingModule,
    AddtagsModule,
    FixasrModule,
    VolunteerModule,
    TemppagesModule,
    GmSharedModule,
    TestModule,
    //LayoutModule,
    //MatToolbarModule,
    //MatButtonModule,
    //MatSidenavModule,
    //MatIconModule,
    //MatListModule,
    GMLayoutModule
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

