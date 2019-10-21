import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmguageComponent } from './amguage.component';

describe('AmguageComponent', () => {
  let component: AmguageComponent;
  let fixture: ComponentFixture<AmguageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AmguageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmguageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
