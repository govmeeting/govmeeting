import { Injectable } from '@angular/core';
import { Breakpoints, BreakpointObserver, BreakpointState  } from '@angular/cdk/layout';
import {MediaMatcher} from '@angular/cdk/layout';
import {ChangeDetectorRef, OnDestroy} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MediaQueryService {
  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;

  constructor(
    private breakpointObserver: BreakpointObserver,
    changeDetectorRef: ChangeDetectorRef
    // media: MediaMatcher
    )
  {
    // this.mobileQuery = media.matchMedia('(max-width: 600px)');
    // this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    // this.mobileQuery.addListener(this._mobileQueryListener);
  }

  isMobile() {
    return false;
    // return this.mobileQuery.matches;
  }

}
