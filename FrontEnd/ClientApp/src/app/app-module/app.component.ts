import { Component, VERSION } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
  public collapsed = true;
  version: string;

  constructor() {
    this.version = VERSION.full;
  }

 toggleCollapsed() {
   this.collapsed = !this.collapsed;

 }

}
