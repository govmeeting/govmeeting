import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { APP_BASE_HREF } from '@angular/common';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { AboutModule } from './about/about.module';
import { HomepageModule } from './homepage/homepage.module';
import { AddtagsModule } from './addtags/addtags.module';
import { MeetingModule } from './meeting/meeting.module';
import { FixasrModule } from './fixasr/fixasr.module';
import { MatsampModule } from './matsamp/matsamp.module';
import { VideoModule } from './video/video.module';
import { SharedModule } from './shared/shared.module';

@NgModule({
  imports: [BrowserModule, HttpModule, AppRoutingModule,
     AboutModule, HomepageModule, AddtagsModule, MeetingModule, FixasrModule, MatsampModule,
      VideoModule, SharedModule.forRoot()],
  declarations: [AppComponent],
  providers: [{
    provide: APP_BASE_HREF,
    useValue: '<%= APP_BASE %>'
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
