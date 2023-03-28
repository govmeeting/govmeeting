import { Component, OnInit, Input } from '@angular/core';
import { UserSettingsService } from '../../common/user-settings.service';
import { GetPageTitle } from '../document-pages';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-overview',
  templateUrl: './overview.html',
  styleUrls: ['./overview.scss'],
})
export class OverviewComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  constructor(private userSettingsService: UserSettingsService) {}
  // @Input() showtitle: boolean = true;
  // userSettingsService: UserSettingsService;
  title = 'Overview';
  document1: string = '';
  document2: string = '';
  language: string = '';

  showtranscript = false;
  showhidetranscript = 'Show';

  showindex = false;
  showhideindex = 'Show';
  ngOnInit() {
    this.changeLanguage('en'); // TODO - remove

    this.userSettingsService.subscribeLanguage((language: string) => {
      this.changeLanguage(language);
    });
  }

  changeLanguage(language: string) {
    this.language = language;
    this.title = GetPageTitle('overview', this.language, false);
    let folder = 'TRANS/' + this.language.toUpperCase() + '/';
    if (this.language === 'en') {
      folder = '';
    }
    this.document1 = 'assets/docs/' + folder + 'overview1.md';
    this.document2 = 'assets/docs/' + folder + 'overview2.md';
  }

  CheckShowTranscript(): boolean {
    return this.showtranscript;
  }
  ToggleTranscript() {
    this.showhidetranscript = this.showtranscript ? 'Show' : 'Hide';
    this.showtranscript = !this.showtranscript;
  }

  CheckShowIndex(): boolean {
    return this.showindex;
  }
  ToggleIndex() {
    this.showhideindex = this.showindex ? 'Show' : 'Hide';
    this.showindex = !this.showindex;
  }

  errorHandler(ev: any) {
    NoLog || console.log(this.ClassName + ' in errorHandler');
  }
  loadedHandler(ev: any) {
    NoLog || console.log(this.ClassName + ' in loadedHandler');
  }
}
