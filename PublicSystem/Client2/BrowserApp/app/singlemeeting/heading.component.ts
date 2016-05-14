import {Component, OnInit} from 'angular2/core';
import {BackendService} from './../utilities/backend.service'
import {HTTP_PROVIDERS} from 'angular2/http';

@Component({
    selector: 'heading',
    templateUrl: './app/singlemeeting/heading.component.html',
    directives: [],
    providers: [
        HTTP_PROVIDERS,
        BackendService
    ]
})
export class HeadingComponent {
    
    meetingInfo: any = {name: "", date: ""};

    errorMessage: string;
        
    constructor(private _backendService: BackendService){};
    
    ngOnInit() {this.getMeetingInfo();}
    
    getMeetingInfo() {
        this._backendService.getMeeting()
        .subscribe(
        t => this.meetingInfo = t.data.meetingInfo,
            // console.log(this.meetingInfo);},
        error => this.errorMessage = <any>error);
    }

}