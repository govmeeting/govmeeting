import { Component, HostListener} from '@angular/core';
import { ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, OnDestroy } from '@angular/core';
// import {ApplicationRef} from '@angular/core';

// TEMP // import { NavService } from './sidenav/nav.service';
// import { MediaQueryService } from './work_experiments/media-query.service';

// // For degugging routes
// import { Router } from '@angular/router';
// // For degugging userSetttings
// import { UserSettingsService, UserSettings, LocationType } from './common/user-settings.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements AfterViewInit, OnDestroy {
  private ClassName: string = this.constructor.name + ': ';
  // The next statement gets a reference to the "#sidenav" element in app.component.html.
  @ViewChild('sidenav', { static: false }) sidenav?: ElementRef;

  // setMode(value) {
  //   this.options.value.mode = value;
  // }

  mediaQueryList: MediaQueryList;
  private mediaQueryListener: () => void;

  constructor(
    // // For debugging routes and userSettings
    // private userSettingsService: UserSettingsService,
    // private router: Router,
    // TEMP //public navService: NavService,
    // public mediaQueryService: MediaQueryService,
    fb: FormBuilder,
    changeDetectorRef: ChangeDetectorRef,
    // changeDetectorRef: ApplicationRef,
    media: MediaMatcher
  ) {
    this.mediaQueryList = media.matchMedia('(max-width: 600px)');
    this.mediaQueryListener = () => {
      changeDetectorRef.detectChanges();
      NoLog || console.log(this.ClassName + 'mediaQueryListener:' + this.mediaQueryList.matches);
      // this.checkDeviceType();
    };
    this.mediaQueryList.addEventListener('change', this.mediaQueryListener);
  }

  ngAfterViewInit() {
    // TEMP // this.navService.sidenav = this.sidenav;
  }

  ngOnDestroy(): void {
    this.mediaQueryList.removeEventListener('change', this.mediaQueryListener);
  }

  isMobile() {
    return false;
    // return this.mediaQueryService.isMobile();
  }

  checkDeviceType() {
    const width = window.innerWidth;
    if (width <= 768) {
      NoLog || console.log(this.ClassName + 'mobile device detected');
    } else if (width > 768 && width <= 992) {
      NoLog || console.log(this.ClassName + 'tablet detected');
    } else {
      NoLog || console.log(this.ClassName + 'desktop detected');
    }
  }

  //////  For debugging userSettings ///////
  // sendSettings() {
  //   const userSettings: UserSettings = new UserSettings('en', 'Totowa', 'Council');
  //   this.userSettingsService.settings = userSettings;
  // }
  // setLanguage() {
  //   this.userSettingsService.language = 'de';
  // }

  ////// For debugging routes //////
  // routeAbout() {
  //   this.router.navigateByUrl('about');
  // }
  // routeDash() {
  //   this.router.navigateByUrl('dash');
  // }

}
