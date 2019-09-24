import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestComponent } from './test.component';
import { MaterialModule } from '../material';

@NgModule({
  declarations: [TestComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [ TestComponent ]
})
export class TestModule { }
