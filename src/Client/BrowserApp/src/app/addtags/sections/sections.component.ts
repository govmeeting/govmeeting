import { Component, OnInit } from '@angular/core';
import { SectionsService } from './sections.service';

@Component({
  selector: 'gm-sections',
  templateUrl: './sections.component.html',
  styleUrls: ['./sections.component.css'],
  providers: [SectionsService]
})
export class SectionsComponent implements OnInit {

  sections : string[];

  constructor(sectionsService: SectionsService) {
      this.sections = sectionsService.getSections();
  }

  ngOnInit() {
  }

  OnChange(newValue: any) {
      console.log(newValue);
  }
}
