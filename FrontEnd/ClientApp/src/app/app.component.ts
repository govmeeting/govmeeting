import { Component, VERSION } from '@angular/core';
// import { NavItem } from './dashboard/dash-sidenav/sidenav-menu/nav-item';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
  public collapsed = true;
  version: string;

  constructor() {
    this.version = VERSION.full;
  }

//  toggleCollapsed() {
//    this.collapsed = !this.collapsed;
//   this.RunTestCode();
//  }

//   navItems1 = new Array();
//   navItems2: NavItem[];

//   navItems: Array<NavItem> = [
//     new NavItem('Government', 'group'),
//     new NavItem('Non-Government', 'group')
//   ];

//   RunTestCode() {

//   }
}
