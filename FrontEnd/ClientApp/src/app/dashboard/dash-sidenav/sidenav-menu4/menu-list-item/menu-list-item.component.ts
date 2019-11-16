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
  expanded: boolean;
  @HostBinding('attr.aria-expanded') ariaExpanded = this.expanded;
  @Input() item: NavItem;
  @Input() depth: number;
  @Output() valueChange = new EventEmitter();

  constructor(public navService: NavService,
              public router: Router) {
    if (this.depth === undefined) {
      this.depth = 0;
    }
  }

  onItemSelected(item: NavItem) {
    if (!item.children || !item.children.length) {
      // this.router.navigate([item.route]);
      this.router.navigate([{outlets: {sidenav: item.route}}]);
      // this.valueChange.emit(item);
      console.log(item);
      console.log("OnItemSelected");
      this.navService.closeNav();
    }
    if (item.children && item.children.length) {
      this.expanded = !this.expanded;
    }
  }
}
