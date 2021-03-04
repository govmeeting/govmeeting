import { Injectable } from "@angular/core";

// our abstract class
@Injectable()
export abstract class MyServiceLoader {
  abstract printTime(): void;
  abstract getNow(): string;
}
