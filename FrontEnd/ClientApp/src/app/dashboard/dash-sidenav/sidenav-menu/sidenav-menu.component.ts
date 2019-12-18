import {Component, OnInit, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit} from '@angular/core';
import {VERSION} from '@angular/material';
import {NavItem} from '../../../models/nav-item';
import {NavService} from '../../../services/sidenav.service';
import { string } from '@amcharts/amcharts4/core';

@Component({
  selector: 'gm-sidenav-menu',
  templateUrl: 'sidenav-menu.component.html',
  styleUrls: ['sidenav-menu.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidenavMenuComponent implements AfterViewInit {
  @ViewChild('appDrawer', {static: false})
  sidenav: ElementRef;
  version = VERSION;

  itemSelected: string = '';

  constructor(private navService: NavService) {
  }

  ngAfterViewInit() {
    this.navService.sidenav = this.sidenav;
    this.navService.navItems = this.navItems;
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

    this.navService.closeMenu(0);
  }

    // oneNavItem: NavItem = new NavItem('Austin', 'location_city', 2);

    navItems: Array<NavItem> = [
      new NavItem('Organization', null, 0,
    [
      new NavItem('Austin', 'location_city', 1,
      [
        new NavItem('City Council', 'group', 2, 'info-city'),
        new NavItem('Board of Education', 'school', 2, 'info-city'),
        new NavItem('Planning Board', 'group', 2, 'info-city'),
        new NavItem('All Depts.', 'group', 2, 'info-city'),
      ]),
      new NavItem('Traves County', 'group', 1,
      [
        new NavItem('Commissioners', 'group', 2, 'info-county'),
        new NavItem('Transportation', 'group', 2, 'info-county'),
        new NavItem('Both Depts.', 'group', 2, 'info-county'),
      ]),
      new NavItem('State of Texas', 'star', 1,
      [
        new NavItem('Senate', 'group', 2, 'info-state'),
        new NavItem('House', 'group', 2, 'info-state'),
        new NavItem('Both chambers', 'group', 2, 'info-state')
      ]),
      new NavItem('United States', 'flag', 1,
      [
        new NavItem('Senate', 'group', 2, 'info-federal'),
        new NavItem('House', 'group', 2, 'info-federal'),
        new NavItem('Both chambers', 'group', 2, 'info-federal')
      ]),
      new NavItem('Non-Government', 'group', 1,
      [
        new NavItem('Glendale HOA', 'group', 2, 'info-HOA'),
      ])
    ])
  ];

}
