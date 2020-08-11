import { Component, Input, Output, OnInit } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { DropdownValue } from './value';
import { FormBuilder, Validators } from '@angular/forms';
// import { FormGroup, ReactiveFormsModule } from '@angular/forms'

const NoLog = true; // set to false for console logging

@Component({
  // moduleId: module.id,
  selector: 'gm-dropdown',
  templateUrl: 'dropdown.html',
  styleUrls: ['./dropdown.css'],
})
export class DropdownComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  @Input()
  values: DropdownValue[];

  @Output()
  selectSpeaker: EventEmitter<number>;

  @Output()
  addSpeaker: EventEmitter<string>;

  public newOptionForm = this.fb.group({
    newOption: ['', Validators.required],
  });

  constructor(public fb: FormBuilder) {
    this.selectSpeaker = new EventEmitter();
    this.addSpeaker = new EventEmitter();
  }

  ngOnInit() {}

  onSelectChange(i: number) {
    NoLog || console.log(this.ClassName + 'selected index=' + i);
    this.selectSpeaker.emit(i);
  }

  onNewEntry(event: any) {
    NoLog || console.log(this.ClassName, event);
    const value = this.newOptionForm.value.newOption;
    this.newOptionForm.reset();
    this.addSpeaker.emit(value);
  }
}

// Then you can use the component like this:
//   <gm-dropdown [values]="dropdownvalues" (select)="action($event)"></dropdown>
// Note that dropdownvalues and the action method are on the parent component (not the dropdown one).
//   dropdownvalues: DropdownValue [] = [
//     {'value': 'value1', 'label': 'label1'},
//     {'value': 'value2', 'label': 'label2'},
//     {'value': 'value3', 'label': 'label3'}
//   ];
//   action(d: any){
//     NoLog || console.log(this.ClassName + "selected=" + d.label);
//   }
