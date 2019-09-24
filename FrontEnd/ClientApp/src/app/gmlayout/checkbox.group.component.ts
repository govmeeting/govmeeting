import { Component, Input } from '@angular/core';

@Component({
  selector : 'ff-checkbox-group',
  styles : [`
    div[fxLayoutAlign] { padding:4px; }
  `],
  template : `
    <div fxLayout="row wrap" fxLayoutAlign="space-around center">
      <div *ngFor="let question of questions; let i = index">
        <mat-slide-toggle [id]="question.key" >  {{question.label}} </mat-slide-toggle>
      </div>
    </div>
  `
})
export class CheckboxGroupComponent {
  @Input('dataProvider') questions : Array<any>;
}
