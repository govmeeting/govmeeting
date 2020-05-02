import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetPageTitle } from './document-pages';
import { Subscription } from 'rxjs';
import { UserSettingsService, UserSettings, LocationType } from '../user-settings.service';

const NoLog = true;  // set to false for console logging

// const defaultDocument = "assets/docs/purpose.md"
// const defaultTitle = "Purpose";
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
    // this.userSettingsService = _userSettingsService;
  }
  // constructor(private _userSettingsService: UserSettingsService) {
  //   this.userSettingsService = _userSettingsService;
  //  }

  ngOnInit() {
    // We subscribe to changes in user settings - for language change.
    this.userSettingsService.SettingsChangeAsObservable().subscribe(message => {
      let newSettings = this.userSettingsService.settings;
      if (newSettings.language != undefined) {
        NoLog || console.log(this.ClassName + "message=" + message);
        this.language = newSettings.language;
        this.title = GetPageTitle(this.pageid, this.language)
      }
    })

    // We subscribe to changes in the about page displayed.
    // https://stackblitz.com/edit/angular-3fkg6e?file=src%2Fapp%2Fcomponent-a.component.ts
    this.activeRoute.queryParams.subscribe(params => {
        this.pageid = params.id;
        this.title = GetPageTitle(this.pageid, this.language);
        this.document = "assets/docs/" + this.pageid + "." + this.language + ".md"
    })
  }
  errorHandler(ev) {
    console.log("in errorHandler")
  }
  loadedHandler(ev) {
    console.log("in loadedHandler")
  }

    // xtranslateTitle(pageid: string, language: string) : string {
    //   let i = PageIds.findIndex(x => x == pageid);
    //   let j = PageTitles.findIndex(y => y[0] == language);
    //   return PageTitles[j][i+1];
    // }

}
