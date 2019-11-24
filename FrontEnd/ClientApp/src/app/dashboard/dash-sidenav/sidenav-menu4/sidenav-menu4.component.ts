import {Component, OnInit, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit} from '@angular/core';
import {VERSION} from '@angular/material';
import {NavItem} from './nav-item';
import {NavService} from './nav.service';
import { string } from '@amcharts/amcharts4/core';

@Component({
  selector: 'gm-sidenav-menu4',
  templateUrl: 'sidenav-menu4.component.html',
  styleUrls: ['sidenav-menu4.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidenavMenu4Component implements AfterViewInit {
  @ViewChild('appDrawer', {static: false}) appDrawer: ElementRef;
  version = VERSION;

  itemSelected: string = '';

  constructor(private navService: NavService) {
  }

  ngAfterViewInit() {
    this.navService.appDrawer = this.appDrawer;
  }

    navItems: Array<NavItem> = [
      new NavItem('Government', 'group',
      [
        new NavItem('Austin', 'location_city',
        [
          new NavItem('City Council', 'group'),
          new NavItem('Board of Education', 'school'),
          new NavItem('Planning Board', 'group'),
          new NavItem('All Departments', 'group')
        ]),
        new NavItem('Traves County', 'group',
        [
          new NavItem('Commissioners', 'group'),
          new NavItem('Transportation', 'group'),
          new NavItem('All Departments', 'group')
        ]),
        new NavItem('State of Texas', 'star',
        [
          new NavItem('Senate', 'group'),
          new NavItem('House of Representatives', 'group'),
          new NavItem('bBoth Branches', 'group')
        ]),
        new NavItem('United States', 'flag',
        [
          new NavItem('Senate', 'group'),
          new NavItem('House of Representatives', 'group'),
          new NavItem('Both Branches', 'group')
        ])
      ]),
      new NavItem('Non-Government', 'group',
      [
        new NavItem('Glendale HOA', 'group',
        [
          new NavItem('Governing Board', 'group'),
          new NavItem('Covenance Committee', 'group'),
          new NavItem('Both', 'group')
        ]),
        new NavItem('Paws Rescue', 'group')
      ])
    ];

  onEmitted(items: Array<NavItem>){
    var selected: string = '';
    console.log("====OnEmitted(sidenav): ");
    console.log(items);
    for(var i = (items.length -1); i >= 0; i--)
    {
      console.log(items[i]);
      selected = selected + items[i].displayName + ((i !=0) ? ' ; ' : '');
    }
    console.log("itemSelected: " + selected);
    this.itemSelected = selected;
  }

}
