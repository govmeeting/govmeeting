import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SidenavMenu2Component } from './sidenav-menu2.component';

describe('SidenavMenu2Component', () => {
  let component: SidenavMenu2Component;
  let fixture: ComponentFixture<SidenavMenu2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidenavMenu2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidenavMenu2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
