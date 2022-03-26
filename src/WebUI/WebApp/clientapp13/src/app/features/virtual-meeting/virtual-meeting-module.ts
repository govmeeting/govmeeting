import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VirtualMeetingComponent } from './virtual-meeting';

@NgModule({
  declarations: [VirtualMeetingComponent],

  imports: [CommonModule],
  exports: [VirtualMeetingComponent],
})
export class VirtualMeetingModule {}
