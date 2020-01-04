import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  private _location = '';
  private _agency = '';
  private datetime;

  @Input()
    set location(location: string) {
      this._location = location;
      console.log("bills set location=" + location)}
    get location(): string { return this._location; }

    @Input()
    set agency(agency: string) {
      this._agency = agency;
      console.log("bills set agency=" + agency)}
    get agency(): string { return this._agency; }

  constructor() { }

  ngOnInit() {
    this.datetime = new Date()
  }

}
