import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';

import {A11yModule} from '@angular/cdk/a11y';
import {BidiModule} from '@angular/cdk/bidi';
import {ObserversModule} from '@angular/cdk/observers';
import {OverlayModule} from '@angular/cdk/overlay';
import {PlatformModule} from '@angular/cdk/platform';
import {PortalModule} from '@angular/cdk/portal';
import {ScrollDispatchModule} from '@angular/cdk/scrolling';
import {CdkStepperModule} from '@angular/cdk/stepper';
import {CdkTableModule} from '@angular/cdk/table';

import { DemoMaterialModule } from '../../../material';

import {FlexLayoutModule} from '@angular/flex-layout';
import {MenuListItemComponent} from './menu-list-item/menu-list-item';
import {SidenavMenuComponent} from './sidenav-menu';
import {SidenavMenuRoutingModule} from './routing.module';
import { InfoCityComponent } from '../sidenav-info/info-city/info-city';
import { InfoCountyComponent } from '../sidenav-info/info-county/info-county';
import { InfoStateComponent } from '../sidenav-info/info-state/info-state';
import { InfoFederalComponent } from '../sidenav-info/info-federal/info-federal';
import { NavService } from './service';
import { TopNavComponent } from '../sidenav-header/sidenav-header';

@NgModule({
  exports: [
    // CDK
    A11yModule,
    BidiModule,
    ObserversModule,
    OverlayModule,
    PlatformModule,
    PortalModule,
    ScrollDispatchModule,
    CdkStepperModule,
    CdkTableModule,

    DemoMaterialModule
  ]
})
export class MaterialModule {}

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,          // TODO This is also imported in dashboard.module & app.module. Choose which we need.
    FlexLayoutModule,
    SidenavMenuRoutingModule
  ],
  declarations: [
    SidenavMenuComponent,
    MenuListItemComponent,
    InfoCityComponent,
    InfoCountyComponent,
    InfoStateComponent,
    InfoFederalComponent,
    TopNavComponent
  ],
  exports: [
    SidenavMenuComponent
  ],
  // bootstrap: [AppComponent],
  providers: [NavService]
})
export class SidenavMenuModule {}