import { Injectable } from '@angular/core';
import * as Factory from 'factory.ts';

// https://www.npmjs.com/package/factory.ts and https://github.com/willryan/factory.ts
// https://www.npmjs.com/package/faker and https://github.com/marak/Faker.js/

/*
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

@Injectable({
  providedIn: 'root',
})
export class DataFactoryService {
  constructor() {}

  personFactory = Factory.Sync.makeFactory<Person>({
    id: Factory.each((i) => i),
    firstName: 'Bob',
    lastName: 'Smith',
    // age: Factory.each(i => 20 + (i % 10))
    age: Factory.each(() => this.randomInteger(20, 60)),
  });

  randomInteger(start, end) {
    return start + Math.round(Math.random() * (end - start));
  }
}
