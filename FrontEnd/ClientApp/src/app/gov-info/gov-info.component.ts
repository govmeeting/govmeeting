import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'gm-gov-info',
  templateUrl: './gov-info.component.html',
  styleUrls: ['./gov-info.component.scss']
})
export class GovInfoComponent implements OnInit, OnDestroy {
  location: string;
  agency: string;
  private sub: any;
  information: string;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.location = params['location'];
      this.agency = params['agency'];

      console.log("gov-info:location="+this.location+"agency="+this.agency)

      // In a real app: dispatch action to load the details here.

      switch (this.location) {
        case 'Austin': {
          this.information = "info on Austin";
          break;
        }
        case 'Traves County': {
          this.information = "info on Travis";
          break;
        }
        case 'Texas':{
          this.information = "info on Texas";
          break;
        }
        case 'United States':{
          this.information = "info on US";
          break;
        }
      }
   });
 }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
