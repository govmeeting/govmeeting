import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {BackendService} from './../utilities/backend.service'
import {UserchoiceService, IUserChoiceSrv} from './../utilities/userchoice.service'
import {MyHighlightDirective} from '../myhighlight.directive'

@Component({
    selector: 'topics',
    templateUrl: './app/singlemeeting/topics.component.html',
    directives: [MyHighlightDirective],
    providers: [
        HTTP_PROVIDERS,
        BackendService
    ]
})
export class TopicsComponent {
    
    topicNames: string[];
    errorMessage: string;
    selectedTopic: number = 0;
    selectedTopicColor: string = 'green';
        
    constructor(private _backendService: BackendService,
        private _userChoice: UserchoiceService){};
    
    ngOnInit() {this.getTopicNames();}
    
    getTopicNames() {
        this._backendService.getMeeting()
        .subscribe(
        t => {this.topicNames = t.data.topicNames;
            // console.log(this.topicNames);},
        error => this.errorMessage = <any>error);
    }
    
    IsSelectedTopic(i: number) : boolean
    {
        return(this._userChoice.getTopic() == this.topicNames[i]);
    }
    
    FilterByTopic(i: number)
    {
        this.selectedTopic = i;
        console.log(this.topicNames[i])
        this._userChoice.setTopic(this.topicNames[i])
        if (i!=0){
            this._userChoice.setSpeaker("SHOW ALL")
        }
    }

    myTopic(newTopic: string) {
        if ((newTopic != null) && (newTopic != "")) {
            this._userChoice.setTopic(newTopic);
        }
        return this._userChoice.getTopic()
    }
}