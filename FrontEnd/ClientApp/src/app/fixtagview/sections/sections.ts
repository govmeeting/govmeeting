import { Component, OnInit } from '@angular/core';
import { FixtagviewService } from '../fixtagview.service';

const NoLog = true;  // set to false for console logging

@Component({
  selector: 'gm-sections',
  templateUrl: './sections.html',
  styleUrls: ['./sections.css'],
})
export class SectionsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
    errorMessage: string;
    sections: string[];
    gotSections: boolean = false;

  constructor(private _fixtagviewService: FixtagviewService) {
  }

    ngOnInit() { this.getSections(); }

getSections() {
  if (! this.gotSections) {
    this.gotSections = true;
    NoLog || console.log(this.ClassName + 'getSections');
    this._fixtagviewService.getTalks()
        .subscribe(
        addtags => {
            this.sections = addtags.sections;
            NoLog || console.log(this.ClassName, this.sections);
        },
        error => this.errorMessage = <any>error);
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

