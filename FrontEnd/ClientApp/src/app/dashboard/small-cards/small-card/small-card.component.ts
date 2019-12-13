import { Component, Input, OnInit } from '@angular/core';
import { number } from '@amcharts/amcharts4/core';

// interface IStyles {
//   height: string;
//   zindex: number;
// }

@Component({
  selector: 'gm-small-card',
  templateUrl: './small-card.component.html',
  styleUrls: ['./small-card.component.scss']
})
export class SmallCardComponent implements OnInit {
  @Input() icon: string;
  @Input() iconcolor: string;
  @Input() title: string;
  @Input() subtitle: string;
  @Input() tooltip: string;


  // height: string;
  // overflow: string;
  collapsed: boolean = true;
  // bcolor: string = "lightgreen";
  // zIndex: number = 0;
  x: number;

  currentStyles: any;
  // currentStyles = {'height': null, 'z-index': 2};

  toggleCollapsed() {
    this.collapsed = !this.collapsed;
    this.currentStyles = {
      // 'height': this.collapsed  ? '85px' : '400px',
      // 'z-index': this.collapsed ? '0'   : '8'
      'height': this.collapsed  ? '85px' : null,
      'z-index': this.collapsed ? '0'   : '2'
   };
   this.x = 4/2; // for setting breakpoint
    //this.overflow = (this.overflow == 'hidden') ? 'visible' : 'hidden';
  }

  constructor() { }

  ngOnInit() {
    this.collapsed = true;
    this.currentStyles = {
      'height': '85px',
    };
    //this.overflow = 'hidden';
  }

}
