import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../material';

// Small Cards
import { SmallCardsComponent } from './small-cards/small-cards';
import { SmallCardComponent } from './small-cards/small-card/small-card';

// Large Cards
import { LargeCardsComponent } from './large-cards/large-cards';
import { LargeCardComponent } from './large-cards/large-card/large-card';



@NgModule({
  declarations: [
    SmallCardsComponent,
    SmallCardComponent,
    LargeCardsComponent,
    LargeCardComponent
  ],
  imports: [
    CommonModule,
    DemoMaterialModule
  ],
  exports: [
    SmallCardsComponent,
    SmallCardComponent,
    LargeCardsComponent,
    LargeCardComponent
  ]
})
export class CardsModule { }
