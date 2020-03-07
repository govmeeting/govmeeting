import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'gm-auto-processing',
  templateUrl: './about-project.html',
  styleUrls: ['./about-project.scss']
})
export class AboutComponent implements OnInit {
  title = "Developer Setup";
  document: string = "assets/docs/setup.md";

  constructor(private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    // https://stackblitz.com/edit/angular-3fkg6e?file=src%2Fapp%2Fcomponent-a.component.ts
    this.activeRoute.queryParams.subscribe(params => {
      console.log(params.id);
    })
  }
  errorHandler(ev) {
    console.log("in errorHandler")
  }
  loadedHandler(ev) {
    console.log("in loadedHandler")
  }

}
