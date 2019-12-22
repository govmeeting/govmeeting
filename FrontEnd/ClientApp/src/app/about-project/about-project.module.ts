import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DemoMaterialModule } from '../material';

import { AboutProjectComponent } from './about-project';
import { PurposeComponent } from './purpose/purpose';
import { NeededFeaturesComponent } from './needed-features/needed-features';
import { VolunteerComponent } from './volunteer/volunteer';
import { AboutTemplateComponent } from './about-template/about-template';
import { OverviewComponent } from './overview/overview';
import { RegisterOrganizationComponent } from './register-organization/register-organization';
import { SearchMeetingsComponent } from './search-meetings/search-meetings';
import { AutoProcessingComponent } from './auto-processing/auto-processing';


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
