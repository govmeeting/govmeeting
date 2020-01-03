import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'gm-main-content',
  templateUrl: './dash-main.html',
  styleUrls: ['./dash-main.scss']
})
export class MainContentComponent implements OnInit {

  constructor(public router: Router) { }

  ngOnInit() {
  }

  CallBills(){
    console.log("CallBills");
    this.router.navigate([{outlets: {"bills": "bills"}}]);

  }
}
