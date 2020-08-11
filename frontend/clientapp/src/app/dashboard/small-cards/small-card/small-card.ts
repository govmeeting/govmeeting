import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { DashCardsService } from '../../dash-cards.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-small-card',
  templateUrl: './small-card.html',
  styleUrls: ['./small-card.scss'],
})
export class SmallCardComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  @Input() icon: string;
  @Input() iconcolor: string;
  @Input() title: string;
  @Input() subtitle: string;
  @Input() tooltip: string;
  collapsed = true;
  currentStyles: any;
  subscription: Subscription;

  constructor(private dashCardsService: DashCardsService) {
    this.subscription = this.dashCardsService.getMessage().subscribe((message) => {
      NoLog || console.log(this.ClassName + 'receive settings=', message);
      // If another small card is opening, close if open
      if (message !== this.title && !this.collapsed) {
        this.toggleCollapsed2();
      }
    });
  }

  toggleCollapsed() {
    // If I am being opened, send message to other small card to close.
    if (this.collapsed) {
      // send my title so each card knows which is being opened.
      this.dashCardsService.sendMessage(this.title);
    }
    // Actually open of close
    this.toggleCollapsed2();
  }

  toggleCollapsed2() {
    this.collapsed = !this.collapsed;
    this.currentStyles = {
      height: this.collapsed ? '85px' : null,
      'z-index': this.collapsed ? '0' : '2',
    };
  }

  ngOnInit() {
    this.collapsed = true;
    this.currentStyles = {
      height: '85px',
    };
  }
}
