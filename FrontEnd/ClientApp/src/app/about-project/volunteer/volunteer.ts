import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-volunteer',
  templateUrl: './volunteer.html',
  styleUrls: ['./volunteer.scss']
})
export class VolunteerComponent implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
