import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { DemoMaterialModule } from '../common/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MenuListItemComponent } from './menu-list-item/menu-list-item';
import { SidenavMenuComponent } from './sidenav-menu';
import { NavService } from './nav.service';
import { TopNavComponent } from './sidenav-header/sidenav-header';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // TODO This is also imported in dashboard.module & app.module. Choose which we need.
    FlexLayoutModule,
    RouterModule,
    DemoMaterialModule,
  ],
  declarations: [SidenavMenuComponent, MenuListItemComponent, TopNavComponent],
  exports: [SidenavMenuComponent],
  providers: [NavService],
})
export class SidenavMenuModule {}
