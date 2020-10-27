import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FixasrComponent } from './fixasr';
import { VideoModule } from '../../common/video/video.module';
import { SharedModule } from '../../common/common.module';
import { RouterModule } from '@angular/router';
// import { FixasrRoutingModule } from './fixasr-routing.module';
// import { ReactiveFormsModule } from '@angular/forms'

@NgModule({
  declarations: [FixasrComponent],

  imports: [
    // ReactiveFormsModule,
    CommonModule,
    RouterModule,
    // FixasrRoutingModule,
    FormsModule,
    HttpClientModule,
    VideoModule,
    SharedModule,
  ],

  exports: [FixasrComponent],

  providers: [],
})
export class FixasrModule {}
