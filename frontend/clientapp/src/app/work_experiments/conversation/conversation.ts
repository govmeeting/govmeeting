import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/from';
import 'rxjs/add/operator/map';

import { ConversationService } from './conversation.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-conversation',
  templateUrl: './conversation.html',
  styleUrls: ['./conversation.scss'],
})
export class ConversationComponent implements OnInit {
  constructor(private ms: ConversationService, private router: Router) {}
  private ClassName: string = this.constructor.name + ': ';

  // conversations: any
  conversations: any = [
    { display_name: 'Wrightsboro Residents', id: '1', members: [{ username: 'Joe' }, { username: 'Sue' }] },
    { display_name: 'Wrightsboro Volunteers', id: '2', members: [{ username: 'Hank' }, { username: 'Mary' }] },
  ];

  selectedConversation: any;
  text: string;
  events: Array<any> = [];

  // buildConversationsArray(conversations) {
  //   let array = [];

  //   for (let conversation in conversations) {
  //     array.push(conversations[conversation]);
  //   }

  //   return array
  // }

  ngOnInit() {
    // if (!this.ms.app) {
    //   this.router.navigate(['/']);
    // } else {
    //   this.ms.app.getConversations().then(conversations => {
    //     this.conversations = this.buildConversationsArray(conversations)
    //   })
    // }
  }

  // selectConversation(conversationId: string) {
  //   this.ms.app.getConversation(conversationId).then(conversation => {
  //     this.selectedConversation = conversation

  //     Observable.from(conversation.events.values()).subscribe(
  //       event => {
  //         this.events.push(event)
  //       }
  //     )

  //     this.selectedConversation.on("text", (sender, message) => {
  //       this.events.push(message)
  //     })

  //     NoLog || console.log(this.ClassName + "Selected", this.selectedConversation)
  //   }
  //   )
  // }

  selectConversation(i: number) {
    this.selectedConversation = this.conversations[i];
  }

  // sendText(text: string) {
  //   this.selectedConversation.sendText(text).then(() => this.text = "")
  // }

  sendText(text: string) {
    this.text = text;
  }
}
