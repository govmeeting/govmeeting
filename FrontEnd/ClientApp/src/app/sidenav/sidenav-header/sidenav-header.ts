import { Component, OnInit } from '@angular/core';
import {NavService} from '../nav.service';

@Component({
  selector: 'gm-sidenav-header',
  templateUrl: './sidenav-header.html',
  styleUrls: ['./sidenav-header.scss']
})
export class TopNavComponent implements OnInit {

  // NavService is used in the template for the button to close the menu.
  constructor(public navService: NavService) { }

  ngOnInit() {
  }

}
