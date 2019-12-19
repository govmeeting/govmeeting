import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VirtualMeetingComponent } from './component';



@NgModule({
  declarations: [VirtualMeetingComponent],
  imports: [
    CommonModule
  ],
  exports: [
    VirtualMeetingComponent
  ]
})
export class VirtualMeetingModule { }
