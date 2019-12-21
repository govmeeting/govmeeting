// The code for this component was created with:
//  ng generate @angular/material:material-dashboard --name=GMDashboard

import { Component, HostListener } from '@angular/core';
import { ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver, BreakpointState  } from '@angular/cdk/layout';
import {FormBuilder, FormGroup} from '@angular/forms';

import {MediaMatcher} from '@angular/cdk/layout';
import {ChangeDetectorRef, OnDestroy} from '@angular/core';


// import { SidenavComponent } from './dash-sidenav/sidenav-container/sidenav.component';
import {NavService} from './dash-sidenav/sidenav-menu/service';

@Component({
  selector: 'gm-dashboard',
  templateUrl: './component.html',
  styleUrls: ['./component.scss']
})
export class DashboardComponent implements AfterViewInit {
  @ViewChild('sidenav', {static: false}) sidenav: ElementRef;

  // isHandset = false;
  // isLarge = false;
  // viewsize: number = 1;
  // public results1$;
  // public results2$;
  // public innerWidth;
  // public innerHeight;
  // orientation:string;


  // myob = {'(max-width: 1000px)': true, '(max-width: 1500px)': true, '(max-width: 2000px)': true}

  // setMode(value) {
  //   this.options.value.mode = value;
  // }

  options: FormGroup;
  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;

  constructor(
    public navService: NavService,
    private breakpointObserver: BreakpointObserver,
    fb: FormBuilder,
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher
    ) {

    this.options = fb.group({
      bottom: 0,
      fixed: true,
      top: 0,
      mode: 'side',
      hasBackdrop: false
    });

    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);

  }

  ngAfterViewInit() {
    this.navService.sidenav = this.sidenav;
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  // ngOnInit() {
    // this.results1$ = this.breakpointObserver.observe('(max-width: 350px)')
    // this.results2$ = this.breakpointObserver.observe(['(max-width: 350px)', '(max-width: 450px)'])

/*
    Using Breakpoints.Handset, I get the following results:
    If re-size the browser so that innerHeight is 750px and innerWidth is 500, then
      when I increase the width:
      It starts with 2 cards per line. At 600 it becomes 4. At 750, it becomes 2 again and
      at 960 it becomes 4 again and stays at 4 to maximum width.
      From 500 to 600, it thinks it's a handset.
      From 601 to 750, it doesn't.
      From 751 to 960, it's in landscape mode and thinks it is a handset again.
      From 961 - max, it doesn't
*/
  // this.breakpointObserver
  //   .observe(Breakpoints.Handset)
  //   .subscribe((state: BreakpointState) => {
  //     if (state.matches) {
  //       this.isHandset = true;
  //     } else {
  //       this.isHandset = false;
  //     }
  //   });

  // this.breakpointObserver
  //   .observe(['(max-width: 1000px)', '(max-width: 1500px)',
  //    '(max-width: 2000px)'])
  //   .subscribe((state: BreakpointState) => {
  //     console.log(state);
  //     // Set viewsize from 1 (smallest) to 4 (largest)
  //     if (!state.breakpoints['(max-width: 2000px)']) {
  //       this.viewsize = 4;
  //     } else {
  //       if (!state.breakpoints['(max-width: 1500px)']){
  //         this.viewsize = 3;
  //       } else {
  //           if (!state.breakpoints['(max-width: 1000px)']){
  //             this.viewsize = 2;
  //         } else {
  //             this.viewsize = 1;
  //           }
  //       }
  //     }
  //   });
  // }

//   @HostListener('window:resize', ['$event'])
// onResize(event) {
//   this.innerWidth = window.innerWidth;
//   this.innerHeight = window.innerHeight;
//   this.orientation = (this.innerWidth > this.innerHeight) ? "landscape" : "portrait";
// }

// GetCols() : number {
//   return this.viewsize * 3;
// }
// GetColspan(s, l) : number {
//     //return this.isLarge ? 3 * l : 3 * s;
//     return 3;
//   }


}



  // LgMdSm(large: number, middle: number, small: number) {
  // }

  // Demo code to create 4 Cards based on breakpoints.
  /** Based on the screen size, switch from standard to one column per row */
  // cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
  //   map(({ matches }) => {
  //     if (matches) {
  //       return [
  //         { title: 'Card 1', cols: 1, rows: 1 },
  //         { title: 'Card 2', cols: 1, rows: 1 },
  //         { title: 'Card 3', cols: 1, rows: 1 },
  //         { title: 'Card 4', cols: 1, rows: 1 }
  //       ];
  //     }

  //     return [
  //       { title: 'Card 1', cols: 2, rows: 1 },
  //       { title: 'Card 2', cols: 1, rows: 1 },
  //       { title: 'Card 3', cols: 1, rows: 2 },
  //       { title: 'Card 4', cols: 1, rows: 1 }
  //     ];
  //   })
  // );

