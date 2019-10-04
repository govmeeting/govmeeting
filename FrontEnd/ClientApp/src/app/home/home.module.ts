import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule, Routes } from '@angular/router';
import { DemoMaterialModule } from '../material';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    DemoMaterialModule
  ],
  declarations: [HomeComponent],
  exports: [HomeComponent],
  providers: []
})
export class HomeModule { }
