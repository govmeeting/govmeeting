import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule  } from '@angular/common/http';
import { FixasrComponent } from './component';
import { VideoModule } from '../video/module';
import { SharedModule } from '../shared/module'
import { RouterModule } from '@angular/router';
//import { FixasrRoutingModule } from './fixasr-routing.module';
//import { ReactiveFormsModule } from '@angular/forms'

@NgModule({
  declarations: [
    FixasrComponent,
  ],
  imports: [
    //ReactiveFormsModule,
    CommonModule,
    RouterModule,
    //FixasrRoutingModule,
    FormsModule,
    HttpClientModule,
    VideoModule,
    SharedModule
  ],
  providers: [],
})
export class FixasrModule { }

