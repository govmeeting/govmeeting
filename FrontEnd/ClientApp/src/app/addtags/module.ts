import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
//import { ReactiveFormsModule } from '@angular/forms'

import { AddtagsComponent } from './component';
import { TalksComponent } from './talks/component';
import { TopicsComponent } from './topics/component';
import { SectionsComponent } from './sections/component';
import { SharedModule } from '../shared/module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    //ReactiveFormsModule
    SharedModule
  ],
  declarations: [AddtagsComponent, TalksComponent, TopicsComponent, SectionsComponent]
})
export class AddtagsModule { }
