import { Injectable } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';
import { OnDestroy } from '@angular/core';

const NoLog = true; // set to false for console logging

@Injectable({
  providedIn: 'root',
})
export class MediaQueryService implements OnDestroy {
  private ClassName: string = this.constructor.name + ': ';

  mediaQueryList: MediaQueryList;
  private mediaQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mediaQueryList = media.matchMedia('(max-width: 992px)');
    this.mediaQueryListener = () => {
      changeDetectorRef.detectChanges();
      NoLog || console.log(this.ClassName + 'Match?: ' + this.mediaQueryList.matches);
    };
    this.mediaQueryList.addEventListener('change', this.mediaQueryListener);
  }
  ngOnDestroy(): void {
    this.mediaQueryList.removeEventListener('change', this.mediaQueryListener);
  }
  isMobile() {
    return false;
    // return this.mediaQueryService.isMobile();
  }
}

// import { Injectable } from '@angular/core';
// import { ChangeDetectorRef } from '@angular/core';
// import { MediaMatcher } from '@angular/cdk/layout';

// @Injectable({
//   providedIn: 'root'
// })
// export class MediaQueryService  {
//   mediaQueryList: MediaQueryList;
//   private mediaQueryListener:() => void;

//   constructor(
//     changeDetectorRef: ChangeDetectorRef,
//     media: MediaMatcher
//   ) {
//     this.mediaQueryList = media.matchMedia('(max-width: 992px)');
//     this.mediaQueryListener = () => {
//       changeDetectorRef.detectChanges();
//       NoLog || console.log(this.ClassName + "Match?: ", this.mediaQueryList.matches)
//       }
//     this.mediaQueryList.addListener(this.mediaQueryListener);
//   }
//   ngOnDestroy(): void {
//     this.mediaQueryList.removeListener(this.mediaQueryListener);
//   }
//   isMobile() {
//     return false;
//     // return this.mediaQueryService.isMobile();
//   }
// }

// import { Injectable } from '@angular/core';
// import { Breakpoints, BreakpointObserver, BreakpointState  } from '@angular/cdk/layout';
// import {MediaMatcher} from '@angular/cdk/layout';
// import {ChangeDetectorRef, OnDestroy} from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
// export class MediaQueryService {
//   mobileQuery: MediaQueryList;
//   private _mobileQueryListener: () => void;

//   constructor(
//     private breakpointObserver: BreakpointObserver,
//     changeDetectorRef: ChangeDetectorRef
//     // media: MediaMatcher
//     )
//   {
//     // this.mobileQuery = media.matchMedia('(max-width: 600px)');
//     // this._mobileQueryListener = () => changeDetectorRef.detectChanges();
//     // this.mobileQuery.addListener(this._mobileQueryListener);
//   }

//   isMobile() {
//     return false;
//     // return this.mobileQuery.matches;
//   }

// }
