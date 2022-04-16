import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-user-dropdown',
  templateUrl: './user-dropdown.html',
  styleUrls: ['./user-dropdown.scss'],
})
export class UserDropdownComponent implements OnInit {
  dropdownActive = '';
  isLoggedIn = false;
  isAdmin = false;
  backgroundStyle: any;

  ngOnInit() {
    this.setBackground("url('assets/images/female-no-facial-features.png')");
  }

  setDropdownActive() {
    this.dropdownActive = this.toggle(this.dropdownActive, 'dropdown--active', '');
  }

  toggle(value: string, value1: string, value2: string) {
    // return (value = value1 ? value2 : value1);
    value = value === value1 ? value2 : value1;
    return value;
  }

  signin() {
    window.location.href = 'account/login';
  }

  register() {
    window.location.href = 'account/register';
  }

  admin() {
    window.location.href = 'admin';
  }

  myprofile() {}

  myaccount() {}

  signout() {}

  private setBackground(background: string) {
    this.backgroundStyle = { 'background-image': background };
  }
}
