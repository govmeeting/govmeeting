import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingComponent } from './meeting.component';
import { BrowsemeetingComponent } from './browsemeeting/browsemeeting.component';
import { HeadingComponent } from './heading/heading.component';
import { SpeakersComponent } from './speakers/speakers.component';
import { TopicsComponent } from './topics/topics.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [MeetingComponent, BrowsemeetingComponent,
     HeadingComponent, SpeakersComponent, TopicsComponent]
})
export class MeetingModule { }
