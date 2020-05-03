import { Component, OnInit, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit, Input} from '@angular/core';
import { VERSION } from '@angular/material';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { NavItem, EntryType } from './nav-item';
import { NavService } from './nav.service';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';
//import { string } from '@amcharts/amcharts4/core';

import { navigationItems } from './menu-items';
import { MenuTreeArray } from './menu-tree-array'

import { MatDialog, MatDialogRef } from  '@angular/material';
import { PopupComponent } from '../popup/popup.component';

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
// export class SidenavMenuComponent implements AfterViewInit {
  export class SidenavMenuComponent {
    private ClassName: string = this.constructor.name + ": ";
    @ViewChild('appDrawer', {static: false})
    subscription: Subscription;
    navItems: any[] = [];
    sidenav: ElementRef;
    version = VERSION;
    navigationItems: NavItem[] = navigationItems;
    menuTreeArray: MenuTreeArray;
    deviceType: string;

  constructor(
    private navService: NavService,
    public router: Router,
    private userSettingsService: UserSettingsService,
    private  dialog:  MatDialog)
  {
      this.menuTreeArray = new MenuTreeArray();
      this.menuTreeArray.assignPositions(navigationItems);
      NoLog || console.log(this.ClassName + "navigationItems=", this.navigationItems);
      // let item: NavItem = this.menuTreeArray.getItem([1,3,1], this.navigationItems);
      // NoLog || console.log(this.ClassName + "selectedItem=", item);

      this.subscription = this.navService.getMenuSelection().subscribe(message => {
        if (message) {
          NoLog || console.log(this.ClassName + "navService message=", message);
          this.HandleSelection(message);
        } else {
          // clear messages when empty message received
          this.navItems = [];
        }
      });
    }

    ngOnInit() {
      this.navService.sidenav = this.sidenav;
      this.navService.navigationItems = this.navigationItems;
      this.navService.openFirstMenuLevels();
    }

  openDialog(){
    this.dialog.open(PopupComponent,{ data: {
      message:  "Error!!!"
    }});
  }

  HandleSelection(item: NavItem){
    let location: string;
    let agency: string;

    switch (item.entryType) {
      case EntryType.location: {
        NoLog || console.log(this.ClassName + "Selected location. Navigate to dashboard and set settings");
        this.router.navigate(['dashboard']);
        location = item.displayName;
        let userSettings: UserSettings = new UserSettings('en', location,  null);
        this.userSettingsService.settings = userSettings;

        break;
      }
      case EntryType.agency: {
        NoLog || console.log(this.ClassName + "Selected agency. Set new settings");
        agency = item.displayName;
        let parent = this.menuTreeArray.getParent(item, this.navigationItems);
        location = parent.displayName;
        let userSettings: UserSettings = new UserSettings('en', location,  agency);
        this.userSettingsService.settings = userSettings;
        break;
      }
      case EntryType.link: {
        NoLog || console.log(this.ClassName + "Selected a link");
        this.router.navigateByUrl(item.route);
        break;
      }
      case EntryType.docId: {
        // The assets/docs pages are handled by AboutProjectComponent which loads the markdown file.
        NoLog || console.log(this.ClassName + "Selected a link");
        let url = "/about?id=" + item.route;
        this.router.navigateByUrl(url);
        break;
      }

    }

    if (this.isMobile()) {
      this.navService.closeNav();
    }
  }

  private checkDeviceType() : DeviceType {
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

  private isMobile() {
    return (this.checkDeviceType() == DeviceType.mobile)
  }



}
