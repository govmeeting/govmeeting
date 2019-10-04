import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VolunteerComponent } from './volunteer.component';
import { GmSharedModule } from '../gmshared/gmshared.module'
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../material';


@NgModule({
  imports: [
    CommonModule,
      GmSharedModule,
      RouterModule,
      DemoMaterialModule
  ],
  declarations: [VolunteerComponent],
  exports: [VolunteerComponent]
})
export class VolunteerModule { }
