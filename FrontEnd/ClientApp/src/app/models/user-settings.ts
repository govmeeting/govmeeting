export class UserSettings {
  language: string;
  location: string;
  agency: string;

  constructor(_language?: string, _location?: string, _agency?: string){
    this.language = _language;
    this.location = _location;
    this.agency = _agency
  }
}
