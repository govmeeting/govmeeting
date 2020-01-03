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

    // If the menu selection is "Select Location" -> "Austin" -> "City Council"
    // then the array will contain: ["City Council", "Austin", "Select Location"]
    // and then we just want "Austin; City Council" as the parameter to pass in
    // the router.navigate call.
    for(var i = (items.length -2); i >= 0; i--)
    {
      console.log(items[i]);
      selected = selected + items[i].displayName + ((i !=0) ? ' ; ' : '');
    }
    console.log("itemSelected: " + selected);

    // selected = selected.replace('Select Location','');
    this.itemSelected = selected;


    this.navService.closeOrgMenu(0);
    // Navigate to route of selected item
    // this.router.navigate([{outlets: {sidenav: items[0].route}}]);
    // this.router.navigateByUrl("dashboard/infocounty");
    // this.router.navigateByUrl(items[0].route);
    // this.router.navigateByUrl("dashboard/govinfo");
    this.router.navigate(['dashboard/govinfo', selected]);
  }

    // For debugging
    // oneNavItem: NavItem = new NavItem('Austin', 'location_city', 2);


    orgItems: Array<NavItem> = [


      new NavItem('Select Location', null, 0,
    [
      new NavItem('Austin', 'location_city', 1,
      [
        new NavItem('City Council', 'group', 2, 'dashboard/govinfo'),
        new NavItem('Board of Education', 'school', 2, 'dashboard/govinfo'),
        new NavItem('Planning Board', 'group', 2, 'dashboard/govinfo'),
        new NavItem('All Depts.', 'group', 2, 'dashboard/govinfo'),
      ]),
      new NavItem('Traves County', 'group', 1,
      [
        new NavItem('Commissioners', 'group', 2, 'dashboard/infocounty'),
        new NavItem('Transportation', 'group', 2, 'dashboard/infocounty'),
        new NavItem('Both Depts.', 'group', 2, 'dashboard/infocounty'),
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

      new NavItem('Transcripts', null, 0,
      [
        new NavItem('Proofread', 'group', 1, 'info-city'),
        new NavItem('Add Issue Tags', 'school', 1, 'info-city'),
        new NavItem('Browse', 'school', 1, 'info-city')
      ]),

      new NavItem('Documentation', null, 0,
      [
        new NavItem('About', 'group', 1, 'info-city'),
        new NavItem('Github', 'school', 1, 'info-city')
      ])


    ];

}
