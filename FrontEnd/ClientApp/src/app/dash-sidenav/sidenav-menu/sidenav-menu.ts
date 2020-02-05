import {Component, OnInit, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit} from '@angular/core';
import {VERSION} from '@angular/material';
import {Router} from '@angular/router';

import {NavItem} from './nav-item';
import {NavService} from './service';
import { MessageService } from '../../message.service';
import { string } from '@amcharts/amcharts4/core';

import { navigationItems } from './menu-items';

enum DeviceType{
  desktop,
  tablet,
  mobile
}

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-sidenav-menu',
  templateUrl: 'sidenav-menu.html',
  styleUrls: ['sidenav-menu.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidenavMenuComponent implements AfterViewInit {
  private ClassName: string = this.constructor.name + ": ";
  @ViewChild('appDrawer', {static: false})
  sidenav: ElementRef;
  version = VERSION;

  itemSelected: string = '';
  navigationItems: NavItem[] = navigationItems;

  deviceType: string;

  constructor(private navService: NavService, public router: Router, private messageService: MessageService) {
  }

  checkDeviceType() : DeviceType {
    var width = window.innerWidth;
    var deviceType;
    if (width <= 768) {
      deviceType = DeviceType.mobile;
      this.deviceType = "Mobile";
      NoLog || console.log(this.ClassName + 'mobile device detected')
    } else if (width > 768 && width <= 992) {
      deviceType = DeviceType.tablet;
      this.deviceType = "Tablet";
      NoLog || console.log(this.ClassName + 'tablet detected')
    } else {
      deviceType = DeviceType.desktop;
      this.deviceType = "Desktop";
      NoLog || console.log(this.ClassName + 'desktop detected')
    }
    return deviceType;
  }

  isMobile() {
    return (this.checkDeviceType() == DeviceType.mobile)
  }

  ngAfterViewInit() {
    this.navService.sidenav = this.sidenav;
    this.navService.navigationItems = this.navigationItems;
  }

  OnFinalSelection(items: Array<NavItem>){
    NoLog || console.log(this.ClassName + "====OnEmitted(sidenav): ");
    NoLog || console.log(this.ClassName, items);
    NoLog || console.log(this.ClassName + "org:" + this.navigationItems[0].displayName)

    // this.navService.closeOrgMenu(0);

    let submenu = items[items.length -1].displayName;
    switch (submenu){

      // If the user selected a new location, send a message to the components that need to be updated.
      case 'Select Location': {
          this.router.navigate(['dashboard']);
          let agency = items[0].displayName;
          let location = items[1].displayName;
          NoLog || console.log(this.ClassName + "location=" + location + " agency="+agency)
          this.messageService.sendMessage('AgencySelected:' + location + ':' + agency);
          break;
        }

      // If the user selected a new About page, navigate to it.
      case 'About': {
        let AboutDoc = items[0].displayName;
        switch (AboutDoc) {
          case 'Purpose': {
            this.router.navigateByUrl('purpose');
            break;
          }
          case 'Overview': {
            this.router.navigateByUrl('overview');
            break;
          }
          case 'Workflow': {
            this.router.navigateByUrl('workflow');
            break;
          }
          case 'Auto Processing': {
            this.router.navigateByUrl('autoprocessing');
            break;
          }
          case 'Manual Processing': {
            this.router.navigateByUrl('manualprocessing');
            break;
          }
          case 'Extend Govmeeting': {
            this.router.navigateByUrl('extendgovmeeting');
            break;
          }
          case '[All Pages]': {
            this.router.navigateByUrl('about');
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
    if (this.isMobile()) {
      this.navService.closeNav();
    }
}


}
