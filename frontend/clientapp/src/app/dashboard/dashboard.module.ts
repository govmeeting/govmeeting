import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../common/material';

// Small Cards
import { SmallCardsComponent } from './small-cards/small-cards';
import { SmallCardComponent } from './small-cards/small-card/small-card';

// Large Cards
import { LargeCardsComponent } from './large-cards/large-cards';
import { LargeCardComponent } from './large-cards/large-card/large-card';

// import { DashMainComponent } from './dash-main/dash-main';
import { DashFooterComponent } from './dash-footer/dash-footer';

@NgModule({
  declarations: [
    SmallCardsComponent,
    SmallCardComponent,
    LargeCardsComponent,
    LargeCardComponent,
    // DashMainComponent,
    DashFooterComponent,
  ],
  imports: [CommonModule, DemoMaterialModule],

  exports: [
    SmallCardsComponent,
    SmallCardComponent,
    LargeCardsComponent,
    LargeCardComponent,
    // DashMainComponent,
    DashFooterComponent,
  ],
})
export class DashboardModule {}
