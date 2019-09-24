import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../material';

import { CheckboxGroupComponent } from './checkbox.group.component';

@NgModule({
  declarations: [CheckboxGroupComponent],
  imports: [
    CommonModule,
    DemoMaterialModule
  ],
  exports: [CheckboxGroupComponent]
})
export class GMLayoutModule { }
