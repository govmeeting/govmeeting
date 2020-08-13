import { Component, NgZone } from '@angular/core';
import { Message } from './message';
import { ChatService } from './chat.service';

@Component({
  selector: 'gm-chat',
  templateUrl: './chat.html',
  styleUrls: ['./chat.scss', '../../app.component.scss'],
})
export class ChatComponent {
  title = 'clientapp';
  txtMessage = '';
  uniqueID: string = new Date().getTime().toString();
  messages = new Array<Message>();
  message = new Message();
  constructor(private chatService: ChatService, private _ngZone: NgZone) {
    // this.subscribeToEvents();
  }
  sendMessage(): void {
    if (this.txtMessage) {
      this.message = new Message();
      this.message.clientuniqueid = this.uniqueID;
      this.message.type = 'sent';
      this.message.message = this.txtMessage;
      this.message.date = new Date();
      this.messages.push(this.message);
      this.chatService.sendMessage(this.message);
      this.txtMessage = '';
    }
  }
  private subscribeToEvents(): void {
    this.chatService.messageReceived.subscribe((message: Message) => {
      this._ngZone.run(() => {
        if (message.clientuniqueid !== this.uniqueID) {
          message.type = 'received';
          this.messages.push(message);
        }
      });
    });
  }
}
