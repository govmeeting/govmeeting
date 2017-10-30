import { Component, ElementRef } from '@angular/core';
import { AppData } from './appdata';

// This import was here from before the conversion to use angular-cli
// I am not sure if we still need it.
// import './operators';

// See aumentations.ts for the explanation of the following.
// import 'rxjs/Subject';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

//  constructor(private eltRef:ElementRef) {
//    //let prop = eltRef.getAttribute('clientonly');
//    let native = this.eltRef.nativeElement;
//    let test = native.getAttribute("clientonly");
//    console.log( 'clientonly - ', test);
//  }

  constructor(appData:AppData) {
    console.log('AppComponent - ', appData);
  }
}
