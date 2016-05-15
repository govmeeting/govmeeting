import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {BackendService} from './../utilities/backend.service'
import {UserchoiceService, IUserChoiceSrv} from './../utilities/userchoice.service'
import {MyHighlightDirective} from './../myhighlight.directive'

@Component({
    selector: 'speakers',
    templateUrl: './app/singlemeeting/speakers.component.html',
    directives: [MyHighlightDirective],
    providers: [
        HTTP_PROVIDERS,
        BackendService,
        //UserchoiceService
    ]
})
export class SpeakersComponent {
    
    speakerNames: string[];
    errorMessage: string;
    selectedSpeaker: number = 0;
        
    constructor(private _backendService: BackendService,
        private _userChoice: UserchoiceService){};
    
    ngOnInit() {this.getSpeakerNames();}
    
    getSpeakerNames() {
        this._backendService.getMeeting()
        .subscribe(
        t => {this.speakerNames = t.data.speakerNames;},
            // console.log(this.speakerNames);},
        error => this.errorMessage = <any>error);
    }
    
    IsSelectedSpeaker(i: number) : boolean
    {
        return(this._userChoice.getSpeaker() == this.speakerNames[i]);
    }

    FilterBySpeaker(i: number)
    {
        this.selectedSpeaker = i;
        console.log(this.speakerNames[i])
        this._userChoice.setSpeaker(this.speakerNames[i])
        this._userChoice.setSpeaker(this.speakerNames[i])
        if (i!=0){
            this._userChoice.setTopic("SHOW ALL")
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

