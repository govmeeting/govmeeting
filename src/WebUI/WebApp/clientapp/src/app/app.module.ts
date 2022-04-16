import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// from gm
// import { FlexLayoutModule } from '@angular/flex-layout';
import { DemoMaterialModule } from './common/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidenavMenuModule } from './sidenav/sidenav-menu-module';
import { HeaderModule } from './header/header.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { AboutProjectModule } from './about-project/about-project.module';

import { ChatService } from './features/chat/chat.service';
import { ErrorHandlingService } from './common/error-handling/error-handling.service';

import { EditTranscriptServiceReal } from './features/edittranscript/edittranscript.service-real';
import { EditTranscriptServiceStub } from './features/edittranscript/edittranscript.service-stub';
import { EditTranscriptService } from './features/edittranscript/edittranscript.service';

import { ViewTranscriptServiceReal } from './features/viewtranscript/viewtranscript.service-real';
import { ViewTranscriptServiceStub } from './features/viewtranscript/viewtranscript.service-stub';
import { ViewTranscriptService } from './features/viewtranscript/viewtranscript.service';

import { RegisterGovBodyService } from './features/register-gov-body/register-gov-body.service';
import { RegisterGovBodyServiceStub } from './features/register-gov-body/register-gov-body.service-stub';
import { RegisterGovBodyServiceReal } from './features/register-gov-body/register-gov-body.service-real';


// const isAspServerRunning = environment.useServer; // Is the Asp.Net server running?
const isAspServerRunning = false;

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    // AppRoutingModule.forRoot([]),
    // RouterModule.forRoot([], { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule,
    //// from gm
    // FlexLayoutModule,
    DemoMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SidenavMenuModule,
    HeaderModule,
    DashboardModule,
    AboutProjectModule,
],
  providers: [
    ChatService,
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
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
