import { Injectable } from '@angular/core';

export interface IUserChoiceSrv {
  getSpeaker(): string;
  setSpeaker(speaker: string): void;
  getTopic(): string;
  setTopic(topic: string): void;
}

/*
 * <summary>
 *  A user choice server.
 * </summary>
 */

@Injectable()
export class UserchoiceService implements IUserChoiceSrv {
  _speaker: string;
  _topic: string;

  getSpeaker(): string {
    return this._speaker;
  }

  setSpeaker(speaker: string) {
    this._speaker = speaker;
    if (speaker !== 'SHOW ALL') {
      this.setTopic('SHOW ALL');
    }
  }

  getTopic(): string {
    return this._topic;
  }

  setTopic(topic: string) {
    this._topic = topic;
    if (topic !== 'SHOW ALL') {
      this.setSpeaker('SHOW ALL');
    }
  }
}
