import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
//import { sample } from 'rxjs/operators';
import { RegisterGovBodyService } from './register-gov-body.service'
import { IGovbodyDetails_Vm, IGovLocation_Vm, IOfficial_Vm } from '../../models/govbody-view';
import { Observable } from 'rxjs';

import { IGovLocation_Dto} from '../../apis/api.generated.clients'

@Component({
  selector: 'gm-register-gov-body',
  templateUrl: './register-gov-body.component.html',
  styleUrls: ['./register-gov-body.component.scss'],
})
export class RegisterGovBodyComponent implements OnInit {
  @Output() register = new EventEmitter<IGovbodyDetails_Vm>();

  form: FormGroup;
  gBService: RegisterGovBodyService;
  //observable: Observable<IGovLocation_Dto[]>;
  myGovlocations: IGovLocation_Vm[];


  constructor(fb: FormBuilder, _gBService: RegisterGovBodyService) {
  
    this.form = fb.group({
      name: [null, [Validators.required]],
      officials: [null, [Validators.required]],
      officers: [null, [Validators.required]],
      recordingsUrl: [null, []],
      transcriptsUrl: [null, []],
    });
    this.gBService = _gBService;
  }

  ngOnInit() {
  //  this.registerService.testMapper();

    //this.myGovlocations = this.registerService.getMyGovLocations();
    this.myGovlocations = this.gBService.getMyGovLocations();

  }

  submit(form: IGovbodyDetails_Vm, valid: boolean) {
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
