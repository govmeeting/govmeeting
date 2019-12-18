import { Component, OnInit } from '@angular/core';
import {NavService} from '../../../services/sidenav.service';

@Component({
  selector: 'gm-sidenav-header',
  templateUrl: './sidenav-header.component.html',
  styleUrls: ['./sidenav-header.component.scss']
})
export class TopNavComponent implements OnInit {

  constructor(public navService: NavService) { }

  ngOnInit() {
  }

}
