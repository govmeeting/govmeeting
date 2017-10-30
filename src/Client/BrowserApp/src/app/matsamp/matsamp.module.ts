import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatsampComponent } from './matsamp.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [MatsampComponent],
  exports: [MatsampComponent],
})
export class MatsampModule { }
