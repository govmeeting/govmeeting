import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideoComponent } from './video.component';
import { VideoRoutingModule } from './video-routing.module';

import { VgCoreModule } from 'videogular2/core';
import { VgControlsModule } from 'videogular2/controls';
import { VgOverlayPlayModule } from 'videogular2/overlay-play';
import { VgBufferingModule } from 'videogular2/buffering';

@NgModule({
  imports: [
      CommonModule,
      VideoRoutingModule,
      VgCoreModule,
      VgControlsModule,
      VgOverlayPlayModule,
      VgBufferingModule
    ],
  declarations: [VideoComponent],
  exports: [VideoComponent]
})
export class VideoModule { }
