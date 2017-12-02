import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
//import { ReactiveFormsModule } from '@angular/forms'

import { AddtagsComponent } from './addtags.component';
import { TalksComponent } from './talks/talks.component';
import { TopicsComponent } from './topics/topics.component';
import { SectionsComponent } from './sections/sections.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    //ReactiveFormsModule
    SharedModule
  ],
  declarations: [AddtagsComponent, TalksComponent, TopicsComponent, SectionsComponent]
})
export class AddtagsModule { }
