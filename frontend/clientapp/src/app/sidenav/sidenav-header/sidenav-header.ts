import { Component, OnInit } from '@angular/core';
import { NavService } from '../nav.service';
import { UserSettingsService, UserSettings, LocationType } from '../../common/user-settings.service';
import { AppData } from '../../appdata';

interface Language {
  enname: string;
  value: string;
  viewValue: string;
}
@Component({
  selector: 'gm-sidenav-header',
  templateUrl: './sidenav-header.html',
  styleUrls: ['./sidenav-header.scss'],
})
export class TopNavComponent implements OnInit {
  // userSettingsService: UserSettingsService;
  language: string;
  isBeta: boolean;

  languages: Language[] = [
    { enname: 'English', value: 'en', viewValue: 'English' },
    { enname: 'French', value: 'fr', viewValue: 'Français' },
    { enname: 'German', value: 'de', viewValue: 'Deutsch' },
    { enname: 'Portuguese', value: 'pt', viewValue: 'Português' },
    { enname: 'Spanish', value: 'es', viewValue: 'Español' },
    { enname: 'Italian', value: 'it', viewValue: 'Italiano' },
    { enname: 'Finish', value: 'fi', viewValue: 'Suomalainen' },
    { enname: 'Polish', value: 'pl', viewValue: 'Polskie' },
    { enname: 'Icelandic', value: 'is', viewValue: 'Íslensku' },
    { enname: 'Greek', value: 'el', viewValue: 'Ελληνικά' },
    { enname: 'Swahili', value: 'sw', viewValue: 'Kiswahili' },
    { enname: 'Vietnamese', value: 'vi', viewValue: 'Tiếng Việt' },
    { enname: 'Hungarian', value: 'hu', viewValue: 'Magyar' },
    { enname: 'Serbian', value: 'sr', viewValue: 'Српски' },
    { enname: 'Hebrew', value: 'iw', viewValue: 'עִברִית' },
    { enname: 'Mandarin', value: 'zh', viewValue: '普通话' },
    { enname: 'Japanese', value: 'ja', viewValue: '日本語' },
    { enname: 'Hindi', value: 'hi', viewValue: 'हिन्दी' },
    { enname: 'Bengali', value: 'bn', viewValue: 'বাংলা' },
    { enname: 'Arabic', value: 'ar', viewValue: 'عربى' },
    { enname: 'Korean', value: 'ko', viewValue: '한국어' }, // ADD_HERE - do not remove this comment

    // {enname: 'Norwegian', value: 'no', viewValue: ''},
    // {enname: 'Swedish', value: 'sv', viewValue: ''},
    // {enname: 'Danish', value: 'da', viewValue: ''},
    // {enname: 'Croatian', value: 'hr', viewValue: ''},
    // {enname: 'Albanian', value: 'sq', viewValue: ''},
    // {enname: 'Armenian', value: 'hy', viewValue: ''},
    // {enname: 'Bosnian', value: 'bs', viewValue: ''},
    // {enname: 'Bulgarian', value: 'bg', viewValue: ''},
    // {enname: 'Czech', value: 'cs', viewValue: ''},
    // {enname: 'Dutch', value: 'nl', viewValue: ''},
    // {enname: 'Estonian', value: 'rt', viewValue: ''},
    // {enname: 'Filipino', value: 'tl', viewValue: ''},
    // {enname: 'Hebrew', value: 'iw', viewValue: ''},
    // {enname: 'Hungarian', value: 'hu', viewValue: ''},
    // {enname: 'Italian', value: 'it', viewValue: ''},
    // {enname: 'Lao', value: 'lo', viewValue: ''},
    // {enname: 'Latvian', value: 'lv', viewValue: ''},
    // {enname: 'Lithuanian', value: 'lt', viewValue: ''},
    // {enname: 'Macedonian', value: 'mk', viewValue: ''},
    // {enname: 'Romanian', value: 'ro', viewValue: ''},
    // {enname: 'Slovenian', value: 'sl', viewValue: ''},
    // {enname: 'Ukrainian', value: 'uk', viewValue: ''},
    // {enname: 'Javanese', value: 'jw', viewValue: ''},
    // {enname: 'Telugu', value: 'te', viewValue: ''},
    // {enname: 'Tamil', value: 'ta', viewValue: ''},
    // {enname: 'Marathi', value: 'mr', viewValue: ''},
    // {enname: 'Gujarati', value: 'gu', viewValue: ''},
    // {enname: 'Telugu', value: 'te', viewValue: ''},
    // {enname: 'Russian', value: 'ru', viewValue: 'русский'},
    // {enname: 'Turkish', value: 'tr', viewValue: 'Türk'},
    // {enname: 'Indonesian', value: 'id', viewValue: 'Indonesia'},
    // {enname: 'Urdu', value: 'ur', viewValue: 'اردو'},
    // {enname: 'Marathi', value: 'mr', viewValue: 'मराठी'},
  ];

  // NavService is used in the template for the button to close the menu.
  // UserSettingsService is for changing the language
  constructor(public navService: NavService, private userSettings: UserSettingsService, private appData: AppData) {
    this.isBeta = appData.isBeta;
  }

  ngOnInit() {
    this.language = 'en';
  }

  setLanguage(language: string) {
    this.userSettings.language = language;
  }
}
