import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { MeetingModule } from './meeting/meeting.module'
import { AddtagsModule } from './addtags/addtags.module'
import { FixasrModule } from './fixasr/fixasr.module'
import { SharedModule } from './shared/shared.module'
import { HomeModule } from './home/home.module';
import { AboutModule } from './about/about.module';
import { MatsampModule } from './matsamp/matsamp.module';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';

import { AppData } from './appdata';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HomeModule,
    AboutModule,
    MeetingModule,
    AddtagsModule,
    FixasrModule,
    MatsampModule,
    SharedModule
  ],
  exports: [
  ],
  providers: [AppData,
    {
      provide: AppData,
      useValue: window['APP_DATA']
    }
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
