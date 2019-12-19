import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
//import { TopicsService } from './topics.service';
import { AddtagsService } from '../service';

@Component({
    selector: 'gm-topicset',
    templateUrl: 'component.html',
    styleUrls: ['topicset.component.css']
})
export class TopicsComponent implements OnInit {
    topics: string[];
    errorMessage: string;

    @Input() newTopicName: string | undefined;

    @Output() topicSelect: EventEmitter<string>;
    @Output() topicEnter: EventEmitter<string>;

    constructor(private _addtagsService: AddtagsService) {
        this.topicSelect = new EventEmitter<string>();
        this.topicEnter = new EventEmitter<string>();
        this.newTopicName = undefined;
    }

    // Call getTopics after Angular is done creating the component.
    ngOnInit() {this.getTopics();}

    getTopics() {
        this._addtagsService.getTalks()
        .subscribe(
            addtags => {
                this.topics = addtags.topics;
                //console.log(this.topics);
            },
        error => this.errorMessage = <any>error);
    }

    // When the user select a topic, we raise the "topicSelect" event.
    // The parent component (TalksComponent) can then capture this event.
    OnChange(newValue: string) {
        this.topicSelect.emit(newValue);
        console.log('topic.component--topicSelect ' + newValue);
    }

    // When the user enters a new topic, we again raise the "topicSelect" event.
    // We get the new topic name from the bound "newTopicName" property.
    OnEnter() {
        this.topicSelect.emit(this.newTopicName);
        console.log('topic.component--topicSelect ' + this.newTopicName);
    }
}
