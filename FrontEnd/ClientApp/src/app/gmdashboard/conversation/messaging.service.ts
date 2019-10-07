import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


declare var ConversationClient: any;
const GATEWAY_URL = "http://localhost:3000/api/";

@Injectable()
export class MessagingService {


  constructor(private http: HttpClient) {

  }

  initialize() {
    this.client = new ConversationClient(
      {
        debug: false
      }
    )
  }

  public client: any
  public app: any

  public getUserJwt(username: string): Promise<any> {
    return this.http.get(GATEWAY_URL + "jwt/" + username + "?admin=true")
    .toPromise().then((response: any) => response.user_jwt)
  }
}
