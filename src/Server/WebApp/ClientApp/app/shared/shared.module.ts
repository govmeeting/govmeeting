import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms'
import { DropdownComponent } from './dropdown/dropdown.component';
import { MyhighlightDirective } from './myhighlight/myhighlight.directive';
import { TestcompComponent } from './testcomp/testcomp.component';

@NgModule({
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
  declarations: [
    DropdownComponent,
    MyhighlightDirective,
    TestcompComponent
  ],
  exports: [
    DropdownComponent,
    MyhighlightDirective,
    TestcompComponent
  ]
})
export class SharedModule { }
