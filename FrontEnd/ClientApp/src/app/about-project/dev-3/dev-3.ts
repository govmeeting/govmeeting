import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-developer-notes',
  templateUrl: './dev-3.html',
  styleUrls: ['./dev-3.scss']
})
export class Dev3Component implements OnInit {
  @Input() showtitle: boolean = true;

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
