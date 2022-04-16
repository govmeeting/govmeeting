import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../common/material';

// Small Cards
import { SmallCardsComponent } from './small-cards/small-cards';
import { SmallCardComponent } from './small-cards/small-card/small-card';

// Large Cards
import { LargeCardsComponent } from './large-cards/large-cards';
import { LargeCardComponent } from './large-cards/large-card/large-card';

import { DashMainComponent } from './dash-main/dash-main';
import { DashFooterComponent } from './dash-footer/dash-footer';

import { FeaturesModule } from '../features/features.module';
import { VirtualMeetingModule } from '../features/virtual-meeting/virtual-meeting-module';
import { ChatModule } from '../features/chat/chat.module';
import { EditTranscriptModule } from '../features/edittranscript/edittranscript.module';
import { ViewTranscriptModule } from '../features/viewtranscript/viewtranscript.module';

@NgModule({
  declarations: [
    SmallCardsComponent,
    SmallCardComponent,
    LargeCardsComponent,
    LargeCardComponent,
    DashMainComponent,
    DashFooterComponent
  ],
  imports: [
    CommonModule,
    DemoMaterialModule,
    FeaturesModule,
    VirtualMeetingModule,
    ChatModule,
    EditTranscriptModule,
    ViewTranscriptModule
  ],
  exports: [
    // SmallCardsComponent,
    // SmallCardComponent,
    // LargeCardsComponent,
    // LargeCardComponent,
    // DashMainComponent,
    // DashFooterComponent,
  ],
})
export class DashboardModule {}
