import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-auto-processing',
  templateUrl: './dev-1.html',
  styleUrls: ['./dev-1.scss']
})
export class Dev1Component implements OnInit {
  title = "Developer Setup";
  document: string = "assets/docs/setup.md";
  constructor() { }

  ngOnInit() {
  }
  errorHandler(ev) {
    console.log("in errorHandler")
  }
  loadedHandler(ev) {
    console.log("in loadedHandler")
  }

}
