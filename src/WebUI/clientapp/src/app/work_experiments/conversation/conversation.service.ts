import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var ConversationClient: any;
const GATEWAY_URL = 'http://localhost:3000/api/';

@Injectable()
export class ConversationService {
  constructor(private http: HttpClient) {}

  public client: any;
  public app: any;

  initialize() {
    this.client = new ConversationClient({
      debug: false,
    });
  }

  public getUserJwt(username: string): Promise<any> {
    return this.http
      .get(GATEWAY_URL + 'jwt/' + username + '?admin=true')
      .toPromise()
      .then((response: any) => response.user_jwt);
  }
}
