import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { map } from 'rxjs/operators';
import { Observable, ObservableInput, of } from 'rxjs';
import { catchError } from 'rxjs/operators/catchError.js';

// https://davembush.github.io/where-to-store-angular-configurations/
export function loadConfiguration(http: HttpClient, config: ConfigService): () => Promise<boolean> {
  return (): Promise<boolean> => {
    return new Promise<boolean>((resolve: (a: boolean) => void): void => {
      // resolve(true);
      http
        .get('./assets/config.json')
        .pipe(
          map((x: ConfigService) => {
            config.baseUrl = x.baseUrl;
            // console.log("baseUrl=" + config.baseUrl);
            resolve(true);
          }),
          catchError(
            (x: { status: number }, caught: Observable<void>): ObservableInput<{}> => {
              if (x.status !== 404) {
                resolve(false);
              }
              config.baseUrl = 'http://localhost:8080/api';
              resolve(true);
              return of({});
            }
          )
        )
        .subscribe();
    });
  };
}
