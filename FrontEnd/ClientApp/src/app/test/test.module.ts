import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestComponent } from './test.component';
import { DemoMaterialModule } from '../material';

@NgModule({
  declarations: [TestComponent],
  imports: [
    CommonModule,
    DemoMaterialModule
  ],
  exports: [ TestComponent ]
})
export class TestModule { }
