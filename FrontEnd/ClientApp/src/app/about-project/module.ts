import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AboutProjectComponent } from './component';
import { DemoMaterialModule } from '../material';
import { PurposeComponent } from './purpose/component';
import { NeededFeaturesComponent } from './needed-features/component';
import { VolunteerComponent } from './volunteer/component';
import { AboutTemplateComponent } from './about-template/component';
import { OverviewComponent } from './overview/component';
import { RegisterOrganizationComponent } from './register-organization/component';
import { SearchMeetingsComponent } from './search-meetings/component';
import { AutoProcessingComponent } from './auto-processing/component';


@NgModule({
  declarations: [
    AboutProjectComponent,
    PurposeComponent,
    NeededFeaturesComponent,
    VolunteerComponent,
    AboutTemplateComponent,
    OverviewComponent,
    RegisterOrganizationComponent,
    SearchMeetingsComponent,
    AutoProcessingComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    DemoMaterialModule
  ],
  exports: [
    DemoMaterialModule,
    AboutProjectComponent
  ]
})
export class AboutProjectModule { }
