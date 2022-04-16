import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../common/material';
import { HttpClientModule } from '@angular/common/http';
import { MarkdownModule } from 'ngx-markdown';

import { AboutComponent } from './about-project';
import { OverviewComponent } from './overview/overview';
// import { SysDesignComponent } from './sys-design/sys-design'

@NgModule({
  declarations: [
    AboutComponent,
    OverviewComponent,
    // SysDesignComponent
  ],
  imports: [CommonModule, RouterModule, DemoMaterialModule, HttpClientModule, MarkdownModule.forRoot()],
  exports: [DemoMaterialModule],
})
export class AboutProjectModule {}
