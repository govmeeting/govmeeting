import {EventEmitter, Injectable} from '@angular/core';

@Injectable()
export class NavService {
  public sidenav: any;

  constructor() {
  }

  public closeNav() {
    this.sidenav.close();
  }

  public openNav() {
    this.sidenav.open();
  }
}
