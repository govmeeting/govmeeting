import { NO_ERRORS_SCHEMA } from '@angular/core';
import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { RegisterGovBodyComponent } from './register-gov-body.component';
import { RegisterGovBodyService } from './register-gov-body.service';

class MockRegisterGovBodyService {
  getMyGovLocations() {}
}

describe('RegisterGovBodyComponent', () => {
  let component: RegisterGovBodyComponent;
  let fixture: ComponentFixture<RegisterGovBodyComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [RegisterGovBodyComponent],
        providers: [FormBuilder, { provide: RegisterGovBodyService, useClass: MockRegisterGovBodyService }],
        schemas: [NO_ERRORS_SCHEMA],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterGovBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
