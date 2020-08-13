import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
// import { ReactiveFormsModule } from '@angular/forms'

import { EditTranscriptComponent } from './edittranscript';
import { TalksComponent } from './talks/talks';
import { TopicsComponent } from './topics/topics';
import { SectionsComponent } from './sections/sections';
import { SharedModule } from '../../common/common.module';
import { VideoModule } from '../../common/video/video.module';

@NgModule({
  declarations: [EditTranscriptComponent, TalksComponent, TopicsComponent, SectionsComponent],

  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    // ReactiveFormsModule
    VideoModule,
    SharedModule,
  ],

  exports: [EditTranscriptComponent],
})
export class EditTranscriptModule {}
