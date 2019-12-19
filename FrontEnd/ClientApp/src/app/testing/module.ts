import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// test small card
import { SampleContentComponent } from './sample-content/component';


@NgModule({
  declarations: [
    SampleContentComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    SampleContentComponent
  ]
})
export class TestingModule { }
