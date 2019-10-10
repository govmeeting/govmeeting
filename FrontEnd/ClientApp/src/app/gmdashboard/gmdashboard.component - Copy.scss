// Sass tils
$color-fiord: #394263; // sidenav bg & dark text  // used also elsewhere
$color-white: #FFF; // card bg
$color-athens-gray: #EAEDF1; // content bg
$color-catskill-white: #F9FAFC; // top nav bg
$color-abbey: #777; // gray text                // used many places
$color-mischka: #DADAE3; // light gray for menu icon
$color-java: #1BBAE1; // blue text            // used many places
$color-mine-shaft: #333; // main section header bg
$color-cinnabar: #e74c3c; // main icon bg, red //used also elsewhere
$color-transparent: rgba(255, 255, 255, .5);   // used also elsewhere

// should not be needed in gmdashboard
// $color-jungle-green: #27ae60; // calendar icon bg
// $color-zest: #e67e22; // document icon bg
// $color-amethyst: #af64cc; // main photo icon bg
// $color-alto: #D3D3D3;

$height-header: 50px;
$height-footer: 50px;
$width-sidenav: 240px;   // used also in navlist.component.scss

@mixin profile-avatar {
  background-image: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/1609106/headshot.png");
  background-size: cover;
  background-repeat: no-repeat;
  border-radius: 50%;
  border: 2px solid rgba(255, 255, 255, .2);
}

// used also in user-dropdown.component.scss
@mixin box-shadow {
  box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.16), 0 0 0 1px rgba(0, 0, 0, 0.08);
}

// Resets
html, body {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Open Sans","Helvetica Neue",Helvetica,Arial,sans-serif
}

a {
  text-decoration: none;
}

// Util classes
.text-light {
  font-weight: 300;
}

.text-bold {
  font-weight: bold;
}

.row {
  display: flex;

  &--align-v-center {
    align-items: center;
  }

  &--align-h-center {
    justify-content: center;
  }
}

// Establish dashboard css grid layout - mobile
.grid {
  position: relative;
  display: grid;
  grid-template-columns: 100%; // Charts responsiveness won't work with fr units
  grid-template-rows: $height-header 1fr $height-footer;
  grid-template-areas:
    'header'
    'main'
    'footer';
  height: 100vh;
  overflow-x: hidden; // Prevent overflow scroll from hidden sidenav

  &--noscroll {
    overflow-y: hidden;
  }
}

.header {
  grid-area: header;
  display: flex;
  align-items: center;
  justify-content: space-between;
  background-color: $color-catskill-white;

  &__menu {
    position: fixed; // Needs to stay visible for all mobile scrolling
    padding: 13px;
    left: 12px;
    background-color: $color-mischka;
    border-radius: 50%;
    z-index: 1;

    &:hover {
      cursor: pointer;
    }
  }

  &__search {
    margin-left: 55px;
    font-size: 20px;
    color: $color-abbey;
  }

  &__input {
    border: none;
    background: transparent;
    padding: 12px;
    font-size: 20px;
    color: $color-abbey;

    &:focus {
      outline: none;
      border: none;
    }
  }

  &__avatar {
    @include profile-avatar;
    position: relative;
    margin: 0 26px;
    width: 35px;
    height: 35px;
    cursor: pointer;

    &:after {
      position: absolute;
      content: "";
      width: 6px;
      height: 6px;
      background: none;
      border-left: 2px solid $color-abbey;
      border-bottom: 2px solid $color-abbey;
      transform: rotate(-45deg) translateY(-50%);
      top: 50%;
      right: -18px;
    }
  }
}

// .dropdown {
//   position: absolute;
//   top: 54px;
//   right: -16px;
//   width: 220px;
//   height: auto;
//   z-index: 1;
//   background-color: #fff;
//   border-radius: 4px;
//   visibility: hidden;
//   opacity: 0;
//   transform: translateY(-10px);
//   transition: all .3s;
//   @include box-shadow;

//   &__list {
//     margin: 0;
//     padding: 0;
//     list-style-type: none;
//   }

//   &__list-item {
//     padding: 12px 24px;
//     color: $color-abbey;
//     text-transform: capitalize;

//     &:hover {
//       background-color: rgba(0,0,0, .1);
//     }
//   }

//   &__icon {
//     color: $color-java;
//   }

//   &__title {
//     margin-left: 10px;
//   }

//   &:before {
//     position: absolute;
//     content: "";
//     top: -6px;
//     right: 30px;
//     width: 0;
//     height: 0;
//     border-left: 4px solid transparent;
//     border-right: 4px solid transparent;
//     border-bottom: 6px solid #FFF;
//   }

//   &--active {
//     visibility: visible;
//     opacity: 1;
//     transform: translateY(0);
//   }
// }

.sidenav {
  position: fixed; // Access sidenav at any scroll position; relatively positioned on medium + screens
  grid-area: sidenav;
  height: 100%;
  overflow-y: auto;
  background-color: $color-fiord;
  color: $color-white;
  width: $width-sidenav; // Will match grid area on medium + screens
  transform: translateX(-245px);
  transition: all .6s ease-in-out;
  box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.16), 0 0 0 1px rgba(0, 0, 0, 0.08);
  z-index: 2; // Needs to sit above the hamburger menu icon

  &__brand {
    position: relative;
    display: flex;
    align-items: center;
    padding: 0 16px;
    height: $height-header;
    background-color: rgba(0, 0, 0, .15);

    &-icon {
      margin-top: 2px;
      font-size: 14px;
      color: $color-transparent;
    }

    &-close {
      position: absolute;
      right: 8px;
      top: 8px;
      visibility: visible;
      color: $color-transparent;
      cursor: pointer;
    }

    &-link {
      font-size: 18px;
      font-weight: bold;
      color: $color-white;
      margin: 0 15px;
      letter-spacing: 1.5px;
    }
  }

  &__profile {
    display: flex;
    align-items: center;
    min-height: 90px;
    background-color: rgba(255, 255, 255, .1);

    &-avatar {
      @include profile-avatar;
      height: 64px;
      width: 64px;
      margin: 0 15px;
    }

    &-title {
      font-size: 17px;
      letter-spacing: 1px;
    }
  }

  &__arrow {
    position: absolute;
    content: "";
    width: 6px;
    height: 6px;
    top: 50%;
    right: 20px;
    border-left: 2px solid rgba(255,255,255,.5);
    border-bottom: 2px solid rgba(255,255,255,.5);
    transform: translateY(-50%) rotate(225deg);
  }

  &__sublist {
    list-style-type: none;
    margin: 0;
    padding: 10px 0 0;
  }

  &--active {
    transform: translateX(0);
  }
}

// .navList {
//   width: $width-sidenav;
//   padding: 0;
//   margin: 0;
//   background-color: $color-fiord;
//   list-style-type: none;

//   &__heading {
//     position: relative;
//     display: flex;
//     align-items: center;
//     justify-content: space-between;
//     padding: 16px 16px 3px;
//     color: $color-transparent;
//     text-transform: uppercase;
//     font-size: 15px;
//   }

//   &__subheading {
//     position: relative;
//     padding: 10px 30px;
//     color: #fff;
//     font-size: 16px;
//     text-transform: capitalize;

//     &-icon {
//       display: flex;
//       align-items: center;
//       justify-content: center;
//       font-size: 12px;
//       color: $color-transparent;
//       width: 12px; // Keep spacing consistent
//     }

//     &-title {
//       margin: 0 15px;
//     }

//     &:after {
//       position: absolute;
//       content: "";
//       height: 6px;
//       width: 6px;
//       top: 17px;
//       right: 25px;
//       border-left: 1px solid $color-transparent;
//       border-bottom: 1px solid $color-transparent;
//       transform: rotate(225deg);
//       transition: all .2s;
//     }

//     &:hover {
//       background-color: darken($color-fiord, 5%);
//       cursor: pointer;
//     }

//     &--open {
//       background-color: darken($color-fiord, 5%);

//       &:after {
//         transform: rotate(315deg);
//       }
//     }
//   }

//   .subList {
//     padding: 0;
//     margin: 0;
//     list-style-type: none;
//     background-color: darken($color-fiord, 10%);
//     visibility: visible;
//     overflow: hidden;
//     max-height: 200px;
//     transition: all .4s ease-in-out;

//     &__item {
//       padding: 8px;
//       text-transform: capitalize;
//       padding: 8px 30px;
//       color: $color-alto;

//       &:first-child {
//         padding-top: 15px;
//       }

//       &:hover {
//         background-color: rgba(255, 255, 255, .1);
//         cursor: pointer;
//       }
//     }

//     &--hidden {
//       visibility: hidden;
//       max-height: 0;
//     }
//   }
// }

// Dashboard content wrapper
.main {
  grid-area: main;
  background-color: $color-athens-gray;
  color: $color-fiord;

  &__cards {
    display: block;
    column-count: 1;
    column-gap: 20px;
    margin: 20px;
  }
}

.main-header {
  position: relative;
  display: flex;
  justify-content: space-between;
  height: 250px;
  color: $color-white;
  background-size: cover;
  background-image: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/1609106/lake-shadow-water.jpg");
  margin-bottom: 20px;

  &__intro-wrapper {
    display: flex;
    flex: 1;
    flex-direction: column; // Mobile-first; break out to row on medium + screens
    align-items: center;
    justify-content: space-between;
    height: 160px;
    padding: 12px 30px;
    background: rgba(255,255,255,.12);
    font-size: 26px;
    letter-spacing: 1px;
  }

  &__welcome {
    display: flex;
    flex-direction: column;
    align-items: center;

    &-title {
      margin-bottom: 8px;
      font-size: 26px;
    }

    &-subtitle {
      font-size: 18px;
    }
  }
}

// Main header quick view update items
// .quickview {
//   display: grid;
//   grid-auto-flow: column;
//   grid-gap: 60px;

//   &__item {
//     display: flex;
//     align-items: center;
//     flex-direction: column;

//     &-total {
//       margin-bottom: 2px;
//       font-size: 32px;
//     }

//     &-description {
//       font-size: 16px;
//       text-align: center;
//     }
//   }
// }

// Overview quicklink cards container
// .main-overview {
//   display: grid;
//   grid-template-columns: repeat(auto-fit, minmax(265px, 1fr));
//   grid-auto-rows: 94px;
//   grid-gap: 30px;
//   margin: 20px;
// }

// .overviewCard {
//   display: flex;
//   align-items: center;
//   justify-content: space-between;
//   padding: 12px;
//   background-color: $color-white;
//   transform: translateY(0);
//   transition: all .3s;

//   &-icon {
//     display: flex;
//     align-items: center;
//     justify-content: center;
//     height: 60px;
//     width: 60px;
//     border-radius: 50%;
//     font-size: 21px;
//     color: #fff;

//     &--document {
//       background-color: $color-zest;
//     }

//     &--calendar {
//       background-color: $color-jungle-green;
//     }

//     &--mail {
//       background-color: $color-cinnabar;
//     }

//     &--photo {
//       background-color: $color-amethyst;
//     }
//   }

//   &-description {
//     display: flex;
//     flex-direction: column;
//     align-items: center;
//   }

//   &-title {
//     font-size: 18px;
//     color: $color-java;
//     margin: 0;
//   }

//   &-subtitle {
//     margin: 2px;
//     color: $color-abbey;
//   }

//   &:hover {
//     transform: translateY(-3px);
//     box-shadow: 0 5px 5px rgba(0,0,0,.1);
//     cursor: pointer;
//   }
// }

/* .card {
  display: flex;
  flex-direction: column;
  width: 100%;
  background-color: #fff;
  margin-bottom: 20px;
  -webkit-column-break-inside: avoid;

  &__header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    height: 50px;
    background-color: $color-fiord;
    color: $color-white;

    &-title {
      margin: 0 20px;
      font-size: 20px;
      letter-spacing: 1.2px;
    }

    &-link {
      font-size: 16px;
      color: $color-java;
      letter-spacing: normal;
      display: inline-block;
    }
  }

  &__main {
    position: relative;
    padding-right: 20px;
    background-color: $color-white;

    &:after {
      content: "";
      position: absolute;
      top:0;
      left: 120px;
      bottom: 0;
      width: 2px;
      background-color: #f0f0f0;
    }
  }

  &__secondary {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(100px, 1fr));
    grid-auto-rows: 100px;
    grid-gap: 25px;
    padding: 20px;
    background-color: $color-white;
  }

  &__photo {
    // background-image: url('../../img/pumpkin-carving.jpg');
    background-size: cover;
    background-repeat: no-repeat;
    background-color: slategray;
    // overflow: hidden;
    transform: scale(1);
    transition: transform .3s ease-in-out;
    width: 100%;
    height: 100%;

    &:hover {
      transform: scale(1.1);
      cursor: pointer;
    }
  }

  &__photo-wrapper {
    overflow: hidden;
  }

  &__row {
    position: relative;
    display: flex;
    flex: 1;
    margin: 15px 0 20px;
  }

  &__icon {
    position: absolute;
    display: flex;
    align-items: center;
    justify-content: center;
    content: "";
    width: 30px;
    height: 30px;
    top: 0;
    left: 121px;
    transform: translateX(-50%);
    border-radius: 50%;
    color: $color-white;
    background-color: $color-java;
    z-index: 1;
  }

  &__row:nth-child(even) {
    .card__icon {
      background-color: $color-cinnabar;
    }
  }

  &__time {
    display: flex;
    flex: 1;
    justify-content: flex-end;
    max-width: 80px;
    margin-left: 15px;
    text-align: right;
    font-size: 14px;
    line-height: 2;
  }

  &__detail {
    display: flex;
    flex: 1;
    flex-direction: column;
    padding-left: 12px;
    margin-left: 48px;
    transform: translateX(0);
    transition: all .3s;

    &:hover {
      background-color: #f0f0f0;
      transform: translateX(4px);
      cursor: pointer;
    }
  }

  &__source {
    line-height: 1.8;
    color: $color-java;
  }

  // &__description {

  // }

  &__note {
    margin: 10px 0;
    color: $color-abbey;
  }

  &--finance {
    position: relative;
  }
}
 */
// Card header settings icons
/* .settings {
  display: flex;
  margin: 8px;
  align-self: flex-start;
  background-color: $color-transparent;
  border: 1px solid rgba(0,0,0,.1);
  border-radius: 2px;

  &__block {
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 4px;
    color: $color-fiord;
    font-size: 11px;

    &:not(:last-child) {
      border-right: 1px solid rgba(0,0,0,.1);
    }
  }

  &__icon {
    padding: 0px 3px;
    font-size: 12px;

    &:hover {
      background-color: rgba(255,255,255,.8);
      cursor: pointer;
    }
  }

  &:hover {
    background-color: #fff;
    cursor: pointer;
  }
}
 */

 .documents {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(105px, 1fr));
  grid-auto-rows: 214px;
  grid-gap: 12px;
  height: auto;
  background-color: $color-white;
}

.document {
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 15px 0 0;
  flex-direction: column;

  &__img {
    width: 105px;
    height: 136px;
    background-image: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/1609106/doc-1.png");
    background-size: cover;
    box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 3px 1px -2px rgba(0, 0, 0, 0.12), 0 1px 5px 0 rgba(0, 0, 0, 0.2);
    cursor: pointer;
    transition: transform .3s ease;

    &:hover {
      transform: translateY(-4px);
    }
  }

  &__title {
    margin: 8px 0 2px;
    color: $color-abbey;
  }

  &__date {
    font-size: 10px;
  }
}

// Styles for example chart
#chartdiv {
  width: 100%;
  height: 300px;
  font-size: 11px;
  min-width: 0;
}

.footer {
  grid-area: footer;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 16px;
  color: $color-abbey;
  background-color: $color-white;

  &__copyright {
    color: $color-java;
  }

  &__icon {
    color: $color-cinnabar;
  }

  &__signature {
    color: $color-java;
    cursor: pointer;
    font-weight: bold;
  }
}

// Mobile screen breakpoints (750px)
@media only screen and (min-width: 46.875em) {
  // Break out to sidenav grid layout on medium + screens
  .grid {
    display: grid;
    grid-template-columns: $width-sidenav calc(100% - 240px); // Charts responsiveness won't work with fr units
    grid-template-rows: $height-header 1fr $height-footer;
    grid-template-areas:
      'sidenav header'
      'sidenav main'
      'sidenav footer';
    height: 100vh;
  }

  .sidenav {
    position: relative;
    transform: translateX(0);

    &__brand-close {
      visibility: hidden;
    }
  }

  .main-header {
    &__intro-wrapper {
      padding: 0 30px;
    }
  }

  .header {
    &__menu {
      display: none;
    }

    &__search {
      margin-left: 20px; // No menu icon; move 'er back over
    }

    &__avatar {
      width: 40px;
      height: 40px;
    }
  }
}

// Medium screens breakpoint (1050px)
@media only screen and (min-width: 65.625em) {
  .main {
    &__cards {
      column-count: 2;
    }
  }

  .main-header {
    &__intro-wrapper {
      flex-direction: row;
    }

    &__welcome {
      align-items: flex-start;
    }
  }
}
