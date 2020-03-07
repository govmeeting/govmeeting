import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-developer-notes',
  templateUrl: './dev-5.html',
  styleUrls: ['./dev-5.scss']
})
export class Dev5Component implements OnInit {
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
