import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'gm-gov-info',
  templateUrl: './gov-info.component.html',
  styleUrls: ['./gov-info.component.scss']
})
export class GovInfoComponent implements OnInit, OnDestroy {
  item: string;
  private sub: any;
  information: string;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.item = params['item'];

      // In a real app: dispatch action to load the details here.

      let x = this.item.indexOf(';');
      let location = this.item.substr(0, x-1)
      // this.information = location;

      switch (location) {
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
