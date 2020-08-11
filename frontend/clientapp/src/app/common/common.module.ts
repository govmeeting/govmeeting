import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownComponent } from './dropdown/dropdown';
import { HighlightDirective } from './myhighlight/myhighlight.directive';
// import { ErrorHandlingService } from './error-handling/error-handling.service';

@NgModule({
  imports: [ReactiveFormsModule, CommonModule],
  declarations: [
    DropdownComponent,
    HighlightDirective,
    // ErrorHandlingService
  ],
  exports: [DropdownComponent, HighlightDirective],
})
export class SharedModule {}
