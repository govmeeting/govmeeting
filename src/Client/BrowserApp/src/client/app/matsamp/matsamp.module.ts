// import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MaterialModule } from '@angular/material';
import { MatsampRoutingModule } from './matsamp-routing.module';
import { MatsampComponent } from './matsamp.component';

// Todo - I get the following error in the F12 console window in Chrome:
//   material.umd.js:3258 Could not find HammerJS. Certain Angular Material components may not work correctly.

@NgModule({
  declarations: [
    MatsampComponent
  ],
  imports: [
    // BrowserModule,
    CommonModule,
    FormsModule,
    HttpModule,
    MatsampRoutingModule,
    MaterialModule.forRoot()
  ],
  providers: [],
})
export class MatsampModule { }
