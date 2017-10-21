import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomepageComponent } from './homepage.component';
import { HomepageRoutingModule } from './homepage-routing.module';
import { SharedModule } from '../shared/shared.module';
import { NameListService } from '../shared/name-list/index';
//import { MarkdownModule } from 'angular2-markdown/alert';

@NgModule({
  imports: [CommonModule, HomepageRoutingModule, SharedModule],
  //imports: [CommonModule, HomepageRoutingModule, SharedModule, MarkdownModule.forRoot()],
  declarations: [HomepageComponent],
  exports: [HomepageComponent],
  providers: [NameListService]
})
export class HomepageModule { }
