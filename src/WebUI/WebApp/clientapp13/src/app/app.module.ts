import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// from gm
// import { FlexLayoutModule } from '@angular/flex-layout';
import { DemoMaterialModule } from './common/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidenavMenuModule } from './sidenav/sidenav-menu-module';
import { HeaderModule } from './header/header.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { AboutProjectModule } from './about-project/about-project.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    // AppRoutingModule.forRoot([]),
    // RouterModule.forRoot([], { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule,
    //// from gm
    // FlexLayoutModule,
    DemoMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SidenavMenuModule,
    HeaderModule,
    DashboardModule,
    AboutProjectModule,
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
