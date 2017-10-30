import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { MeetingModule } from './meeting/meeting.module'
import { AddtagsModule } from './addtags/addtags.module'
import { FixasrModule } from './fixasr/fixasr.module'
import { ReactiveFormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { DropdownComponent } from './shared/dropdown/dropdown.component';
import { MyhighlightDirective } from './shared/myhighlight/myhighlight.directive';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    DropdownComponent,
    MyhighlightDirective
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    MeetingModule,
    AddtagsModule,
    FixasrModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
