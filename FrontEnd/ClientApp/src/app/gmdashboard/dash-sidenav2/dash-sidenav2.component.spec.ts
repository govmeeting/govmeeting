import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashSidenav2Component } from './dash-sidenav2.component';

describe('DashSidenav2Component', () => {
  let component: DashSidenav2Component;
  let fixture: ComponentFixture<DashSidenav2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashSidenav2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashSidenav2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
