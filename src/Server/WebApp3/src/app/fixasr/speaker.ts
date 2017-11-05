import { DropdownValue } from '../shared/dropdown/dropdown.value';

export class Speaker extends DropdownValue {
  abbreviation:string;

  constructor(option:string, abbreviation:string) {
    super(option);
    this.abbreviation = abbreviation;
  }
}
