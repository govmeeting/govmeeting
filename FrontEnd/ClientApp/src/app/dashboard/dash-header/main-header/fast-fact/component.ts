import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-fast-fact',
  templateUrl: './component.html',
  styleUrls: ['./component.scss']
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
