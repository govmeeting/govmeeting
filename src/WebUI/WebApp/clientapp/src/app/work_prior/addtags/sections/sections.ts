import { Component, OnInit } from '@angular/core';
import { AddtagsService } from '../addtags.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-sections',
  templateUrl: './sections.html',
  styleUrls: ['./sections.css'],
})
export class SectionsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  errorMessage: string;
  sections: string[];
  gotSections = false;

  constructor(private _addtagsService: AddtagsService) {}

  ngOnInit() {
    this.getSections();
  }

  getSections() {
    if (!this.gotSections) {
      this.gotSections = true;
      NoLog || console.log(this.ClassName + 'getSections');
      this._addtagsService.getTalks().subscribe(
        (addtags) => {
          this.sections = addtags.sections;
          NoLog || console.log(this.ClassName, this.sections);
        },
        (error) => (this.errorMessage = error as any)
      );
    }
  }

  OnChange(newValue: any) {
    NoLog || console.log(this.ClassName, newValue);
  }

  isEmptyObject(obj) {
    let prop;
    for (prop in obj) {
      if (obj.hasOwnProperty(prop)) {
        return false;
      }
    }
    return true;
  }
}
