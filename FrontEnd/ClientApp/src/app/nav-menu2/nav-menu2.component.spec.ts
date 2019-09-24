import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavMenu2Component } from './nav-menu2.component';

describe('NavMenu2Component', () => {
  let component: NavMenu2Component;
  let fixture: ComponentFixture<NavMenu2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavMenu2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavMenu2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
