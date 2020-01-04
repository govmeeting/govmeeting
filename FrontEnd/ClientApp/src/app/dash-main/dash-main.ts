import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'gm-main-content',
  templateUrl: './dash-main.html',
  styleUrls: ['./dash-main.scss']
})
export class MainContentComponent implements OnInit {
  location: string = "Newark"
  agency: string = "Council";

  constructor(public router: Router) { }

  ngOnInit() {
  }

  CallBills(){
    console.log("CallBills");

    // this.router.navigate([{outlets: {"bills": ['dashboard/bills']}}]);
       // this.router.navigate(['dashboard/govinfo', location, agency]);

       this.router.navigateByUrl('dashboard/(bills:bills)');

    // this.router.navigate([{outlets: {"bills": ['dashboard/bills']}}]);
    // <a [routerLink]="[{ outlets: { 'bills': ['bills'] } }]">Link Bills</a><br/>
    // this.router.navigate([{ outlets: {'playListOutletName': ['playlist-path']}]);
    //     <a [routerLink]="[{ outlets: {"playListOutletName": ["playlist-path"]}}]">Link text</a>
  }
}
