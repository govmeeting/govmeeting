import { Component } from '@angular/core';

@Component({
  moduleId: module.id,
  selector: 'gm-matsamp',
  templateUrl: './matsamp.component.html',
  styleUrls: ['./matsamp.component.css']
})
export class MatsampComponent {
  title = 'matsamp works!';
  isDarkTheme : boolean = false;
  progress : number = 50;
}
