export enum LocationType {
  municipal,
  county,
  state,
  federal,
  nongovernment,
}

export class UserSettings {
  language: string;
  location: string;
  locationType: LocationType;
  agency: string;

  constructor(_language?: string, _location?: string, _agency?: string) {
    this.language = _language;
    this.location = _location;
    this.locationType = this.getLocationType(_location);
    this.agency = _agency;
  }

  // This routine is a kludge. We need to have a location type that includes the
  // displayName, locationType, etc. This should be used in the menu items
  // and user settings.
  private getLocationType(location: string): LocationType {
    switch (location) {
      case 'Boothbay Harbor': {
        return LocationType.municipal;
      }
      case 'Lincoln County': {
        return LocationType.county;
      }
      case 'State of Maine': {
        return LocationType.state;
      }
      case 'United States': {
        return LocationType.federal;
      }
      case 'Glendale HOA': {
        return LocationType.nongovernment;
      }
    }
    return null;
  }
}
