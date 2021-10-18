import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideojsComponent } from './videojs';

@NgModule({
  imports: [CommonModule],
  declarations: [VideojsComponent],
  exports: [VideojsComponent],
})
export class VideojsModule {}
