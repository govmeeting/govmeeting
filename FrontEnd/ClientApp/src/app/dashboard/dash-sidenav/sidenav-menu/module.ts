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

// import {
//   MatAutocompleteModule,
//   MatButtonModule,
//   MatButtonToggleModule,
//   MatCardModule,
//   MatCheckboxModule,
//   MatChipsModule,
//   MatDatepickerModule,
//   MatDialogModule,
//   MatExpansionModule,
//   MatGridListModule,
//   MatIconModule,
//   MatInputModule,
//   MatListModule,
//   MatMenuModule,
//   MatNativeDateModule,
//   MatProgressBarModule,
//   MatProgressSpinnerModule,
//   MatRadioModule,
//   MatRippleModule,
//   MatSelectModule,
//   MatSidenavModule,
//   MatSliderModule,
//   MatSlideToggleModule,
//   MatSnackBarModule,
//   MatTabsModule,
//   MatToolbarModule,
//   MatTooltipModule
// } from '@angular/material';
import {FlexLayoutModule} from '@angular/flex-layout';
import {MenuListItemComponent} from './menu-list-item/component';
import {SidenavMenuComponent} from './component';
import {SidenavMenuRoutingModule} from './routing.module';
import { InfoCityComponent } from '../sidenav-info/info-city/component';
import { InfoCountyComponent } from '../sidenav-info/info-county/component';
import { InfoStateComponent } from '../sidenav-info/info-state/component';
import { InfoFederalComponent } from '../sidenav-info/info-federal/component';
import { NavService } from '../../../services/sidenav.service';
import { TopNavComponent } from '../sidenav-header/component';

/**
 * NgModule that includes all Material modules that are required.
 */
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
    // Material
    // MatAutocompleteModule,
    // MatButtonModule,
    // MatButtonToggleModule,
    // MatCardModule,
    // MatCheckboxModule,
    // MatChipsModule,
    // MatDatepickerModule,
    // MatDialogModule,
    // MatExpansionModule,
    // MatGridListModule,
    // MatIconModule,
    // MatInputModule,
    // MatListModule,
    // MatMenuModule,
    // MatProgressBarModule,
    // MatProgressSpinnerModule,
    // MatRadioModule,
    // MatRippleModule,
    // MatSelectModule,
    // MatSidenavModule,
    // MatSlideToggleModule,
    // MatSliderModule,
    // MatSnackBarModule,
    // MatTabsModule,
    // MatToolbarModule,
    // MatTooltipModule,
    // MatNativeDateModule,
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
