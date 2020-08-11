import { Component, HostBinding, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { NavItem } from '../nav-item';
import { Router } from '@angular/router';
import { NavService } from '../nav.service';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { UserSettingsService } from '../../common/user-settings.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-menu-list-item',
  templateUrl: './menu-list-item.html',
  styleUrls: ['./menu-list-item.scss'],
  animations: [
    trigger('indicatorRotate', [
      state('collapsed', style({ transform: 'rotate(0deg)' })),
      state('expanded', style({ transform: 'rotate(180deg)' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4,0.0,0.2,1)')),
    ]),
  ],
})
export class MenuListItemComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  @Input() item: NavItem;
  // @HostBinding('attr.aria-expanded') ariaExpanded = this.item.expanded;
  @Input() depth: number;
  displayNameClass: string;
  disabled = false;
  grayout = '';

  constructor(public navService: NavService, public router: Router) {}

  ngOnInit() {
    // this.item.depth = this.depth;
    this.displayNameClass = 'depth' + this.item.depth;
    NoLog || console.log(this.ClassName, 'NgOnInit DisplayName=' + this.item.displayName);
    this.disableStateFederalNongov(this.item);
  }

  // THese are temporarily disabled. It's less confusing than clicking on these links,
  // only to find that none of the cards have meaningful data. We need sample data for
  // these locations.
  disableStateFederalNongov(item: NavItem) {
    if (['State of Maine', 'United States', 'Glendale HOA'].includes(item.displayName)) {
      this.disabled = true;
      this.grayout = 'grayed-out';
      // this.displayNameClass = this.displayNameClass + " grayed-out"
    }
  }

  onItemSelected(item: NavItem) {
    NoLog || console.log(this.ClassName + 'OnItemSelected selectedItem=', item);
    NoLog || console.log(this.ClassName + 'OnItemSelected myself=', this.item);

    if (item.displayName === 'Select Location') {
      this.navService.sendMenuSelection(item);
    }

    if (item.children && item.children.length) {
      // If this item has children, toggle expansion of child items.
      NoLog || console.log(this.ClassName + 'item has children');
      if (item.expanded) {
        NoLog || console.log(this.ClassName + 'item expanded: close it');
        item.expanded = false;
      } else {
        NoLog || console.log(this.ClassName + 'item not expanded: close menu & expand it');
        this.navService.closeMenu(1);
        item.expanded = true;
      }
    } else {
      // Otherwise, the user has made the final selection.
      this.navService.sendMenuSelection(item);
    }
  }
}
