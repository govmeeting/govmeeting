import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-large-cards',
  template:`
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
  </style>
  <div class="main__cards">
    <ng-content></ng-content>
  </div>
`
// styleUrls: ['./large-cards.scss']  // Why does it not work when the styles are in a file, instead of inline?
})
export class LargeCardsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
