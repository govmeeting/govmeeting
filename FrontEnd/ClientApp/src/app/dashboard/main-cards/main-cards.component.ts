import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-main-cards',
  template:  `
  <style>
    $color-athens-gray: #EAEDF1;
    $color-fiord: #394263;
    .main {
    //grid-area: main;
    background-color: $color-athens-gray;
    color: $color-fiord;

    &__cards {
      display: block;
      column-count: 1;
      column-gap: 20px;
      margin: 20px;
    }
  }
  // Medium screens breakpoint (1050px)
  @media only screen and (min-width: 65.625em) {
    .main {
      &__cards {
        column-count: 2;
      }
    }
  }
  </style>
  <div class="main__cards">
    <ng-content></ng-content>
  </div>
`
})
export class MainCardsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
