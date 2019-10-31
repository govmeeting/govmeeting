import { Component, Input, OnInit } from '@angular/core';

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

   // Currently hard-coded in gmdashboard.component.html for each card.
   // It should be added in cards.component automatically.
  @Input() zIndex: number;

  sampleContent: string = 'A rather long string of English text, an error message ' +
  'actually that just keeps going and going -- an error ' +
  'message to make the Energizer bunny blush (right through ' +
  'those Schwarzenegger shades)! Where was I? Oh yes, ' +
  'you\'ve got an error and all the extraneous whitespace is ' +
  'just gravy.  Have a nice day.';

  height: number;
  overflow: string;

  collapsed: boolean = true;
  toggleCollapsed() {
    this.collapsed = !this.collapsed;
    this.height = (this.height == 45) ? 500 : 45;
    this.overflow = (this.overflow == 'hidden') ? 'visible' : 'hidden';
  }

  constructor() { }

  ngOnInit() {
    this.height = 20;
    this.overflow = 'hidden';
  }

}
