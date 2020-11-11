import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-small-cards',
  template: `
    <div class="smallCards">
      <ng-content></ng-content>
    </div>
  `,
  styleUrls: ['./small-cards.scss'],
})
export class SmallCardsComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
