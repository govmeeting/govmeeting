import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about.component';
import { GmSharedModule } from '../../gmshared/gmshared.module'
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../../material';

@NgModule({
  imports: [
    CommonModule,
    GmSharedModule,
    RouterModule,
    DemoMaterialModule
    ],
  declarations: [AboutComponent],
  exports: [AboutComponent]
})
export class AboutModule { }
