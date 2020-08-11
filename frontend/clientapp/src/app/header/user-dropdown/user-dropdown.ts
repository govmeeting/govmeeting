import { Component, OnInit, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'gm-user-dropdown',
  templateUrl: './user-dropdown.html',
  styleUrls: ['./user-dropdown.scss'],
})
export class UserDropdownComponent implements OnInit {
  dropdownActive = '';
  isLoggedIn = false;
  isAdmin = false;

  constructor(@Inject(DOCUMENT) private document: Document, private router: Router) {}

  ngOnInit() {}

  setDropdownActive() {
    this.dropdownActive = this.toggle(this.dropdownActive, 'dropdown--active', '');
  }

  toggle(value: string, value1: string, value2: string) {
    return (value = value1 ? value2 : value1);
  }

  signin() {
    window.location.href = 'account/login';
    // window.open('account/login');    // opens in new tab
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
}
