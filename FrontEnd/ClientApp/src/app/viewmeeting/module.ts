import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { ViewMeetingComponent } from './component';
import { BrowseComponent } from './browse/component';
import { HeadingComponent } from './heading/component';
import { SpeakersComponent } from './speakers/component';
import { TopicsComponent } from './topics/component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    SharedModule
 ],
  declarations: [ViewMeetingComponent, BrowseComponent,
     HeadingComponent, SpeakersComponent, TopicsComponent]
})
export class ViewMeetingModule { }
