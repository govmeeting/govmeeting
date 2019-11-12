import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashSidenav3Component } from './dash-sidenav3.component';

describe('DashSidenav3Component', () => {
  let component: DashSidenav3Component;
  let fixture: ComponentFixture<DashSidenav3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashSidenav3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashSidenav3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
