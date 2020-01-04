import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-bills',
  templateUrl: './bills.component.html',
  styleUrls: ['./bills.component.scss']
})
export class BillsComponent implements OnInit {
  private _location = '';
  private _agency = '';

  @Input()
    set location(location: string) {
      this._location = location;
      console.log("bills set location=" + location)
    }
    get location(): string { return this._location; }


  @Input() agency: string;

  constructor() { }

  ngOnInit() {
    console.log("bills ngOnInit location=" + this._location)
  }

}
