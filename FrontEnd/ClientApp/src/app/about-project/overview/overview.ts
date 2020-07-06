import { Component, OnInit, Input } from '@angular/core';
import { UserSettingsService } from '../../COMMON/user-settings.service';
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
   }
  ngOnInit() {
    this.changeLanguage("en");   // TODO - remove


    this.userSettingsService.subscribeLanguage(language => {
      this.changeLanguage(language);
  })

  }

  changeLanguage(language: string) {
    this.language = language;
    this.title = GetPageTitle("overview", this.language, false);
    let folder = "TRANS/" + (this.language).toUpperCase() + "/";
    if (this.language == "en") folder = "";
    this.document1 = "assets/docs/" + folder + "overview1.md";
    this.document2 = "assets/docs/" + folder + "overview2.md";
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
