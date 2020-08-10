/* Scripts for css grid dashboard */

const NoLog = true; // set to false for console logging

$(document).ready(() => {
  // addResizeListeners();
  // setSidenavListeners();
  // setMenuClickListener();
  // setSidenavCloseListener();
});

// Set constants and grab needed elements
const sidenavEl = $('.sidenav');
const gridEl = $('.grid');
const sidenav_ACTIVE_CLASS = 'sidenav--active';
const GRID_NO_SCROLL_CLASS = 'grid--noscroll';

function toggleClass(el, className) {
  if (el.hasClass(className)) {
    el.removeClass(className);
  } else {
    el.addClass(className);
  }
}

// If user opens the menu and then expands the viewport from mobile size without closing the menu,
// make sure scrolling is enabled again and that sidenav active class is removed
function addResizeListeners() {
  $(window).resize(function (e) {
    const width = window.innerWidth;
    NoLog || console.log(this.ClassName + 'width: ', width);

    if (width > 750) {
      sidenavEl.removeClass(sidenav_ACTIVE_CLASS);
      gridEl.removeClass(GRID_NO_SCROLL_CLASS);
    }
  });
}

// Menu open sidenav icon, shown only on mobile
function setMenuClickListener() {
  $('.header__menu').on('click', function (e) {
    NoLog || console.log(this.ClassName + 'clicked menu icon');
    toggleClass(sidenavEl, sidenav_ACTIVE_CLASS);
    toggleClass(gridEl, GRID_NO_SCROLL_CLASS);
  });
}

// Sidenav close icon
function setSidenavCloseListener() {
  $('.sidenav__brand-close').on('click', function (e) {
    toggleClass(sidenavEl, sidenav_ACTIVE_CLASS);
    toggleClass(gridEl, GRID_NO_SCROLL_CLASS);
  });
}

// I will most likely replace his navigation menu with one base on Angular Material.
// Sidenav list sliding functionality
function setSidenavListeners() {
  const subHeadings = $('.navList__subheading');
  NoLog || console.log(this.ClassName + 'subHeadings: ', subHeadings);
  const SUBHEADING_OPEN_CLASS = 'navList__subheading--open';
  const SUBLIST_HIDDEN_CLASS = 'subList--hidden';

  subHeadings.each((i, subHeadingEl) => {
    $(subHeadingEl).on('click', (e) => {
      const subListEl = $(subHeadingEl).siblings();

      // Add/remove selected styles to list category heading
      if (subHeadingEl) {
        toggleClass($(subHeadingEl), SUBHEADING_OPEN_CLASS);
      }

      // Reveal/hide the sublist
      if (subListEl && subListEl.length === 1) {
        toggleClass($(subListEl), SUBLIST_HIDDEN_CLASS);
      }
    });
  });
}
