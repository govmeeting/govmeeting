import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetPageTitle } from './document-pages';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../common/user-settings.service';
import { AppData } from '../appdata';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-auto-processing',
  templateUrl: './about-project.html',
  styleUrls: ['./about-project.scss'],
})
export class AboutComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  isBeta: boolean;
  subscription: Subscription;
  // userSettingsService: UserSettingsService;
  title: string; // page title obtained from GetPageTitle(...)
  document: string; // The path of the document. EG: "assets/docs/TRANS/overview.md"
  pageid = 'overview'; // the filename of the document minus ".md". EG: "overview"
  language = 'en';

  // constructor(private activeRoute: ActivatedRoute) { }
  constructor(
    private activeRoute: ActivatedRoute,
    private userSettingsService: UserSettingsService,
    private appData: AppData
  ) {
    this.isBeta = appData.isBeta;
  }

  ngOnInit() {
    // We subscribe to changes in user settings language.
    this.userSettingsService.subscribeLanguage((language) => {
      this.language = language;
      this.setDocument(this.pageid, this.language);
    });

    // We subscribe to changes in the about page displayed.
    // https://stackblitz.com/edit/angular-3fkg6e?file=src%2Fapp%2Fcomponent-a.component.ts
    this.activeRoute.queryParams.subscribe((params) => {
      this.pageid = params.id;
      this.setDocument(this.pageid, this.language);
    });
  }

  setDocument(pageid, language) {
    this.title = GetPageTitle(pageid, language, this.isBeta);
    if (language === 'en') {
      this.document = 'assets/docs/' + pageid + '.md';
    } else {
      this.document = 'assets/docs/TRANS/' + language.toUpperCase() + '/' + this.pageid + '.md';
    }
  }

  errorHandler(ev) {
    console.log('in errorHandler');
  }
  loadedHandler(ev) {
    console.log('in loadedHandler');
  }
}
