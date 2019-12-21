import { Component, OnInit } from '@angular/core';
import {NavService} from '../sidenav-menu/service';

@Component({
  selector: 'gm-sidenav-header',
  templateUrl: './component.html',
  styleUrls: ['./component.scss']
})
export class TopNavComponent implements OnInit {

  constructor(public navService: NavService) { }

  ngOnInit() {
  }

}
