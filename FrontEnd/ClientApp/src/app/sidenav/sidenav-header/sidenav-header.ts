import { Component, OnInit } from '@angular/core';
import {NavService} from '../nav.service';
import { UserSettingsService, UserSettings, LocationType } from '../../user-settings.service';

interface Language {
  enname: string;
  value: string;
  viewValue: string;
}
@Component({
  selector: 'gm-sidenav-header',
  templateUrl: './sidenav-header.html',
  styleUrls: ['./sidenav-header.scss']
})
export class TopNavComponent implements OnInit {
  userSettingsService: UserSettingsService;
  language: string;

  languages: Language[] = [
     {enname: 'English', value: 'en', viewValue: 'English'},
     {enname: 'French', value: 'fr', viewValue: 'Français'},
     {enname: 'German', value: 'de', viewValue: 'Deutsch'},
    // {enname: 'Indonesian', value: 'id', viewValue: 'Indonesia'},
    // {enname: 'Icelandic', value: 'ic', viewValue: 'Íslensku'},
     {enname: 'Portuguese', value: 'pt', viewValue: 'Português'},
     {enname: 'Spanish', value: 'es', viewValue: 'Español'},
     {enname: 'Swahili', value: 'sw', viewValue: 'Kiswahili'},
    // {enname: 'Russian', value: 'ru', viewValue: 'русский'},
    // {enname: 'Turkish', value: 'tr', viewValue: 'Türk'},
     {enname: 'Hindi', value: 'hi', viewValue: 'हिन्दी'},
     {enname: 'Arabic', value: 'ar', viewValue: 'عربى'},
     {enname: 'Mandarin', value: 'zh', viewValue: '普通话'},
     {enname: 'Bengali', value: 'bn', viewValue: 'বাংলা'}
    // {enname: 'Urdu', value: 'ur', viewValue: 'اردو'},
    // {enname: 'Japanese', value: 'ja', viewValue: '日本語'},
    // {enname: 'Marathi', value: 'mr', viewValue: 'मराठी'},
  ];


  // NavService is used in the template for the button to close the menu.
  // UserSettingsService is for changing the language
  constructor(
    public navService: NavService,
    private _userSettingsService: UserSettingsService,
    ) {
      this.userSettingsService = _userSettingsService;     }

  ngOnInit() {
  }

  setLanguage(language: string){
    this.userSettingsService.setLanguage(language);
  }
}
