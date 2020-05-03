import { Component, OnInit, Input } from '@angular/core';
import { UserSettingsService } from '../../user-settings.service';
import { GetPageTitle } from '../document-pages';

@Component({
  selector: 'gm-overview',
  templateUrl: './overview.html',
  styleUrls: ['./overview.scss']
})
export class OverviewComponent implements OnInit {
  // @Input() showtitle: boolean = true;
  // userSettingsService: UserSettingsService;

  title: string = "Overview";
  document1: string;
  document2: string;
  language: string;;

  constructor(private userSettingsService: UserSettingsService) {
    // this.userSettingsService = _userSettingsService;
   }
  ngOnInit() {
    this.changeLanguage("en");

    // this.document1 = "assets/docs/overview1"+ "." + this.language + ".md";
    // this.document2 = "assets/docs/overview2"+ "." + this.language + ".md";
    // this.title = GetPageTitle("overview", this.language);

    // We subscribe to changes in user settings - for language change.
    // this.userSettingsService.SettingsChangeAsObservable().subscribe(message => {
    //   let newSettings = this.userSettingsService.settings;
    //   if (newSettings.language != undefined) {
    //     this.language = newSettings.language;
    //     this.title = GetPageTitle("overview", this.language);
    //     this.document1 = "assets/docs/overview1"+ "." + this.language + ".md";
    //     this.document2 = "assets/docs/overview2"+ "." + this.language + ".md";
    //     } else {
    //       console.error(" language not found");
    //     }
    // })

    this.userSettingsService.bLanguage.subscribe(language => {
      this.changeLanguage(language);
      // this.language = language;
      // this.title = GetPageTitle("overview", this.language);
      // this.document1 = "assets/docs/overview1"+ "." + this.language + ".md";
      // this.document2 = "assets/docs/overview2"+ "." + this.language + ".md";
  })

  }

  changeLanguage(language: string) {
    this.language = language;
    this.title = GetPageTitle("overview", this.language);
    this.document1 = "assets/docs/overview1"+ "." + this.language + ".md";
    this.document2 = "assets/docs/overview2"+ "." + this.language + ".md";
  }

  showtranscript: boolean = false;
  showhidetranscript: string = "Show";

  showindex: boolean = false;
  showhideindex: string = "Show";

  CheckShowTranscript(): boolean {
      return this.showtranscript;
  }
  ToggleTranscript() {
      this.showhidetranscript = this.showtranscript ? "Show" : "Hide";
      this.showtranscript = !this.showtranscript;
  }

  CheckShowIndex(): boolean {
      return this.showindex;
  }
  ToggleIndex() {
      this.showhideindex = this.showindex ? "Show" : "Hide";
      this.showindex = !this.showindex;
  }

  errorHandler(ev) {
    console.log("in errorHandler")
  }
  loadedHandler(ev) {
    console.log("in loadedHandler")
  }
}
