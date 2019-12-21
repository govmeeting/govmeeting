import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../../material';

// Small Cards
import { SmallCardsComponent } from './small-cards/component';
import { SmallCardComponent } from './small-cards/small-card/component';

// Large Cards
import { LargeCardsComponent } from './large-cards/component';
import { LargeCardComponent } from './large-cards/large-card/component';



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
