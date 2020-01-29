import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-extend-govmeeting',
  templateUrl: './extend-govmeeting.html',
  styleUrls: ['./extend-govmeeting.scss']
})
export class ExtendGovmeetingComponent implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
