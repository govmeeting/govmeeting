import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-purpose',
  templateUrl: './purpose.html',
  styleUrls: ['./purpose.scss']
})
export class PurposeComponent implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
