import { Component, VERSION } from '@angular/core';

@Component({
  selector: 'gm-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  public isCollapsed = true;
  version: string;

  constructor() {
    this.version = VERSION.full;
  }
}
