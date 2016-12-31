import { Component } from '@angular/core';
import { SectionsService } from './sections.service';

/* This component is not now being used. We don't currently allow
 * a choice of a section. We can only move the sections that are
 * defined in the existing transcript.
*/
@Component({
    moduleId: module.id,
    selector: 'gm-sections',
    templateUrl: 'sections.component.html',
    providers: [SectionsService]
})
export class SectionsComponent {
    sections : string[];
    constructor(sectionsService: SectionsService) {
        this.sections = sectionsService.getSections();
    }
    OnChange(newValue: any) {
        console.log(newValue);
    }
}
