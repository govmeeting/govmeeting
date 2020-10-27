import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DashCardsService {
  private subject = new Subject<string>();

  clearMessages() {
    this.subject.next();
  }

  sendMessage(message: string) {
    this.subject.next(message);
  }

  getMessage(): Observable<string> {
    return this.subject.asObservable();
  }
}
