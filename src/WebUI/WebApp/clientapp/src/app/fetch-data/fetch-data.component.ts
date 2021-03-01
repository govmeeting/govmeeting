import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// import { IGovbodyDetails_Dto, GovLocation_Dto, IOfficial_Dto } from '../apis/api.generated.clients'

@Component({
  selector: 'gm-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  apistring = '/weatherforecast';

  constructor(http: HttpClient, @Inject('API_BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + this.apistring).subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => console.error(error)
    );
  }

  // For debugging GetMyGovLocations call.
  // public govlocations: GovLocation_Dto[];
  // apistring: string = "/api/GovLocation/GetMyGovLocations";
  // constructor(http: HttpClient, @Inject('API_BASE_URL') baseUrl: string) {
  //  http.get<GovLocation_Dto[]>(baseUrl + this.apistring).subscribe(
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
