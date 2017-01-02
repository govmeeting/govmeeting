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
import { SharedModule } from './shared/shared.module';

@NgModule({
  imports: [BrowserModule, HttpModule, AppRoutingModule,
     AboutModule, HomepageModule, AddtagsModule, MeetingModule, SharedModule.forRoot()],
     // AboutModule, HomepageModule, AddtagsModule, SharedModule.forRoot()],
  declarations: [AppComponent],
  providers: [{
    provide: APP_BASE_HREF,
    useValue: '<%= APP_BASE %>'
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
