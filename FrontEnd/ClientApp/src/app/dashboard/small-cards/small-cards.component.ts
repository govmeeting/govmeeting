import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-small-cards',
  template:  `
  // <style>
  // .smallCards {
  //   display: grid;
  //   // All items will have a minimum width of 265 px and a maximum of 1 fr unit.
  //   grid-template-columns: repeat(auto-fit, minmax(265px, 1fr));
  //   grid-auto-rows: 94px;
  //   grid-gap: 10px;
  //   margin: 10px;
  // }
  //   </style>
      <div class="smallCards">
      <ng-content></ng-content>
    </div>
`,
  // templateUrl: './small-cards/small-cards.component.html',
  styleUrls: ['./small-cards/small-cards.component.scss']
})
export class SmallCardsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
