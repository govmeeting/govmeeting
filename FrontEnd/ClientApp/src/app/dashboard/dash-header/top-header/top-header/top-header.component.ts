import { Component, OnInit } from '@angular/core';
import { SidenavService } from '../../../../services/sidenav.service';

@Component({
  selector: 'gm-top-header',
  templateUrl: './top-header.component.html',
  styleUrls: ['./top-header.component.scss']
})
export class TopHeaderComponent implements OnInit {

  // message:string;

  constructor(private data: SidenavService) { }

  ngOnInit() {
    // this.data.currentMessage.subscribe(message => this.message = message)
  }

  showSidebar() {
    this.data.changeMessage("Show")
  }
}


// Set constants and grab needed elements
// const sidenavEl = $('.sidenav');
// const gridEl = $('.grid');
// const SIDENAV_ACTIVE_CLASS = 'sidenav--active';
// const GRID_NO_SCROLL_CLASS = 'grid--noscroll';

/* toggleClass(el, className) {
  if (el.hasClass(className)) {
    el.removeClass(className);
  } else {
    el.addClass(className);
  }
}
 */
// If user opens the menu and then expands the viewport from mobile size without closing the menu,
// make sure scrolling is enabled again and that sidenav active class is removed
/* function addResizeListeners() {
  $(window).resize(function(e) {
    const width = window.innerWidth; console.log('width: ', width);

    if (width > 750) {
      sidenavEl.removeClass(SIDENAV_ACTIVE_CLASS);
      gridEl.removeClass(GRID_NO_SCROLL_CLASS);
    }
  });
}
 */
// Menu open sidenav icon, shown only on mobile
/* function setMenuClickListener() {
  $('.header__menu').on('click', function(e) { console.log('clicked menu icon');
    toggleClass(sidenavEl, SIDENAV_ACTIVE_CLASS);   // 'sidenav--active'
    toggleClass(gridEl, GRID_NO_SCROLL_CLASS);
  });
}
 */
// Sidenav close icon
/* function setSidenavCloseListener() {
  $('.sidenav__brand-close').on('click', function(e) {
    toggleClass(sidenavEl, SIDENAV_ACTIVE_CLASS);
    toggleClass(gridEl, GRID_NO_SCROLL_CLASS);
  });
}
 */

