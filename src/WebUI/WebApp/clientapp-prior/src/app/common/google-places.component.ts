/// <reference types="@types/googlemaps" />
import { Component, ViewChild, EventEmitter, Output, OnInit, AfterViewInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
//import { } from '@types/googlemaps';

// From: Google Address Autocomplete feature using Angular
//    https://medium.com/@dhormale/use-google-places-api-autocomplete-using-angular-for-resident-and-office-address-23cc33078e8

@Component({
  selector: 'AutocompleteComponent',
  template: `
    <input
      class="input"
      type="text"
      [(ngModel)]="autocompleteInput"
      #addresstext
      style="padding: 12px 20px; border: 1px solid #ccc; width: 400px"
    />
  `,
})
export class AutocompleteComponent implements OnInit, AfterViewInit {
  @Input() adressType: string;
  @Output() setAddress: EventEmitter<any> = new EventEmitter();
  @ViewChild('addresstext') addresstext: any;

  autocompleteInput: string;
  queryWait: boolean;

  constructor() {}

  ngOnInit() {}

  ngAfterViewInit() {
    this.getPlaceAutocomplete();
  }

  private getPlaceAutocomplete() {
    const autocomplete = new google.maps.places.Autocomplete(this.addresstext.nativeElement, {
      componentRestrictions: { country: 'US' },
      types: [this.adressType], // 'establishment' / 'address' / 'geocode'
    });
    google.maps.event.addListener(autocomplete, 'place_changed', () => {
      const place = autocomplete.getPlace();
      this.invokeEvent(place);
    });
  }

  invokeEvent(place: Object) {
    this.setAddress.emit(place);
  }
}

/*
 *
 * To get API key follow instruction on https://developers.google.com/maps/documentation/javascript/get-api-key
 *
 *    <script src=”https://maps.googleapis.com/maps/api/js?libraries=places&key=GOOGLE_KEY"></script>
 *
      For Residential Address:
            <AutocompleteComponent (setAddress)="getAddress($event)" adressType="geocode"></AutocompleteComponent>
      For Office Address:
            <AutocompleteComponent (setAddress)="getEstablishmentAddress($event)" adressType="establishment"></AutocompleteComponent>

      On component file getAddress / getEstablishmentAddress method will emit place object which can be parsed to show on screen in required format.
          ...
          getAddress(place: object) {
             this.address = place[‘formatted_address’];
          ...

      For complete code refer below GitHub source.
        GitHub source: https://github.com/dhormale/google-places-autocomplete
 *
 */
