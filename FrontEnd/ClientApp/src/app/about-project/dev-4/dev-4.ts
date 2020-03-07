import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-developer-notes',
  templateUrl: './dev-4.html',
  styleUrls: ['./dev-4.scss']
})
export class Dev4Component implements OnInit {
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
