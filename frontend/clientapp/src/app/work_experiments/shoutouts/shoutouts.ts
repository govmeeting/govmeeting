import { Component, OnInit } from '@angular/core';
import { DataFactoryService } from '../datafake/data-factory.service';
import { DataFakeService } from '../datafake/data-fake.service';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-shoutouts',
  templateUrl: './shoutouts.html',
  styleUrls: ['./shoutouts.scss'],
})
export class ShoutoutsComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  // personFactory: any;
  // personFake: any;

  _fake: DataFakeService;

  b: any;
  c: any;

  /*   james: any;
  youngBob: any;
  anybody: any;
  theBradyBunch: any[];
  theBradyBunch2: any[];
 */
  constructor(factory: DataFactoryService, fake: DataFakeService) {
    /*     this.personFactory = factory.personFactory;
    this.personFake = fake.personFake;
 */
    this._fake = fake;
  }

  ngOnInit() {
    /*     this.anybody = this.personFactory.build();
    this.youngBob = this.personFactory.build({ age: 5 });
    this.james = this.personFactory.build({firstName: "James",});
    this.theBradyBunch = this.personFactory.buildList(8, { lastName: "Brady" });
    this.personFactory.resetSequenceNumber();
    this.theBradyBunch2 = this.personFactory.buildList(8, { lastName: "Brady" });
 */
    this.b = this._fake.person();
    NoLog || console.log(this.ClassName, this.b);
    this.c = this._fake.person();
  }
}
