import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

const defaultDocument = "assets/docs/purpose.md"
const defaultTitle = "Purpose";
@Component({
  selector: 'gm-auto-processing',
  templateUrl: './about-project.html',
  styleUrls: ['./about-project.scss']
})
export class AboutComponent implements OnInit {
  title: string;
  document: string;

  constructor(private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    // https://stackblitz.com/edit/angular-3fkg6e?file=src%2Fapp%2Fcomponent-a.component.ts
    this.activeRoute.queryParams.subscribe(params => {
      if (params.id == undefined) {
        this.title = defaultTitle;
        this.document = defaultDocument;
      } else {
        let pageid = params.id;
        this.title = this.docPages[pageid];
        this.document = "assets/docs/" + pageid + ".md"
      }
      //console.log(params.id);
    })
  }
  errorHandler(ev) {
    console.log("in errorHandler")
  }
  loadedHandler(ev) {
    console.log("in loadedHandler")
  }

  // doc filenames (less .md") and titles
  docPages = {
    "purpose": "Purpose",
    "overview": "Overview",
    "workflow": "Workflow",
    "dev-setup": "Setup & General Info",
    "dev-client-app": "Client App",
    "dev-webapi": "WebApi",
    "dev-workflow-app": "Workflow App",
    "dev-other-apps": "Other Apps",
    "database-design": "Database",
    "functional-design": "Functional Design",
    "system-design": "System Design",
    "home": "Home"
  }

}
