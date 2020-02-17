export enum LocationType{
  municipal,
  county,
  state,
  federal,
  nongovernment
}

export class UserSettings {
  language: string;
  location: string;
  locationType: LocationType;
  agency: string;

  constructor(_language?: string, _location?: string, _locationType?: LocationType, _agency?: string){
    this.language = _language;
    this.location = _location;
    this.locationType = _locationType;
    this.agency = _agency
  }
}
