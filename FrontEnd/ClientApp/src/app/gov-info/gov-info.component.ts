import { Component, OnInit, Input } from '@angular/core';

const NoLog = false;  // set to false for console logging

@Component({
  selector: 'gm-gov-info',
  templateUrl: './gov-info.component.html',
  styleUrls: ['./gov-info.component.scss']
})
export class GovInfoComponent implements OnInit {
  private ClassName: string = this.constructor.name + ": ";
  public _location = '';
  public _agency = '';

  @Input()
    set location(location: string) {
      this._location = location;
      NoLog || console.log(this.ClassName + "set location=" + location)
    }
    get location(): string { return this._location; }

    @Input()
    set agency(agency: string) {
      this._agency = agency;
      NoLog || console.log(this.ClassName + "set agency=" + agency)
    }
    get agency(): string { return this._agency; }

  constructor() { }

  ngOnInit() {
  }

}


// #### Prior method of using routing ####

// import { ActivatedRoute } from '@angular/router';

// export class GovInfoComponent implements OnInit, OnDestroy {
  // location: string;
  // agency: string;
  // private sub: any;
  // information: string;

  // constructor(private route: ActivatedRoute) {}

//   ngOnInit() {
//     this.sub = this.route.params.subscribe(params => {
//       this.location = params['location'];
//       this.agency = params['agency'];

//       NoLog || console.log(this.ClassName + "gov-info:location="+this.location+"agency="+this.agency)

//       // In a real app: dispatch action to load the details here.

//       switch (this.location) {
//         case 'Austin': {
//           this.information = "info on Austin";
//           break;
//         }
//         case 'Travis County': {
//           this.information = "info on Travis";
//           break;
//         }
//         case 'Texas':{
//           this.information = "info on Texas";
//           break;
//         }
//         case 'United States':{
//           this.information = "info on US";
//           break;
//         }
//       }
//    });
//  }

//   ngOnDestroy() {
//     this.sub.unsubscribe();
//   }

// }
