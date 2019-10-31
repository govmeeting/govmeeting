import { Component, OnInit } from '@angular/core';
import { SidenavService } from '../../sidenav.service';

@Component({
  selector: 'gm-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  message:string;
  sidenavClass: string;
  sidenavText: string = "This is the sidenav";

  // mysideobj: any = {[this.myclass]: false};
  mysideobj: any = {greenside: true, yellowside: false, 'sidenav--active': false};

  constructor(private data: SidenavService) { }

  ngOnInit() {
    this.data.currentMessage.subscribe(message =>
      this.message = message
      // this.sidenavState = 'sidenav--active'
      // this.sidenavClass = 'myside'
       )
  }

  changeColor() {
    if (this.mysideobj.greenside) {
        this.sidenavText = "hello from yellow";
        this.mysideobj = {greenside: false, yellowside: true};

      } else {
        this.sidenavText = "hello from green";
        this.mysideobj = {yellowside: false, greenside: true}

        }
        // this.mysideobj = {[this.myclass]: true};
  }
}
