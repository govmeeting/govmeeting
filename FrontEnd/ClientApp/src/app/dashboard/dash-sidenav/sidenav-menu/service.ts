import {EventEmitter, Injectable} from '@angular/core';
import { NavItem } from './nav-item'

@Injectable()
export class NavService {
  public sidenav: any;
  public orgItems: NavItem[];

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
    this.closeMenu(this.orgItems, startDepth, maxDepth)
  }

  private closeMenu(
    items: NavItem[],
    startDepth: number,
    maxDepth: number
    ) {
    // console.log("closeMenux startDepth=" + startDepth + " maxDepth=" + maxDepth)
    items.forEach(item => {
      // console.log("item=" + item.displayName + " depth=" + item.depth)
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
