import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-small-cards',
  template:  `
    <div class="smallCards">
      <ng-content></ng-content>
    </div>
`,
  // templateUrl: './small-cards/small-cards.component.html',
  styleUrls: ['./small-cards.scss']
})
export class SmallCardsComponent implements OnInit {

  constructor(
  ) {

   }

  ngOnInit() {
  }

}
