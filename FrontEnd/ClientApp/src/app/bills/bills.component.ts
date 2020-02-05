import { Component, OnInit, Input } from '@angular/core';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-bills',
  templateUrl: './bills.component.html',
  styleUrls: ['./bills.component.scss']
})
export class BillsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
  _location = '';
  _agency = '';

  @Input()
    set location(location: string) {
      this._location = location;
      NoLog || console.log(this.ClassName + "set location=" + location)
    }
    get location(): string { return this._location; }

    @Input()
    set agency(agency: string) {
      this._agency = agency;
      NoLog || console.log(this.ClassName + "set agency=" + agency)
    }
    get agency(): string { return this._agency; }

  constructor() { }

  ngOnInit() {
    NoLog || console.log(this.ClassName + "ngOnInit location=" + this._location)
  }


}
