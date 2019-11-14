import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-small',
  templateUrl: './small.component.html',
  styleUrls: ['./small.component.scss']
})
export class SmallComponent implements OnInit {
  @Input() icon: string;
  @Input() iconcolor: string;
  @Input() title: string;
  @Input() subtitle: string;

   // Currently hard-coded in dashboard.component.html for each card.
   // It should be added in cards.component automatically.
//  @Input() zIndex: number;

  sampleContent: string = 'A rather long string of English text, an error message ' +
  'actually that just keeps going and going -- an error ' +
  'message to make the Energizer bunny blush (right through ' +
  'those Schwarzenegger shades)! Where was I? Oh yes, ' +
  'you\'ve got an error and all the extraneous whitespace is ' +
  'just gravy.  Have a nice day.';

  // height: string;
  // overflow: string;
  collapsed: boolean = true;
  // bcolor: string = "lightgreen";
  // zIndex: number = 0;

  currentStyles: any;

  toggleCollapsed() {
    this.collapsed = !this.collapsed;
    this.currentStyles = {
      // 'height': this.collapsed  ? '85px' : '400px',
      // 'z-index': this.collapsed ? '0'   : '8'
      'height': this.collapsed  ? '85px' : null,
      'z-index': this.collapsed ? '0'   : '2'
   };
    //this.overflow = (this.overflow == 'hidden') ? 'visible' : 'hidden';
  }

  constructor() { }

  ngOnInit() {
    this.collapsed = true;
    this.currentStyles = {
      'height': '85px',
      'z-index':  '2'
    };
    //this.overflow = 'hidden';
  }

}
