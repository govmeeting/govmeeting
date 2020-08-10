import { EventEmitter, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { NavItem } from './nav-item';

const NoLog = true; // set to false for console logging

@Injectable()
export class NavService {
  private ClassName: string = this.constructor.name + ': ';

  public sidenav: any;
  public navigationItems: NavItem[];
  private subject = new Subject<NavItem>();

  constructor() {}

  public closeNav() {
    this.sidenav.close();
  }

  public openNav() {
    this.sidenav.open();
  }

  public closeMenu(
    startDepth: number,
    maxDepth: number = 99 // unspecified means all depths
  ) {
    this._closeMenu(this.navigationItems, startDepth, maxDepth);
  }

  public sendMenuSelection(item: NavItem) {
    this.subject.next(item);
  }

  public getMenuSelection(): Observable<NavItem> {
    return this.subject.asObservable();
  }

  public openFirstMenuLevels() {
    // Default view of the sidenav menu.
    //    The "About" list is closed.
    //    The "Select Location" list is open.
    this.navigationItems[0].expanded = false;
    this.navigationItems[1].expanded = true;
  }

  clearMenuSelections() {
    this.subject.next();
  }

  private _closeMenu(items: NavItem[], startDepth: number, maxDepth: number) {
    NoLog || console.log(this.ClassName + '_closeMenu startDepth=' + startDepth + ' maxDepth=' + maxDepth);
    items.forEach((item) => {
      NoLog || console.log(this.ClassName + 'item=' + item.displayName + ' depth=' + item.depth);
      if (item.depth >= startDepth) {
        item.expanded = false;
      }
      if (item.children !== null && item.children !== undefined) {
        if (item.depth + 1 <= maxDepth) {
          this._closeMenu(item.children, item.depth + 1, maxDepth);
        }
      }
    });
  }
}
