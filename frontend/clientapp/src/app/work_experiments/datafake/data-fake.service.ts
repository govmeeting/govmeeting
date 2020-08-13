import { Injectable } from '@angular/core';
import faker from 'faker';
import { random } from '@amcharts/amcharts4/.internal/core/utils/String';

// https://www.npmjs.com/package/faker and https://github.com/marak/Faker.js/

/*
https://www.npmjs.com/package/faker
https://github.com/marak/Faker.js/
https://github.com/Marak/faker.js/wiki

https://github.com/Marak/faker.js/issues/650
"Also... if you want to import only single locale ( as switching locals does strangely not work with typescript ) - import from
import * as faker from 'faker/locale/de_AT' for example.""
*/

interface Person {
  id: number;
  firstName: string;
  lastName: string;
  age: number;
}

enum randomDistributionType {
  uniform,
  guassian,
}

const NoLog = true; // set to false for console logging

@Injectable({
  providedIn: 'root',
})
export class DataFakeService {
  private ClassName: string = this.constructor.name + ': ';
  constructor() {}

  standard: any = null; // will contain a standard mean diaviation function

  id = 1; // starting id number
  person() {
    // this.testRandom(40, 20, randomDistributionType.guassian);

    const person = faker.name;
    return {
      id: this.id++,
      firstName: person.firstName(),
      lastInitial: person.lastName().charAt(0) + '.',
      age: this.randomInteger(30, 10, randomDistributionType.guassian),
    };
  }

  public randomInteger(mean: number, stdev: number, type: randomDistributionType) {
    if (type === randomDistributionType.uniform) {
      return this.randomUniformInteger(mean, stdev);
    }
    return this.randomGaussianInteger(mean, stdev);
  }

  ///////////////////////// Private //////////////////////////////////

  private randomUniformInteger(mean, stdev) {
    let diviation = Math.round(Math.random() * stdev);
    if (diviation % 2 === 0) {
      diviation = -diviation;
    }
    return mean + diviation;
  }

  private randomGaussianInteger(mean, stdev) {
    if (this.standard == null) {
      this.standard = this.gaussianFunction(mean, stdev);
    }
    return Math.round(this.standard());
  }

  private gaussianFunction(mean, stdev) {
    let y2;
    let useLast = false;
    return () => {
      let y1;
      if (useLast) {
        y1 = y2;
        useLast = false;
      } else {
        let x1;
        let x2;
        let w;
        do {
          x1 = 2.0 * Math.random() - 1.0;
          x2 = 2.0 * Math.random() - 1.0;
          w = x1 * x1 + x2 * x2;
        } while (w >= 1.0);
        w = Math.sqrt((-2.0 * Math.log(w)) / w);
        y1 = x1 * w;
        y2 = x2 * w;
        useLast = true;
      }
      const retval = mean + stdev * y1;
      if (retval > 0) {
        return retval;
      }
      return -retval;
    };
  }

  private testRandom(mean: number, stdev: number, type: randomDistributionType) {
    let i = 100;
    let s = '';
    while (i > 0) {
      s = s + ' ' + this.randomInteger(mean, stdev, type);
      i--;
    }
    NoLog || console.log(this.ClassName, s);
  }
}
