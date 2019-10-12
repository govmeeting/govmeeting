import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-overview-card',
  templateUrl: './overview-card.component.html',
  styleUrls: ['./overview-card.component.scss']
})
export class OverviewCardComponent implements OnInit {
  @Input() icon: string;
  @Input() title: string;
  @Input() subtitle: string;

  constructor() { }

  ngOnInit() {
  }

}
