import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-manual-processing',
  templateUrl: './dev-2.html',
  styleUrls: ['./dev-2.scss']
})
export class Dev2Component implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }
}
