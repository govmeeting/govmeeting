import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ToolbarComponent } from './toolbar/index';
import { NavbarComponent } from './navbar/index';
import { NameListService } from './name-list/index';
import { MyHighlightDirective } from './myhighlight/index';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownComponent } from './dropdown/index';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
  imports: [CommonModule, RouterModule
  ,ReactiveFormsModule
],
  declarations: [ToolbarComponent, NavbarComponent, MyHighlightDirective
  , DropdownComponent
  ],
  exports: [ToolbarComponent, NavbarComponent, MyHighlightDirective,
  DropdownComponent,
    CommonModule, FormsModule, RouterModule]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [NameListService]
    };
  }
}
