import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-quick-item',
  templateUrl: './quick-item.component.html',
  styleUrls: ['./quick-item.component.scss', '../quickview/quickview.component.scss']
})
export class QuickItemComponent implements OnInit {
  @Input() total: string;
  @Input() icon: string;
  @Input() desc: string;

  constructor() { }

  ngOnInit() {
  }

}
