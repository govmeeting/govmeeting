import { Component, HostListener, OnInit } from '@angular/core';
import { ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, OnDestroy } from '@angular/core';
// import {ApplicationRef} from '@angular/core';

import { NavService } from './sidenav/nav.service';
// import { MediaQueryService } from './work_experiments/media-query.service';

import { Router } from '@angular/router';
import { UserSettingsService, UserSettings, LocationType } from './common/user-settings.service';

import { replaySubjectLog } from './logger-service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements AfterViewInit, OnDestroy, OnInit {
  private ClassName: string = this.constructor.name + ': ';
  @ViewChild('sidenav', { static: false }) sidenav: ElementRef;

  // setMode(value) {
  //   this.options.value.mode = value;
  // }

  options: FormGroup;
  mediaQueryList: MediaQueryList;
  private mediaQueryListener: () => void;

  constructor(
    private userSettingsService: UserSettingsService,
    private router: Router,
    public navService: NavService,
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
    this.navService.sidenav = this.sidenav;
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

  //////  For debugging ///////

  sendSettings() {
    const userSettings: UserSettings = new UserSettings('en', 'Totowa', 'Council');
    this.userSettingsService.settings = userSettings;
  }
  setLanguage() {
    this.userSettingsService.language = 'de';
  }

  routeAbout() {
    this.router.navigateByUrl('about');
  }

  routeDash() {
    this.router.navigateByUrl('dash');
  }

  //////////////////////////////////////////////////
  // This code is for debugging timing issues.
  // In app.component.html, uncomment:     <ul id="replaySubjectLogOutput"></ul>
  //    and comment out:                   <router-outlet></router-outlet>
  // This will replace most of the normal UI with the single <ul> element.
  // In ngOnInit, we subscribe to the replaySubjectLog service.
  // When any code calls "replaySubjectLog.next", we write their message as an item in
  //      <ul> list.
  // This lets us avoid running Chrome Dev tools (which may affect out timing issues)
  // in order to see console output messages.

  ngOnInit() {
    //  let msg = 'AppComponent:ngOnInit. Enter';
    //  this.addFullItem(msg);
    //  replaySubjectLog.subscribe((data) => this.addFullItem('' + data));
    //  replaySubjectLog.next('AppComponent:ngOnInit. Talking to myself after subscribing.');
  }

  addFullItem(msg: string) {
    const fullmsg = msg + ' ' + this.getNow();
    this.addItem(fullmsg);
  }

  addItem(val: any) {
    const node = document.createElement('li');
    const textnode = document.createTextNode(val);
    node.appendChild(textnode);
    document.getElementById('output').appendChild(node);
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
//// This code is also for debugging timing issues.
function addItem(val: any) {
  const node = document.createElement('li');
  const textnode = document.createTextNode(val);
  node.appendChild(textnode);
  document.getElementById('output').appendChild(node);
}
////////////////////////////////////////////
