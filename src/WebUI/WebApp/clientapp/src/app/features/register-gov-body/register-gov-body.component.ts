import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterGovBodyService } from './register-gov-body.service';
import { IGovbody_Vm, IGovbodyDetails_Vm, IGovLocation_Vm, IOfficial_Vm } from '../../models/govbody-view';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'gm-register-gov-body',
  templateUrl: './register-gov-body.component.html',
  styleUrls: ['./register-gov-body.component.scss'],
})
export class RegisterGovBodyComponent implements OnInit {
  @Output() register = new EventEmitter<IGovbodyDetails_Vm>();

  form: FormGroup;
  gBService: RegisterGovBodyService;

  locations$: Observable<IGovLocation_Vm[]> | null = null;
  bodies$: Observable<IGovbody_Vm[]> | null = null;
  bodyDetails$: Observable<IGovbodyDetails_Vm> | null = null;

  bodyDetails: IGovbodyDetails_Vm | null = null;

  selectedLocation: IGovLocation_Vm | null = null;
  selectedBody: IGovbody_Vm | null = null;

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
    this.locations$ = this.gBService.getMyGovLocations();
  }

  selectLocation(filterVal: any) {
    const x = 0;
    console.log('selectLocation');
    if (this.selectedLocation) {
      this.bodies$ = this.gBService.getGovbodies(this.selectedLocation.id);
    }
  }

  selectBody(filterVal: any) {
    console.log('selectBody');
    if (this.selectedBody) {
      this.bodyDetails$ = this.gBService
        .getGovbody(this.selectedBody.id)
        .pipe(tap((bod: any) => this.form.patchValue(bod)));
    }
  }

  submit(form: IGovbodyDetails_Vm, valid: boolean) {
    this.form.markAllAsTouched();
    if (valid) {
      this.register.emit(form);
    }
  }

  hasError(controlName: string, error: string) {
    const control = this.form.get(controlName);
    if (control) {
      return control.touched && control.hasError(error);
    } else {
      return true;
    }
  }
}
