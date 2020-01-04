import { Component, OnInit, OnDestroy } from '@angular/core';
import {Router} from '@angular/router';
import { Subscription } from 'rxjs';

import { MessageService } from '../message.service';

@Component({
  selector: 'gm-main-content',
  templateUrl: './dash-main.html',
  styleUrls: ['./dash-main.scss']
})
export class MainContentComponent implements OnInit, OnDestroy {
  messages: any[] = [];
  subscription: Subscription;

  location: string;
  agency: string;

  constructor(public router: Router, private messageService: MessageService) {
    this.subscription = this.messageService.getMessage().subscribe(message => {
      if (message) {
        this.messages.push(message);
        console.log("dash-main: message=")
        console.log(message.text);
        this.parseMessage(message.text);
      } else {
        // clear messages when empty message received
        this.messages = [];
      }
    });
   }

  ngOnInit() {
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
}

  parseMessage(message: string) {
    let mes = message.split(':');
    if (mes[0] == 'AgencySelected') {
      this.location = mes[1];
      this.agency = mes[2];
      console.log("location:" + this.location);
    }
  }

  // CallBills(){
  //   console.log("CallBills");

  //   // this.router.navigate([{outlets: {"bills": ['dashboard/bills']}}]);
  //      // this.router.navigate(['dashboard/govinfo', location, agency]);

  //      this.router.navigateByUrl('dashboard/(bills:bills)');

  //   // this.router.navigate([{outlets: {"bills": ['dashboard/bills']}}]);
  //   // <a [routerLink]="[{ outlets: { 'bills': ['bills'] } }]">Link Bills</a><br/>
  //   // this.router.navigate([{ outlets: {'playListOutletName': ['playlist-path']}]);
  //   //     <a [routerLink]="[{ outlets: {"playListOutletName": ["playlist-path"]}}]">Link text</a>
  // }

}
