import { Injectable } from '@angular/core';

// This was used temporarily while debugging appinit\service-manager.module.ts

@Injectable()
export abstract class MyService {
  abstract printTime(): void;
  abstract getNow(): string;
}
