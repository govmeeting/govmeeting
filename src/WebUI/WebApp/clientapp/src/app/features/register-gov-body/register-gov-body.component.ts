import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { sample } from 'rxjs/operators';
import { IGovbodyDetails } from '../../models/govbody-view';

import { SampleMapper } from '../../models/sample-mapper';

@Component({
  selector: 'gm-register-gov-body',
  templateUrl: './register-gov-body.component.html',
  styleUrls: ['./register-gov-body.component.scss'],
})
export class RegisterGovBodyComponent {
  @Output() register = new EventEmitter<IGovbodyDetails>();

  form: FormGroup;
  sampleMapper = new SampleMapper;

  constructor(fb: FormBuilder) {

    this.sampleMapper.useMapper();
    
    this.form = fb.group({
      name: [null, [Validators.required]],
      officials: [null, [Validators.required]],
      officers: [null, [Validators.required]],
      recordingsUrl: [null, []],
      transcriptsUrl: [null, []],
    });
  }

  submit(form: IGovbodyDetails, valid: boolean) {
    this.form.markAllAsTouched();
    if (valid) {
      this.register.emit(form);
    }
  }

  hasError(controlName: string, error: string) {
    const control = this.form.get(controlName);
    return control.touched && control.hasError(error);
  }
}
