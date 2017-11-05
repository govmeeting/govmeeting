import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MaterialModule } from '../shared/material/material.module';
import { MatsampComponent } from './matsamp.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpModule,
    // MaterialModule.forRoot()   // This was used before. Do we need it?
    MaterialModule,
    BrowserAnimationsModule
  ],
  declarations: [MatsampComponent],
  exports: [MatsampComponent],
})
export class MatsampModule { }
