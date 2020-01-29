import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-register-organization',
  templateUrl: './register-organization.html',
  styleUrls: ['./register-organization.scss']
})
export class RegisterOrganizationComponent implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
