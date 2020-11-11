import { DropdownValue } from '../../common/dropdown/value';

// This is the dropdown box used for selecting a speaker.

export class Speaker extends DropdownValue {
  abbreviation: string;

  constructor(option: string, abbreviation: string) {
    super(option);
    this.abbreviation = abbreviation;
  }
}
