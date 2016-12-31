import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddtagsComponent } from './addtags.component';
import { TalksComponent } from './talks/talks.component';
import { TopicsComponent } from './topics/topics.component';
// import { MyHighlightDirective } from '../shared/myhighlight/myhighlight.directive';
import { FormsModule } from '@angular/forms';
// import { MyHighlightDirective } from '../shared/shared.module';
import { AddtagsRoutingModule } from './addtags-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [CommonModule, FormsModule, AddtagsRoutingModule, SharedModule],
  // declarations: [AddtagsComponent, Component],
 declarations: [AddtagsComponent, TalksComponent, TopicsComponent],
  exports: [AddtagsComponent]
})
export class AddtagsModule { }
