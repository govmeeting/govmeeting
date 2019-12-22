import {Component, OnInit, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit} from '@angular/core';
import {VERSION} from '@angular/material';
import {Router} from '@angular/router';

import {NavItem} from './nav-item';
import {NavService} from './service';
import { string } from '@amcharts/amcharts4/core';

@Component({
  selector: 'gm-sidenav-menu',
  templateUrl: 'sidenav-menu.html',
  styleUrls: ['sidenav-menu.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidenavMenuComponent implements AfterViewInit {
  @ViewChild('appDrawer', {static: false})
  sidenav: ElementRef;
  version = VERSION;

  itemSelected: string = '';

  constructor(private navService: NavService, public router: Router) {
  }

  ngAfterViewInit() {
    this.navService.sidenav = this.sidenav;
    this.navService.orgItems = this.orgItems;
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

    this.navService.closeOrgMenu(0);
    // Navigate to route of selected item
    this.router.navigate([{outlets: {sidenav: items[0].route}}]);

  }

    // For debugging
    // oneNavItem: NavItem = new NavItem('Austin', 'location_city', 2);


    orgItems: Array<NavItem> = [

      new NavItem('Documentation', null, 0,
      [
        new NavItem('About', 'group', 1, 'info-city'),
        new NavItem('Github', 'school', 1, 'info-city')
      ]),

      new NavItem('Organizations', null, 0,
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
      ]),

      new NavItem('Tasks', null, 0,
      [
        new NavItem('Fix Transcript', 'group', 1, 'info-city'),
        new NavItem('Add Issue Tags', 'school', 1, 'info-city')
      ]),

    ];

}
