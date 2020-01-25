import { Component, HostListener } from '@angular/core';
import { ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';

import {MediaMatcher} from '@angular/cdk/layout';
import {ChangeDetectorRef, OnDestroy} from '@angular/core';
// import {ApplicationRef} from '@angular/core';

import { NavService } from './dash-sidenav/sidenav-menu/service';
import { MediaQueryService } from './media-query.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit {
  @ViewChild('sidenav', {static: false}) sidenav: ElementRef;

  // setMode(value) {
  //   this.options.value.mode = value;
  // }

  options: FormGroup;
  mediaQueryList: MediaQueryList;
  private mediaQueryListener: () => void;

  constructor(
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
      hasBackdrop: false
    });
    this.mediaQueryList = media.matchMedia('(max-width: 600px)');
    this.mediaQueryListener = () => {
      changeDetectorRef.detectChanges();
      console.log("mediaQueryListener:" + this.mediaQueryList.matches);
      this.checkDeviceType();
    }
    this.mediaQueryList.addListener(this.mediaQueryListener);
  }

  ngAfterViewInit() {
    this.navService.sidenav = this.sidenav;
  }

  ngOnDestroy(): void {
    this.mediaQueryList.removeListener(this.mediaQueryListener);
  }

  isMobile() {
    return false;
    // return this.mediaQueryService.isMobile();
  }

  checkDeviceType() {
    var width = window.innerWidth;
    if (width <= 768) {
      console.log('mobile device detected')
    } else if (width > 768 && width <= 992) {
      console.log('tablet detected')
    } else {
      console.log('desktop detected')
    }
  }
}
