import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideoComponent } from './component';

import { VgCoreModule } from 'videogular2/core';
import { VgControlsModule } from 'videogular2/controls';
import { VgOverlayPlayModule } from 'videogular2/overlay-play';
import { VgBufferingModule } from 'videogular2/buffering';

import { VgStreamingModule } from 'videogular2/streaming';
import { VgImaAdsModule } from 'videogular2/ima-ads';

@NgModule({
  imports: [
      CommonModule,
      VgCoreModule,
      VgControlsModule,
      VgOverlayPlayModule,
      VgBufferingModule,
      VgStreamingModule,
      VgImaAdsModule
    ],
  declarations: [VideoComponent],
  exports: [VideoComponent]
})
export class VideoModule { }
