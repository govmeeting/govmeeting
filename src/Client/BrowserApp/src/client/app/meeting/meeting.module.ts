import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingComponent } from './meeting.component';
import { HeadingComponent } from './heading/heading.component';
import { BrowsemeetingComponent } from './browsemeeting/browsemeeting.component';
import { SpeakersComponent } from './speakers/speakers.component';
import { TopicsComponent } from './topics/topics.component';
import { NewfooterComponent } from './newfooter/newfooter.component';
// import { MyHighlightDirective } from '../shared/myhighlight/myhighlight.directive';
import { FormsModule } from '@angular/forms';
// import { MyHighlightDirective } from '../shared/shared.module';
import { MeetingRoutingModule } from './meeting-routing.module';
import { SharedModule } from '../shared/shared.module';

/**
 * The MeetingModule displays a transcript of a meeting. It allows the user to view the information in a variety of ways.
 * Users can select to see specific topics discussed. They can select to see what a specific person said. There will be many more
 * options added as the system grows.
 */
@NgModule({
  imports: [CommonModule, FormsModule, MeetingRoutingModule, SharedModule],
  declarations: [MeetingComponent, HeadingComponent, BrowsemeetingComponent,
   TopicsComponent, SpeakersComponent, NewfooterComponent],
  exports: [MeetingComponent]
})
export class MeetingModule { }
