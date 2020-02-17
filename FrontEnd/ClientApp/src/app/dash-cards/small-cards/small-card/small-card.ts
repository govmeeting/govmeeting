import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { DashCardsService } from '../../dash-cards.service';

const NoLog = false;  // set to false for console logging

@Component({
  selector: 'gm-small-card',
  templateUrl: './small-card.html',
  styleUrls: ['./small-card.scss']
})
export class SmallCardComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
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

  currentStyles: any;
  // currentStyles = {'height': null, 'z-index': 2};

  subscription: Subscription;

  constructor(
    private dashCardsService: DashCardsService
  ) {
    this.subscription = this.dashCardsService.getMessage().subscribe(message => {
      NoLog || console.log(this.ClassName + "receive settings=", message);
      // If another small card is opening, close if open
      if ((message != this.title) && !this.collapsed) {
        this.toggleCollapsed2()
      }
  })
  }

  toggleCollapsed() {
    // If I am being opened, send message to other small card to close.
    if (this.collapsed) {
       // send my title so each card knows which is being opened.
      this.dashCardsService.sendMessage(this.title)
    }
    // Actually open of close
    this.toggleCollapsed2();
  }

  toggleCollapsed2() {
    this.collapsed = !this.collapsed;
    this.currentStyles = {
      // 'height': this.collapsed  ? '85px' : '400px',
      // 'z-index': this.collapsed ? '0'   : '8'
      'height': this.collapsed  ? '85px' : null,
      'z-index': this.collapsed ? '0'   : '2'
   };
   let x = 1; // for setting breakpoint
    //this.overflow = (this.overflow == 'hidden') ? 'visible' : 'hidden';
  }


  ngOnInit() {
    this.collapsed = true;
    this.currentStyles = {
      'height': '85px',
    };
    //this.overflow = 'hidden';
  }

}
