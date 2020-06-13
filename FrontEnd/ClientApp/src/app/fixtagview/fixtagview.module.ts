import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
//import { ReactiveFormsModule } from '@angular/forms'

import { FixTagViewComponent } from './fixtagview';
import { TalksComponent } from './talks/talks';
import { TopicsComponent } from './topics/topics';
import { SectionsComponent } from './sections/sections';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [FixTagViewComponent, TalksComponent, TopicsComponent, SectionsComponent],

  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    //ReactiveFormsModule
    SharedModule
  ],

  exports: [
    FixTagViewComponent
  ]
})
export class FixTagViewModule { }
