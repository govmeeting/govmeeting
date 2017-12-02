import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule, Routes } from '@angular/router';

@NgModule({
  imports: [CommonModule, RouterModule],
  declarations: [HomeComponent],
  exports: [HomeComponent],
  providers: []
})
export class HomeModule { }
