import { Component, OnInit, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { GetDeviceType } from '../common/get-device-type';
import { NavItem, EntryType } from './nav-item';
import { NavService } from './nav.service';
import { UserSettingsService, UserSettings, LocationType } from '../common/user-settings.service';
import { NavigationItems, NavigationItemsBeta } from './menu-items-all';
import { MenuTreeArray } from './menu-tree-array';
import { AppData } from '../appdata';

// // This is for an experiment, opening a dialog box.
// import { MatDialog, MatDialogRef } from '@angular/material/dialog';
// import { PopupComponent } from '../work_experiments/popup/popup.component';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-sidenav-menu',
  templateUrl: 'sidenav-menu.html',
  styleUrls: ['sidenav-menu.scss'],
  encapsulation: ViewEncapsulation.None,
})
// export class SidenavMenuComponent implements AfterViewInit {
export class SidenavMenuComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  isBeta: boolean;
  @ViewChild('appDrawer', { static: false })
  subscription: Subscription;
  sidenav: ElementRef;
  navigationItems: NavItem[];
  menuTreeArray: MenuTreeArray;

  constructor(
    private navService: NavService,
    public router: Router,
    private userSettingsService: UserSettingsService,
    private appData: AppData // This is for an experiment, opening a dialog box. // private dialog: MatDialog
  ) {
    this.navigationItems = appData.isBeta ? NavigationItemsBeta : NavigationItems;
    this.menuTreeArray = new MenuTreeArray();
    this.menuTreeArray.assignPositions(this.navigationItems);
    NoLog || console.log(this.ClassName + 'navigationItems=', this.navigationItems);
    // let item: NavItem = this.menuTreeArray.getItem([1,3,1], this.navigationItems);
    // NoLog || console.log(this.ClassName + "selectedItem=", item);

    this.subscription = this.navService.getMenuSelection().subscribe((message) => {
      if (message) {
        NoLog || console.log(this.ClassName + 'navService message=', message);
        this.HandleSelection(message);
      }
    });
  }

  ngOnInit() {
    this.navService.sidenav = this.sidenav;
    this.navService.navigationItems = this.navigationItems;
    this.navService.openFirstMenuLevels(); // set default view of menu.
  }

  HandleSelection(item: NavItem) {
    let location: string;
    let agency: string;

    switch (item.entryType) {
      case EntryType.location: {
        NoLog || console.log(this.ClassName + 'Selected location. Navigate to dashboard and set settings');
        this.router.navigate(['dashboard']);
        location = item.displayName;
        const userSettings: UserSettings = new UserSettings('en', location, null);
        this.userSettingsService.settings = userSettings;

        break;
      }
      case EntryType.agency: {
        NoLog || console.log(this.ClassName + 'Selected agency. Set new settings');
        agency = item.displayName;
        const parent = this.menuTreeArray.getParent(item, this.navigationItems);
        location = parent.displayName;
        const userSettings: UserSettings = new UserSettings('en', location, agency);
        this.userSettingsService.settings = userSettings;
        break;
      }
      case EntryType.link: {
        NoLog || console.log(this.ClassName + 'Selected a link');
        this.router.navigateByUrl(item.route);
        break;
      }
      case EntryType.docId: {
        // The assets/docs pages are handled by AboutProjectComponent which loads the markdown file.
        NoLog || console.log(this.ClassName + 'Selected a link');
        const url = '/about?id=' + item.route;
        this.router.navigateByUrl(url);
        break;
      }
    }

    if (GetDeviceType.isMobile()) {
      this.navService.closeNav();
    }
  }

  // // This is for an experiment, opening a dialog box.
  // openDialog() {
  //   this.dialog.open(PopupComponent, {
  //     data: {
  //       message: 'Error!!!',
  //     },
  //   });
  // }
}
