import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddtagsComponent } from './addtags.component';
import { TalksComponent } from './talks/talks.component';
import { TopicsComponent } from './topics/topics.component';
import { SectionsComponent } from './sections/sections.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [AddtagsComponent, TalksComponent, TopicsComponent, SectionsComponent]
})
export class AddtagsModule { }
