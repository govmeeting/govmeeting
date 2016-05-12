import {Component} from 'angular2/core';

@Component({
    selector: 'heading',
templateUrl: './app/singlemeeting/heading.component.html',
directives: []
})
export class HeadingComponent {
    meetingInfo = {name: "Boothbay Selectmen's Meeting",
        date: "Jan. 12, 2016"};
}