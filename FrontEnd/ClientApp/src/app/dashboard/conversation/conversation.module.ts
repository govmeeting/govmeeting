import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../../material';
import { FormsModule } from '@angular/forms';
import { KeysPipe } from './keys.pipe';

import { ConversationComponent } from './conversation.component';


@NgModule({
  declarations: [
    ConversationComponent,
    KeysPipe
  ],
  imports: [
    CommonModule,
    DemoMaterialModule,
    FormsModule
  ],
  exports: [
    ConversationComponent
  ]
})
export class ConversationModule { }
