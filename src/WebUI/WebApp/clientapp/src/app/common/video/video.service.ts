import { Injectable } from '@angular/core';

// our abstract class
@Injectable()
export abstract class VideoService {
  abstract getLocation(): string;
  abstract getFileBasename(): string;
}
