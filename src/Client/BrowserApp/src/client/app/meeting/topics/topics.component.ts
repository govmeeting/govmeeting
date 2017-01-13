import { Component, OnInit } from '@angular/core';
//import { HTTP_PROVIDERS } from '@angular/http';
import { BackendService } from '../../shared/index';
import { UserchoiceService } from '../../shared/index';
// import { MyHighlightDirective}  from '../../shared/index';

@Component({
    moduleId: module.id,
    selector: 'gm-topics',
    templateUrl: 'topics.component.html'
    // directives: [MyHighlightDirective],
    // The providers that we need are declared in meeting.component.ts
    // providers: [
    // ]
})
export class TopicsComponent implements OnInit {

    topicNames: string[];
    errorMessage: string;
    selectedTopic: number = 0;
    selectedTopicColor: string = 'green';

    constructor(private _backendService: BackendService,
        private _userChoice: UserchoiceService) {};

    ngOnInit() {
        this.getTopicNames();
        this._userChoice.setTopic('SHOW ALL');
    }

    getTopicNames() {
        this._backendService.getMeeting()
        .subscribe(
        t => {
            this.topicNames = t.topicNames;
            // console.log(this.topicNames);
        },
        error => this.errorMessage = <any>error);
    }

    IsSelectedTopic(i: number) : boolean {
        return(this._userChoice.getTopic() === this.topicNames[i]);
    }

    FilterByTopic(i: number) {
        this.selectedTopic = i;
        //console.log(this.topicNames[i])
        this._userChoice.setTopic(this.topicNames[i]);
        if (i!==0) {
            this._userChoice.setSpeaker('SHOW ALL');
        }
    }

    myTopic(newTopic: string) {
        if ((newTopic !== null) && (newTopic !== '')) {
            this._userChoice.setTopic(newTopic);
        }
        return this._userChoice.getTopic();
    }
}
