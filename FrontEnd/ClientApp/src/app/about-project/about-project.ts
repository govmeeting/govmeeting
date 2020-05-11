import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetPageTitle } from './document-pages';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-auto-processing',
  templateUrl: './about-project.html',
  styleUrls: ['./about-project.scss']
})
export class AboutComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
  subscription: Subscription;
  // userSettingsService: UserSettingsService;
  title: string;
  document: string;
  pageid: string;
  language: string = "en";

  // constructor(private activeRoute: ActivatedRoute) { }
  constructor(
    private activeRoute: ActivatedRoute,
    private userSettingsService: UserSettingsService
  ) {
  }

  ngOnInit() {
    // We subscribe to changes in user settings language.
    this.userSettingsService.subscribeLanguage(language => {
      this.language = language;
      // this.title = GetPageTitle(this.pageid, this.language);
      this.setDocument(this.pageid, this.language);
      // if (this.language == "en") {
      //   this.document = "assets/docs/" + this.pageid  + ".md"
      // } else {
      //   this.document = "assets/docs/" + this.pageid + (this.language).toUpperCase() + "/" + this.pageid + ".md"
      // }
    })

    // We subscribe to changes in the about page displayed.
    // https://stackblitz.com/edit/angular-3fkg6e?file=src%2Fapp%2Fcomponent-a.component.ts
    this.activeRoute.queryParams.subscribe(params => {
        this.pageid = params.id;
        this.setDocument(this.pageid, this.language);
        // this.title = GetPageTitle(this.pageid, this.language);
        // this.document = "assets/docs/" + this.pageid + "." + this.language + ".md"
    })
  }

  setDocument(pageid, language) {
    this.title = GetPageTitle(pageid, language);
    if (language == "en") {
      this.document = "assets/docs/" + pageid  + ".md"
    } else {
      this.document = "assets/docs/TRANS/" + (language).toUpperCase() + "/" + this.pageid + ".md"
    }
}

  errorHandler(ev) {
    console.log("in errorHandler")
  }
  loadedHandler(ev) {
    console.log("in loadedHandler")
  }

}
