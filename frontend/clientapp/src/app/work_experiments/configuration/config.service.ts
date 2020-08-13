import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  baseUrl: string;
  isAspServerRunning: boolean;
  constructor() {}
}
