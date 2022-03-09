import { Component, HostListener} from '@angular/core';
import { ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, OnDestroy } from '@angular/core';
// import {ApplicationRef} from '@angular/core';

// TEMP // import { NavService } from './sidenav/nav.service';
// import { MediaQueryService } from './work_experiments/media-query.service';

// // For degugging routes and userSetttings
// import { Router } from '@angular/router';
// import { UserSettingsService, UserSettings, LocationType } from './common/user-settings.service';

import { replaySubjectLog } from './logger-service';

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

  options: FormGroup;
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
    this.options = fb.group({
      bottom: 0,
      fixed: true,
      top: 0,
      mode: 'side',
      hasBackdrop: false,
    });
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

  //////////////////////////////////////////////////
  // The code below is for debugging timing issues with services.
  // It lets us see console output messages without using Chrome Dev tools (which may affect timing issues).

  // In order to use this code:
  //  1. To app.component.html, add: <ul id="replaySubjectLogOutput"></ul>
  //     The log messages will be displayed in this element.
  //     I added it in place of <router-outlet></router-outlet> since I didn't need the dashboard UI.
  //  2. Uncomment the ngOnInit method below and add OnInit to the "implements" list of AppComponent.
  //  3. Call addFullItem(msg) to display a log message with a time stamp
  //     or addItem(msg) to display without time stamp.

  // ngOnInit() {
  //    // Subscribe to the replaySubjectLog service.
  //    // "replaySubjectLog.next" writes a message to the <ul> list.
  //    let msg = 'AppComponent:ngOnInit. Enter';
  //    this.addFullItem(msg);
  //    replaySubjectLog.subscribe((data) => this.addFullItem('' + data));
  //    replaySubjectLog.next('AppComponent:ngOnInit. Talking to myself after subscribing.');
  // }

  addFullItem(msg: string) {
    const fullmsg = msg + ' ' + this.getNow();
    this.addItem(fullmsg);
  }

  addItem(val: any) {
    const node = document.createElement('li');
    const textnode = document.createTextNode(val);
    node.appendChild(textnode);
  // ToDo - I added the "!" to avoid the error "object is possibly null"
  // but this should be better handled.
  document.getElementById('output')!.appendChild(node);
}

  getNow(): string {
    const now = Date.now();
    const sec = Math.floor(now / 1000) % 100;
    const ms = now % 1000;
    return sec.toString() + ':' + ms.toString();
  }
  ////////////////////////////////////////////

} // closing brace for the AppComponent class.

////////////////////////////////////////////
//// This is part of the code for debugging timing issues.
function addItem(val: any) {
  const node = document.createElement('li');
  const textnode = document.createTextNode(val);
  node.appendChild(textnode);
  // ToDo - I added the "!" to avoid the error "object is possibly null"
  // but this should be better handled.
  document.getElementById('output')!.appendChild(node);
}
////////////////////////////////////////////
