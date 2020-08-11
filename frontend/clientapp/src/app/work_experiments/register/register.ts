import { Component, OnInit } from '@angular/core';

// This is for experimenting with elements for writing a "Register" component
//  -- register a user, register a government entity

export interface Food {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'gm-register',
  templateUrl: './register.html',
  styleUrls: ['./register.scss'],
})
export class RegisterComponent implements OnInit {
  constructor() {}

  // https://stackblitz.com/angular/rdlobdgvqok?file=src%2Fapp%2Fselect-overview-example.html

  foods: Food[] = [
    { value: 'steak-0', viewValue: 'Steak' },
    { value: 'pizza-1', viewValue: 'Pizza' },
    { value: 'tacos-2', viewValue: 'Tacos' },
  ];

  ngOnInit() {}
}
