import { Injectable } from "@angular/core";

// our abstract class
@Injectable()
export abstract class MyService {
  abstract printTime(): void;
  abstract getNow(): string;
}
