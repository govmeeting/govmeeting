import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MaterialModule } from '@angular/material';
import { FixasrRoutingModule } from './fixasr-routing.module';
import { FixasrComponent } from './fixasr.component';
import { VideoModule } from '../video/video.module';

@NgModule({
  declarations: [
    FixasrComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    VideoModule,
    FixasrRoutingModule,
    MaterialModule.forRoot()
  ],
  providers: [],
})
export class FixasrModule { }
