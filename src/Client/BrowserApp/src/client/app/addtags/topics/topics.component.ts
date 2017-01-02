import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { TopicsService } from './topics.service';

@Component({
    moduleId: module.id,
    selector: 'gm-topicset',
    templateUrl: 'topics.component.html',
    styleUrls: ['topicset.component.css']
})
export class TopicsComponent implements OnInit {
    // topics: string[] = ["abc", "def"]; // DEBUG
    topics: string[];

    errorMessage: string;
    @Input() newTopicName: string;

    @Output() topicSelect: EventEmitter<string>;
    @Output() topicEnter: EventEmitter<string>;

    constructor(private _topicsService: TopicsService) {
        this.topicSelect = new EventEmitter<string>();
        this.topicEnter = new EventEmitter<string>();
        this.newTopicName = null;
    }

    // Call getTopics after Angular is done creating the component. 
    ngOnInit() {this.getTopics();}

    getTopics() {
        this._topicsService.getTopics()
        .subscribe(
        topics => this.topics = topics.data,
        error => this.errorMessage = <any>error);
    }
/*
    getTopics() {
        this._topicsService.getTopicsFromFile()
        .subscribe(
        topics => this.topics = topics,
        error => this.errorMessage = <any>error);
    }  
*/
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

    /* For debugging
    GetTopicsBtn(){
        this._topicsService.getTopics()
        .subscribe(
        t => {this.xtopics = t.data; console.log(t.data);},
        error => this.errorMessage = <any>error);
    }*/
}
