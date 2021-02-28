import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
//import { sample } from 'rxjs/operators';
import { RegisterGovBodyService } from './register-gov-body.service'
import { IGovbodyDetails_Vm, IGovLocation_Vm, IOfficial_Vm } from '../../models/govbody-view';
import { Observable, of } from 'rxjs';

import { GovLocation_Dto} from '../../apis/api.generated.clients'
import { filter, map } from 'rxjs/operators';

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

  observeVm$: Observable<IGovLocation_Vm[]> = null;

  public selectedOLocation;

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
    this.observeVm$ = this.gBService.getMyGovLocations();


    //this.transformNumbers();

    //  this.registerService.testMapper();
    //this.myGovlocations = this.gBService.getMyGovLocations();
  }
  selectLocation(filterVal: any) {
    let x = 0;
  }

  returnNumbersObservable(): Observable<number[]> {
    //return of([1], [2], [3], [4], [5], [6]);
    return of([1, 2, 3]);
  }

  transformNumbers() {
    this.returnNumbersObservable().pipe(
      //filter(n => n[0] % 2 === 0),
      //  map(n => [n[0] * 2, n[1]*3, n[2] * 5])
      //map(n => ["a", "b"])
      map(n => "a string")
    )
      .subscribe(
        result => console.log(result)
      );
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
