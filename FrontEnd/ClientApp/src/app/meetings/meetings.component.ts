import { Component, OnInit, Input } from '@angular/core';

console.log = function() {}  // comment this out for console logging

@Component({
  selector: 'gm-meetings',
  templateUrl: './meetings.component.html',
  styleUrls: ['./meetings.component.scss']
})
export class MeetingsComponent implements OnInit {
  private ClassName: string = this.constructor.name;
  public _location = '';
  public _agency = '';

  @Input()
    set location(location: string) {
      this._location = location;
      console.log(this.ClassName +"bills set location=" + location)
    }
    get location(): string { return this._location; }

    @Input()
    set agency(agency: string) {
      this._agency = agency;
      console.log(this.ClassName +"bills set agency=" + agency)
    }
    get agency(): string { return this._agency; }
  constructor() { }

  ngOnInit() {
  }


}
