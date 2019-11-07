import { Component, OnInit} from '@angular/core';
import { SidenavService } from '../../sidenav.service';

@Component({
  selector: 'gm-sidenav-header',
  templateUrl: './sidenav-header.component.html',
  styleUrls: ['./sidenav-header.component.scss']
})
export class SidenavHeaderComponent implements OnInit {

  message:string;

  constructor(private data: SidenavService) { }

  ngOnInit() {
    this.data.currentMessage.subscribe(message => this.message = message)
  }

  hideSidebar() {
    this.data.changeMessage("Hide")
  }
  }
