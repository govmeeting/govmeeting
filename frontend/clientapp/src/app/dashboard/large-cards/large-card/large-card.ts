import { Component, Input, OnInit } from '@angular/core';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-large-card',
  templateUrl: './large-card.html',
  styleUrls: ['./large-card.scss'],
})
export class LargeCardComponent {
  private ClassName: string = this.constructor.name + ': ';

  @Input() title: string;
  @Input() icon: string;
  @Input() iconcolor: string;
  @Input() tooltip: string;
  panelOpenState = false;

  togglePanel() {
    this.panelOpenState = !this.panelOpenState;
  }
}
