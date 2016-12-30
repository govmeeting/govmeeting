import {Component, OnInit} from '@angular/core';
//import {HTTP_PROVIDERS} from '@angular/http';
import { BackendService } from '../../shared/index';
import {UserchoiceService} from '../../shared/index';
import {MyHighlightDirective} from '../../shared/index';

@Component({
    moduleId: module.id,
    selector: 'gm-speakers',
    templateUrl: 'speakers.component.html',
    directives: [MyHighlightDirective],
    // The providers that we need are declared in meeting.component.ts
    providers: [
    ]
})
export class SpeakersComponent implements OnInit {

    speakerNames: string[];
    errorMessage: string;
    selectedSpeaker: number = 0;

    constructor(private _backendService: BackendService,
        private _userChoice: UserchoiceService) {};

    ngOnInit() {
        this.getSpeakerNames();
        this._userChoice.setSpeaker('SHOW ALL');
    }

    getSpeakerNames() {
        this._backendService.getMeeting()
        .subscribe(
        t => {
            this.speakerNames = t.speakerNames;
            // console.log(this.speakerNames);},
        },
            // console.log(this.speakerNames);},
        error => this.errorMessage = <any>error);
    }

    IsSelectedSpeaker(i: number) : boolean {
        return(this._userChoice.getSpeaker() === this.speakerNames[i]);
    }

    FilterBySpeaker(i: number) {
        this.selectedSpeaker = i;
        //console.log(this.speakerNames[i])
        this._userChoice.setSpeaker(this.speakerNames[i]);
        if (i!==0) {
            this._userChoice.setTopic('SHOW ALL');
        }
    }

/*
    mySpeaker(newSpeaker: string) {
        //if (angular.isDefined(newSpeaker)) {
        if ((newSpeaker != null) && (newSpeaker != "")) {
            this._userChoice.setSpeaker(newSpeaker);
        }
        return this._userChoice.getSpeaker()
    }
*/
}

