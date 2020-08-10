import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../common/material';

import { UserDropdownComponent } from './user-dropdown/user-dropdown';
import { HeaderComponent } from './header';

// These were from prior experiments. We may still want to include
//  the welcome, search and fastfacts components in the header.

// import { TopHeaderComponent } from './top-header/top-header/component';
// import { DashSearchComponent } from './top-header/dash-search/component';
// import { MainHeaderComponent } from './main-header/main-header/component';
// import { MainWelcomeComponent } from './main-header/main-welcome/component';
// import { FastFactsComponent } from './main-header/fast-facts/component';
// import { FastFactComponent } from './main-header/fast-fact/component';

@NgModule({
  declarations: [
    UserDropdownComponent,
    HeaderComponent,

    // TopHeaderComponent,
    // DashSearchComponent,
    // MainHeaderComponent,
    // MainWelcomeComponent,
    // FastFactsComponent,
    // FastFactComponent,
  ],
  imports: [CommonModule, DemoMaterialModule],
  exports: [
    UserDropdownComponent,
    HeaderComponent,

    // TopHeaderComponent,
    // DashSearchComponent,
    // MainHeaderComponent,
    // MainWelcomeComponent,
    // FastFactsComponent,
    // FastFactComponent,
  ],
})
export class HeaderModule {}
