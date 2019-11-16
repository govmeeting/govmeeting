import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SidenavMenu4Component } from './sidenav-menu4.component';

describe('SidenavMenu4Component', () => {
  let component: SidenavMenu4Component;
  let fixture: ComponentFixture<SidenavMenu4Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidenavMenu4Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidenavMenu4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
