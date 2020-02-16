import {Component, HostBinding, Input, OnInit, EventEmitter, Output } from '@angular/core';
import {NavItem} from '../nav-item';
import {Router} from '@angular/router';
import {NavService} from '../nav.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { UserSettingsService } from '../../../user-settings.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'app-menu-list-item',
  templateUrl: './menu-list-item.html',
  styleUrls: ['./menu-list-item.scss'],
  animations: [
    trigger('indicatorRotate', [
      state('collapsed', style({transform: 'rotate(0deg)'})),
      state('expanded', style({transform: 'rotate(180deg)'})),
      transition('expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4,0.0,0.2,1)')
      ),
    ])
  ]
})
export class MenuListItemComponent {
  private ClassName: string = this.constructor.name + ": ";
  @Input() item: NavItem;
  // @HostBinding('attr.aria-expanded') ariaExpanded = this.item.expanded;
  @Input() depth: number;
  //@Output() finalSelection = new EventEmitter();

  displayNameClass: string;
  //navItems: Array<NavItem> = new Array<NavItem>();

  constructor(public navService: NavService,
              public router: Router,
              private userSettingsService: UserSettingsService
              ) {
    // if (this.depth === undefined) {
    //   this.depth = 0;
    // }
  }

  ngOnInit() {
    // this.item.depth = this.depth;
    this.displayNameClass = 'depth' + this.item.depth;
    NoLog || console.log(this.ClassName, "NgOnInit DisplayName=" + this.item.displayName);
    // NoLog || console.log(this.ClassName + "NgOnInit route=", this.item.route);
    // NoLog || console.log(this.ClassName, "NgOnInit route-active=" + this.router.isActive(this.item.route, true));
  }

  OnFinalSelection(items: Array<NavItem> ){
    NoLog || console.log(this.ClassName + "OnFinalSelection item=", this.item);
    NoLog || console.log(this.ClassName + "OnFinalSelection items=", items);

    // Some descendent was selected. Append myself to the
    // item array and send it to my parent.
    //items.push(this.item);    // add my item to the array.
    //this.finalSelection.emit(items);
}

  onItemSelected(item: NavItem) {
    NoLog || console.log(this.ClassName + "OnItemSelected selectedItem=", item);
    NoLog || console.log(this.ClassName + "OnItemSelected myself=", this.item);

    if (item.displayName == "Select Location"){
      NoLog || console.log(this.ClassName + "navigate to dashboard");
      this.router.navigate(['dashboard']);
    }

    if (item.children && item.children.length) {
      NoLog || console.log(this.ClassName + "item has children");
      if (item.expanded) {
        NoLog || console.log(this.ClassName + "item expanded: close it");
        item.expanded = false;
      } else {
        NoLog || console.log(this.ClassName + "item not expanded: close menu & expand it");
        this.navService.closeMenu(1);
        item.expanded = true;
      }

    // Otherwise, the user has made the final selection.
    } else {
      // Put myself onto the navItems array.
      // Since I was just selected, I am the only entry so far
      //this.navItems.push(item);

      // Tell my parent that the user made a selection and
      // send the navItems array. This calls "OnEmitted()" on my parent.
      // My parent will append herself and send the array to their parent.
      //this.finalSelection.emit(this.navItems);
      this.navService.sendMenuSelection(item);
    }
  }

}
