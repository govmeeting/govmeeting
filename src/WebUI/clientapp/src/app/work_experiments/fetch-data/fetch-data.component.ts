import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { WeatherForecastService } from '../../core/api/v1/api/api';
import { WeatherForecast } from '../../core/api/v1/model/models';
import { Observable } from 'rxjs';
// import { IGovbodyDetailsDto, GovLocationDto, IOfficialDto } from '../apis/api.generated.clients'

@Component({
  selector: 'gm-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent implements OnInit {
  // public forecasts: WeatherForecast[] | undefined;
  apistring = '/api/weatherforecast';

  // constructor(http: HttpClient, @Inject('API_BASE_URL') apiBaseUrl: string) {
  //   http.get<WeatherForecast[]>(apiBaseUrl + this.apistring).subscribe(
  //     (result) => {
  //       this.forecasts = result;
  //     },
  //     (error) => console.error(error)
  //   );
  // }

  // constructor(http: HttpClient) {
  // http.get<WeatherForecast[]>('http://localhost:5066' + this.apistring).subscribe(
  //   (result) => {
  //     this.forecasts = result;
  //   },
  //   (error) => console.error(error)
  // );
  // }

  forecasts: Observable<WeatherForecast[]> | undefined;

  constructor(private weatherService: WeatherForecastService) {}

  ngOnInit(): void {
    // The next time we run "npm run generate:api", the method name will change to "getWeatherForecast".
    this.forecasts = this.weatherService.weatherForecastGet();
  }

  // For debugging GetMyGovLocations call.
  // public govlocations: GovLocationDto[];
  // apistring: string = "/api/GovLocation/GetMyGovLocations";
  // constructor(http: HttpClient, @Inject('API_BASE_URL') apiBaseUrl: string) {
  //  http.get<GovLocationDto[]>(apiBaseUrl + this.apistring).subscribe(
  //    (result) => {
  //      this.govlocations = result;
  //    },
  //    (error) => console.error(error)
  //  );
  // }
}

// interface WeatherForecast {
//   date: string;
//   temperatureC: number;
//   temperatureF: number;
//   summary: string;
// }
