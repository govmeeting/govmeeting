import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserDropdownComponent } from './user-dropdown/component';

// These were prior experiments. We may still want to include
//  the welcome, search and fastfacts components in the header.

// import { TopHeaderComponent } from './top-header/top-header/component';
// import { DashSearchComponent } from './top-header/dash-search/component';
// import { MainHeaderComponent } from './main-header/main-header/component';
// import { MainWelcomeComponent } from './main-header/main-welcome/component';
// import { FastFactsComponent } from './main-header/fast-facts/component';
// import { FastFactComponent } from './main-header/fast-fact/component';


@NgModule({
  declarations: [
    UserDropdownComponent
    // TopHeaderComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    UserDropdownComponent

    // TopHeaderComponent,
    // DashSearchComponent,
    // MainHeaderComponent,
    // MainWelcomeComponent,
    // FastFactsComponent,
    // FastFactComponent,
  ]
})
export class HeaderModule { }
