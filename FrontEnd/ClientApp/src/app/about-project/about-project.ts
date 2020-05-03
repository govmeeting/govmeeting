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
    // We subscribe to changes in user settings - for language change.
    // this.userSettingsService.SubscribeSettings(message => {
    //   let newSettings = this.userSettingsService.settings;
    //   if (newSettings.language != undefined) {
    //     NoLog || console.log(this.ClassName + "message=" + message);
    //     this.language = newSettings.language;
    //     this.title = GetPageTitle(this.pageid, this.language);
    //     this.document = "assets/docs/" + this.pageid + "." + this.language + ".md"
    //   }
    // })

      this.userSettingsService.subscribeLanguage(language => {
        this.language = language;
        this.title = GetPageTitle(this.pageid, this.language);
        this.document = "assets/docs/" + this.pageid + "." + this.language + ".md"
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

}
