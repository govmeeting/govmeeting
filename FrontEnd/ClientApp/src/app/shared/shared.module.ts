import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms'
import { DropdownComponent } from './dropdown/dropdown';
import { MyhighlightDirective } from './myhighlight/myhighlight.directive';
//import { ErrorHandlingService } from './error-handling/error-handling.service';

@NgModule({
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
  declarations: [
      DropdownComponent,
      MyhighlightDirective,
      //ErrorHandlingService
    ],
  exports: [
      DropdownComponent,
      MyhighlightDirective,
    ]
})
export class SharedModule { }
