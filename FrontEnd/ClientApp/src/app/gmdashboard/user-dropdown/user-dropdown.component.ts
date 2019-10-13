import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-user-dropdown',
  templateUrl: './user-dropdown.component.html',
  styleUrls: ['./user-dropdown.component.scss']
})
export class UserDropdownComponent implements OnInit {

  dropdownActive = ""

  constructor() { }

  ngOnInit() {
  }

  setDropdownActive() {
    this.dropdownActive = this.toggle(this.dropdownActive, "dropdown--active", "");
  }

  toggle(value: string, value1: string, value2: string){
    return (value == value1) ? value2 : value1;
  }
}
