import { Component, OnInit } from '@angular/core';
import { DataFactoryService } from '../data-factory.service';

@Component({
  selector: 'gm-shoutouts',
  templateUrl: './shoutouts.component.html',
  styleUrls: ['./shoutouts.component.scss']
})
export class ShoutoutsComponent implements OnInit {
  personFactory: any;
  james: any;
  youngBob: any;
  anybody: any;
  theBradyBunch: any[];
  theBradyBunch2: any[];

  constructor(_dfs: DataFactoryService) {
    this.personFactory = _dfs.personFactory;
  }

  ngOnInit() {
    this.anybody = this.personFactory.build();
    this.youngBob = this.personFactory.build({ age: 5 });
    this.james = this.personFactory.build({firstName: "James",});
    this.theBradyBunch = this.personFactory.buildList(8, { lastName: "Brady" });
    this.personFactory.resetSequenceNumber();
    this.theBradyBunch2 = this.personFactory.buildList(8, { lastName: "Brady" });
  }
}
