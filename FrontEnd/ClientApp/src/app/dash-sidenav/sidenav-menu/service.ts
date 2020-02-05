import {EventEmitter, Injectable} from '@angular/core';
import { NavItem } from './nav-item'

const NoLog = true;  // set to false for console logging

@Injectable()
export class NavService {
  private ClassName: string = this.constructor.name + ": ";

  public sidenav: any;
  public navigationItems: NavItem[];

  constructor() {
  }

  public closeNav() {
    this.sidenav.close();
  }

  public openNav() {
    this.sidenav.open();
  }

  public closeOrgMenu(
    startDepth: number,
    maxDepth: number = 99  // unspecified means all depths
    ) {
    this.closeMenu(this.navigationItems, startDepth, maxDepth)
  }

  private closeMenu(
    items: NavItem[],
    startDepth: number,
    maxDepth: number
    ) {
    NoLog || console.log(this.ClassName + "closeMenux startDepth=" + startDepth + " maxDepth=" + maxDepth)
    items.forEach(item => {
      NoLog || console.log(this.ClassName + "item=" + item.displayName + " depth=" + item.depth)
      if (item.depth >= startDepth) {
        item.expanded = false;
      }
      if ((item.children !== null) && (item.children !== undefined)){
        if (item.depth + 1 <= maxDepth) {
          this.closeMenu(item.children, item.depth + 1, maxDepth)
        }
      }
    })
  }
}
