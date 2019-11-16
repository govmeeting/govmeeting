import { Component, OnInit, HostBinding } from '@angular/core';
import { SidenavService } from '../../../services/sidenav.service';
import { Breakpoints, BreakpointObserver, BreakpointState  } from '@angular/cdk/layout';

@Component({
  selector: 'gm-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  @HostBinding('class.sidenav--active') isActive: boolean = false;

   constructor(private data: SidenavService,
     private breakpointObserver: BreakpointObserver) {   }

  ngOnInit() {
    // The menu icon in the top header will display the sidenav.
    // If sidenav is visible, the "X" icon in its eader will close it.
    this.data.currentMessage.subscribe(message => {
      if (message == "Show"){
        this.show();
      }
      if (message == "Hide"){
        this.hide();
      }
    });
    // If the user expands the viewport, set sidenav-active to false,
    // so that the sidenav goes away if they later narrow the viewport. (more intuitive)
    this.breakpointObserver
    .observe(['(min-width: 750px)'])
    .subscribe((state: BreakpointState) => {
      //console.log(state);
      if (state.matches) {
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



