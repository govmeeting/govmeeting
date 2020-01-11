import {Component, OnInit, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit} from '@angular/core';
import {VERSION} from '@angular/material';
import {Router} from '@angular/router';

import {NavItem} from './nav-item';
import {NavService} from './service';
import { MessageService } from '../../message.service';

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

  constructor(private navService: NavService, public router: Router, private messageService: MessageService) {
  }

  ngAfterViewInit() {
    this.navService.sidenav = this.sidenav;
    this.navService.orgItems = this.orgItems;
  }

  OnFinalSelection(items: Array<NavItem>){
    console.log("====OnEmitted(sidenav): ");
    console.log(items);

    this.navService.closeOrgMenu(0);

    let submenu = items[items.length -1].displayName;
    switch (submenu){
      case 'Select Agency': {
          this.router.navigate(['dashboard']);
          let agency = items[0].displayName;
          let location = items[1].displayName;
          console.log("location=" + location + " agency="+agency)
          this.messageService.sendMessage('AgencySelected:' + location + ':' + agency);
          break;
        }
        case 'Transcripts': {
          let transcriptTask = items[0].displayName;
          switch (transcriptTask) {
            case 'Proofread': {
              this.router.navigateByUrl('fixasr');
              break;
            }
            case 'Add Issue Tags': {
              this.router.navigateByUrl('addtags');
              break;
            }
            case 'Browse': {
              this.router.navigateByUrl('viewmeeting');
              break;
            }
          }
          break;
        }
        case 'Documentation': {
          this.router.navigateByUrl('about');
          break;
        }
      }
    }
    // this.router.navigate(['dashboard/govinfo', location, agency]);

    // this.router.navigateByUrl('dashboard/(bills:bills//meetings:meetings)');


    // this.router.navigateByUrl('dashboard/(meetings:meetings)');
    // this.router.navigate([{outlets: {'dashboard/bills': "bills"}}]);

    // For debugging
    // oneNavItem: NavItem = new NavItem('Austin', 'location_city', 2);


    orgItems: Array<NavItem> = [


      new NavItem('Select Agency', null, 0,
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

      new NavItem('Documentation', null, 0)
      // [
      //   new NavItem('About', 'group', 1, 'info-city'),
      //   new NavItem('Github', 'school', 1, 'info-city')
      // ])


    ];

}
