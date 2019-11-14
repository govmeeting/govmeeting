import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-large-card',
  templateUrl: './large-card.component.html',
  styleUrls: ['./large-card.component.scss']
})
export class LargeCardComponent implements OnInit {
  @Input() title: string;
  @Input() icon: string;
  @Input() iconcolor: string;
  @Input() tooltip: string;

  constructor() { }

  ngOnInit() {
  }

}
