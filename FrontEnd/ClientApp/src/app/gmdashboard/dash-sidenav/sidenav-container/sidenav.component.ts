import { Component, OnInit, HostBinding } from '@angular/core';
import { SidenavService } from '../../sidenav.service';
import { Breakpoints, BreakpointObserver, BreakpointState  } from '@angular/cdk/layout';

@Component({
  selector: 'gm-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  message:string;
  sidenavClass: string;
  sidenavText: string = "This is the sidenav";
  viewsize;

  // isActive: boolean = false;
  @HostBinding('class.sidenav--active') isActive: boolean = false;

  //  constructor(private data: SidenavService,
  //    private breakpointObserver: BreakpointObserver) {   }
  constructor(private data: SidenavService) { }

  ngOnInit() {
    this.data.currentMessage.subscribe(message => {
      this.message = this.message + message;
      if (message == "Show"){
        this.show();
      }
      if (message == "Hide"){
        this.hide();
      }
    });
  }

  hide() {
    this.isActive = false;
  }

  show() {
    this.isActive = true;
  }
}

    // this.breakpointObserver
    // .observe(['(max-width: 750px)', '(min-width: 750px)'])
    // .subscribe((state: BreakpointState) => {
    //   console.log(state);

    //   if (!state.breakpoints['(max-width: 750px)']) {
    //     this.show();
    //   }

    //   // This is true if width changed from less than or equal to 750 to more than 750 (No!)
    //   if (!state.breakpoints['(min-width: 750px)']) {
    //     this.hide();
    //   }
    // });


    // .observe(['(max-width: 1000px)', '(max-width: 1500px)',
    //  '(max-width: 2000px)'])
    // .subscribe((state: BreakpointState) => {
    //   console.log(state);
    //   // Set viewsize from 1 (smallest) to 4 (largest)
    //   if (!state.breakpoints['(max-width: 2000px)']) {
    //     this.viewsize = 4;
    //   } else {
    //     if (!state.breakpoints['(max-width: 1500px)']){
    //       this.viewsize = 3;
    //     } else {
    //         if (!state.breakpoints['(max-width: 1000px)']){
    //           this.viewsize = 2;
    //       } else {
    //           this.viewsize = 1;
    //         }
    //     }
    //   }
    // });



