import {Component} from '@angular/core'
import {SectionsService} from './sections.service'

@Component({
    moduleId: module.id,
    selector: 'sections',
    templateUrl: 'sections.component.html',
    providers: [SectionsService]
})
export class SectionsComponent {
    sections : string[];
    constructor(sectionsService: SectionsService) {
        this.sections = sectionsService.getSections();
    }
    OnChange(newValue: any){
        console.log(newValue)
    }
}