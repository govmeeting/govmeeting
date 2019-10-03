// The code for this component was created with:
//  ng generate @angular/material:material-dashboard --name=GMDashboard

import { Component, HostListener } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver, BreakpointState  } from '@angular/cdk/layout';

@Component({
  selector: 'gm-dashboard',
  templateUrl: './gmdashboard.component.html',
  styleUrls: ['./gmdashboard.component.scss']
})
export class GMDashboardComponent {
  isHandset = false;
  public results1$;
  public results2$;
  public innerWidth;
  public innerHeight;
  orientation:string;

  ngOnInit() {
    this.results1$ = this.breakpointObserver.observe('(max-width: 350px)')
    this.results2$ = this.breakpointObserver.observe(['(max-width: 350px)', '(max-width: 450px)'])


    this.breakpointObserver.observe(Breakpoints.Handset)
      .subscribe((state: BreakpointState) => {
        if (state.matches) {
          this.isHandset = true;
        } else {
          this.isHandset = false;
        }
      });
  }

  @HostListener('window:resize', ['$event'])
onResize(event) {
  this.innerWidth = window.innerWidth;
  this.innerHeight = window.innerHeight;
  this.orientation = (this.innerWidth > this.innerHeight) ? "landscape" : "portrait";
}

  // LgMdSm(large: number, middle: number, small: number) {

  // }




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

  constructor(private breakpointObserver: BreakpointObserver) {}
}
