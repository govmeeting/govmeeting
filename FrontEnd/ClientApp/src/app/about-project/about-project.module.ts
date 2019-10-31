import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AboutProjectComponent } from './about-project.component';
import { DemoMaterialModule } from '../material';
import { PurposeComponent } from './purpose/purpose.component';
import { NeededFeaturesComponent } from './needed-features/needed-features.component';
import { VolunteerComponent } from './volunteer/volunteer.component';
import { AboutTemplateComponent } from './about-template/about-template.component';
import { OverviewComponent } from './overview/overview.component';
import { RegisterOrganizationComponent } from './register-organization/register-organization.component';
import { SearchMeetingsComponent } from './search-meetings/search-meetings.component';
import { AutoProcessingComponent } from './auto-processing/auto-processing.component';


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
