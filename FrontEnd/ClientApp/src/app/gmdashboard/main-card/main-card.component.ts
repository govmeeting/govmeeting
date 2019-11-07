import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-main-card',
  templateUrl: './main-card.component.html',
  styleUrls: ['./main-card.component.scss']
})
export class MainCardComponent implements OnInit {
  @Input() title: string;
  @Input() icon: string;
  @Input() iconcolor: string;

  constructor() { }

  ngOnInit() {
  }

}
