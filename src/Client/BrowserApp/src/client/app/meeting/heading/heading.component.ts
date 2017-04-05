import { Component, OnInit } from '@angular/core';
//import {HTTP_PROVIDERS} from '@angular/http';
import { MeetingService } from '../meeting.service';

@Component({
    moduleId: module.id,
    selector: 'gm-heading',
    templateUrl: 'heading.component.html'
    // directives: [],
    // The providers that we need are declared in meeting.component.ts
    // providers: [
    // ]
})
export class HeadingComponent implements OnInit {

    meetingInfo: any = {name: '', date: ''};

    errorMessage: string;

    constructor(private _meetingService: MeetingService) {};

    ngOnInit() {this.getMeetingInfo();}

    getMeetingInfo() {
        this._meetingService.getMeeting()
        .subscribe(
        (meeting: any) => {
            this.meetingInfo = meeting.meetingInfo;
            //console.log(this.meetingInfo);
        },
        (error: any) => this.errorMessage = <any>error);
    }
}
