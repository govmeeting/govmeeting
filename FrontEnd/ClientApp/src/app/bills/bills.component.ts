import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-bills',
  templateUrl: './bills.component.html',
  styleUrls: ['./bills.component.scss']
})
export class BillsComponent implements OnInit {
  _location = '';
  _agency = '';

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
    console.log("bills ngOnInit location=" + this._location)
  }

}