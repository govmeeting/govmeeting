// import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MaterialModule } from '@angular/material';
import { FixasrRoutingModule } from './fixasr-routing.module';
import { FixasrComponent } from './fixasr.component';
import { VideoModule } from '../video/video.module';

//import {CommonModule} from "@angular/common";  // Add this


@NgModule({
  declarations: [
    FixasrComponent
  ],
  imports: [
    CommonModule,
    // BrowserModule,
    FormsModule,
    HttpModule,
    VideoModule,
    FixasrRoutingModule,
    MaterialModule.forRoot()
  ],
  providers: [],
})
export class FixasrModule { }
