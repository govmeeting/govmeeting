import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms'
import { DropdownComponent } from './dropdown/dropdown.component';
import { MyhighlightDirective } from './myhighlight/myhighlight.directive';

@NgModule({
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
  declarations: [
    DropdownComponent,
    MyhighlightDirective,
  ],
  exports: [
    DropdownComponent,
    MyhighlightDirective,
  ]
})
export class SharedModule { }
