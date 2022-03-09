import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// from gm
import { DemoMaterialModule } from './common/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidenavMenuModule } from './sidenav/sidenav-menu-module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    // from gm
    DemoMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SidenavMenuModule
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
