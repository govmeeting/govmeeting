import { Component, Input } from '@angular/core';

@Component({
  selector: 'gm-small',
  templateUrl: './small.component.html',
  styleUrls: ['./small.component.scss']
})
export class SmallComponent   {
  // @Input() title: string;

  sampleContent: string = 'A rather long string of English text, an error message ' +
  'actually that just keeps going and going -- an error ' +
  'message to make the Energizer bunny blush (right through ' +
  'those Schwarzenegger shades)! Where was I? Oh yes, ' +
  'you\'ve got an error and all the extraneous whitespace is ' +
  'just gravy.  Have a nice day.';

  constructor() { }

}
