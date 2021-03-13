import { Injectable } from "@angular/core";
import { ReplaySubject } from "rxjs";
import { Observable } from "rxjs/Observable";
import { Subject } from "rxjs/Subject";

//export var observableLog = Observable.create((observer: any) => {
//  observer.next('Hey guys!')
//  setInterval(() => {
//    observer.next('I am good')
//  }, 2000)
//})

//observableLog.subscribe((x: any) => console.log(x));

//export var subjectLog = new Subject();
//subjectLog.next("The first things was sent.")


export var replaySubjectLog = new ReplaySubject(99);
replaySubjectLog.next("logger-service. The first replay msg sent.")
