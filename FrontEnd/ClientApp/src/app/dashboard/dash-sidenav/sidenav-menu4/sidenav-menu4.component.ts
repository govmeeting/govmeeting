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
  @ViewChild('appDrawer', {static: false})
  appDrawer: ElementRef;
  version = VERSION;

  itemSelected: string = '';

  constructor(private navService: NavService) {
  }

  ngAfterViewInit() {
    this.navService.appDrawer = this.appDrawer;
  }

  OnFinalSelection(items: Array<NavItem>){
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

    navItems: Array<NavItem> = [
      new NavItem('Select', 'group',

    [
      new NavItem('Government', 'group',
      [
        new NavItem('Austin', 'location_city',
        [
          new NavItem('All Departments', 'group', 'info-city'),
          new NavItem('City Council', 'group', 'info-city'),
          new NavItem('Board of Education', 'school', 'info-city'),
          new NavItem('Planning Board', 'group', 'info-city')
        ]),
        new NavItem('Traves County', 'group',
        [
          new NavItem('All Departments', 'group', 'info-county'),
          new NavItem('Commissioners', 'group', 'info-county'),
          new NavItem('Transportation', 'group', 'info-county')
        ]),
        new NavItem('State of Texas', 'star',
        [
          new NavItem('Senate & House', 'group', 'info-state'),
          new NavItem('Senate', 'group', 'info-state'),
          new NavItem('House of Representatives', 'group', 'info-state')
        ]),
        new NavItem('United States', 'flag',
        [
          new NavItem('Senate & House', 'group', 'info-federal'),
          new NavItem('Senate', 'group', 'info-federal'),
          new NavItem('House of Representatives', 'group', 'info-federal')
        ])
      ]),
      new NavItem('Non-Government', 'group',
      [
        new NavItem('Glendale HOA', 'group', 'info-HOA'),
        new NavItem('Paws Rescue', 'group', 'info-non-profit')
      ])
    ])
  ];

}
