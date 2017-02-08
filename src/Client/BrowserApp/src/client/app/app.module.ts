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
import { MatsampModule } from './matsamp/matsamp.module';
import { FixasrModule } from './fixasr/fixasr.module';
import { VideoModule } from './video/video.module';
//import { MaterialModule } from '@angular/material';
import { SharedModule } from './shared/shared.module';

@NgModule({
  imports: [BrowserModule, HttpModule, AppRoutingModule,
     AboutModule, HomepageModule, AddtagsModule, MeetingModule, 
      MatsampModule,
      //VideoModule,
      FixasrModule,
      SharedModule.forRoot()],
  declarations: [AppComponent],
  providers: [{
    provide: APP_BASE_HREF,
    useValue: '<%= APP_BASE %>'
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }

// Todo - Change error message that displays in F12 tools console "Report thid error at ...." to 
// our own issue page instead of mgechev/angular2-seed.
