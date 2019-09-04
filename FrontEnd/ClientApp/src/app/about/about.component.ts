import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  title: string = 'Purpose of the project';

  constructor() { }

  ngOnInit() {
  }

  public changeTitle(): void {
    if (this.title == 'Purpose of the project') {
      this.title = 'About the project'
    } else {
      this.title = 'Purpose of the project'
    }
  }
}
