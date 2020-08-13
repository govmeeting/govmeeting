import { Component, OnInit, Input } from '@angular/core';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss'],
})
export class NewsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  public datetime;

  constructor() {}

  ngOnInit() {
    this.datetime = new Date();
  }
}
