import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { VideoComponent } from './video.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'video', component: VideoComponent }
    ])
  ],
  exports: [RouterModule]
})
export class VideoRoutingModule { }
