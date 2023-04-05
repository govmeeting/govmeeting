import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// import { IGovbodyDetailsDto, GovLocationDto, IOfficialDto } from '../apis/api.generated.clients'

@Component({
  selector: 'gm-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] | undefined;
  apistring = '/weatherforecast';

  // constructor(http: HttpClient, @Inject('API_BASE_URL') apiBaseUrl: string) {
  //   http.get<WeatherForecast[]>(apiBaseUrl + this.apistring).subscribe(
  //     (result) => {
  //       this.forecasts = result;
  //     },
  //     (error) => console.error(error)
  //   );
  // }

  constructor(http: HttpClient) {
    http.get<WeatherForecast[]>('http://localhost:5000' + this.apistring).subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => console.error(error)
    );
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

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
