import { Component, OnInit } from '@angular/core';
import { AddtagsService } from '../service';

@Component({
  selector: 'gm-sections',
  templateUrl: './component.html',
  styleUrls: ['./component.css'],
})
export class SectionsComponent implements OnInit {
    errorMessage: string;
    sections: string[];
    gotSections: boolean = false;

  constructor(private _addtagsService: AddtagsService) {
  }

    ngOnInit() { this.getSections(); }

getSections() {
  if (! this.gotSections) {
    this.gotSections = true;
    console.log('getSections');
    this._addtagsService.getTalks()
        .subscribe(
        addtags => {
            this.sections = addtags.sections;
             console.log(this.sections);
        },
        error => this.errorMessage = <any>error);
      }
    }

 OnChange(newValue: any) {
      console.log(newValue);
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

