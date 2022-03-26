import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { ViewTranscriptComponent } from './viewtranscript';
import { BrowseComponent } from './browse/browse';
import { HeadingComponent } from './heading/heading';
import { SpeakersComponent } from './speakers/speakers';
import { TopicsComponent } from './topics/topics';
import { SharedModule } from '../../common/common.module';

@NgModule({
  imports: [CommonModule, RouterModule, HttpClientModule, SharedModule],

  declarations: [ViewTranscriptComponent, BrowseComponent, HeadingComponent, SpeakersComponent, TopicsComponent],

  exports: [ViewTranscriptComponent],
})
export class ViewTranscriptModule {}
