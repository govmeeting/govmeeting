import { Component, ElementRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(private eltRef:ElementRef) {
    //let prop = eltRef.getAttribute('clientonly');
    let native = this.eltRef.nativeElement;
    let test = native.getAttribute("clientonly");
    console.log( 'clientonly - ', test);
  }
}
