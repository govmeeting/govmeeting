import {Component, OnInit} from '@angular/core';
//import {HTTP_PROVIDERS} from '@angular/http';
import { BackendService } from '../../shared/index';

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

    constructor(private _backendService: BackendService) {};

    ngOnInit() {this.getMeetingInfo();}

    getMeetingInfo() {
        this._backendService.getMeeting()
        .subscribe(
        (t: any) => {
            this.meetingInfo = t.meetingInfo;
            //console.log(this.meetingInfo);
        },
        (error: any) => this.errorMessage = <any>error);
    }
}
