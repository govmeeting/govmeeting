/* This code is from: https://blog.sanderaernouts.com/autogenerate-typescript-api-client-with-nswag
"When the clients are generated you still have to add a way for them to authenticate.
 In Angular you can do this with an HttpInterceptor: "
 https://angular.io/api/common/http/HttpInterceptor
*/

import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor {
  /**
   * Creates an instance of TokenInterceptor.
   * @memberof TokenInterceptor
   */
  constructor() {}

  /**
   * Intercept all HTTP request to add JWT token to Headers
   * @param {HttpRequest<any>} request
   * @param {HttpHandler} next
   * @returns {Observable<HttpEvent<any>>}
   * @memberof TokenInterceptor
   */
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    console.debug('appending bearer token to request:', request);
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${'<get your access token here'}`,
      },
    });

    return next.handle(request);
  }
}
