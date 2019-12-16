import {Component, HostBinding, Input, OnInit, EventEmitter, Output } from '@angular/core';
import {NavItem} from '../nav-item';
import {Router} from '@angular/router';
import {NavService} from '../nav.service';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-menu-list-item',
  templateUrl: './menu-list-item.component.html',
  styleUrls: ['./menu-list-item.component.scss'],
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
  // expandedx: boolean = false;
  @Input() item: NavItem;
  // @HostBinding('attr.aria-expanded') ariaExpanded = this.item.expanded;
  @Input() depth: number;
  @Output() finalSelection = new EventEmitter();

  displayNameClass: string;
  navItems: Array<NavItem> = new Array<NavItem>();

  constructor(public navService: NavService,
              public router: Router) {
    if (this.depth === undefined) {
      this.depth = 0;
    }
  }

  ngOnInit() {
    this.displayNameClass = 'depth' + this.depth;
    console.log(this.item.displayName),
    console.log("route=" + this.item.route);
    console.log(this.router.isActive(this.item.route, true))
  }

  OnFinalSelection(items: Array<NavItem> ){
    // console.log("====OnEmitted(menulist):");
    // console.log('my item');
    // console.log(this.item);
    // console.log('received emitted item');
    // console.log(items);

    // Some descendent was selected. Append myself to the
    // item array and send it to my parent.
    items.push(this.item);    // add my item to the array.
    this.finalSelection.emit(items);
}

  onItemSelected(item: NavItem) {

    // It this item has children, show them
    if (item.children && item.children.length) {
      // this.expandedx = !this.expandedx;
      item.expanded = !item.expanded;

    // Otherwise, the user has made the final selection.
    } else {
      // Display info on selection in sidenav
      this.router.navigate([item.route]);
      this.router.navigate([{outlets: {sidenav: item.route}}]);

      // console.log("====OnItemSelected(before emit):");
      // console.log('my item');
      // console.log(this.item);
      // console.log('sending emitted item');
      // console.log(item);

      // Put myself onto the navItems array.
      // Since I was just selected, I am the only entry so far
      this.navItems.push(item);

      // Tell my parent that the user made a selection and
      // send her the navItems array. This calls "OnEmitted()" on my parent.
      // My parent will append herself and send the array to her parent.
      this.finalSelection.emit(this.navItems);

      // Close the sidenav
      // this.navService.closeNav();
    }
  }
}
