import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
// import { ReactiveFormsModule } from '@angular/forms'

import { AddtagsComponent } from './addtags';
import { TalksComponent } from './talks/talks';
import { TopicsComponent } from './topics/topics';
import { SectionsComponent } from './sections/sections';
import { SharedModule } from '../../common/common.module';

@NgModule({
  declarations: [AddtagsComponent, TalksComponent, TopicsComponent, SectionsComponent],

  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    // ReactiveFormsModule
    SharedModule,
  ],

  exports: [AddtagsComponent],
})
export class AddtagsModule {}
