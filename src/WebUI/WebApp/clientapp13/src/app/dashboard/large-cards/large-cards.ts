import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-large-cards',
  template: `
    <div class="main__cards">
      <ng-content></ng-content>
    </div>
  `,
})
export class LargeCardsComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
