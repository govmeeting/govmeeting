import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-quickview-item',
  templateUrl: './quickview-item.component.html',
  styleUrls: ['./quickview-item.component.scss']
  //styleUrls: ['./quickview-item.component.scss', '../quickview/quickview.component.scss']
})
export class QuickviewItemComponent implements OnInit {
  @Input() total: string;
  @Input() icon: string;
  @Input() desc: string;

  constructor() { }

  ngOnInit() {
  }

}
