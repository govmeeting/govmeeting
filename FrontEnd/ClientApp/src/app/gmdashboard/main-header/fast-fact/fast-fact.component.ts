import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-fast-fact',
  templateUrl: './fast-fact.component.html',
  styleUrls: ['./fast-fact.component.scss']
  //styleUrls: ['./fast-fact.component.scss', '../fast-fact/fast-fact.component.scss']
})
export class FastFactComponent implements OnInit {
  @Input() total: string;
  @Input() icon: string;
  @Input() desc: string;

  constructor() { }

  ngOnInit() {
  }

}
