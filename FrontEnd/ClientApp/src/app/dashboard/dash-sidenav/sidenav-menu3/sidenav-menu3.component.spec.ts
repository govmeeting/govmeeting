import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SidenavMenu3Component } from './sidenav-menu3.component';

describe('SidenavMenu3Component', () => {
  let component: SidenavMenu3Component;
  let fixture: ComponentFixture<SidenavMenu3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidenavMenu3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidenavMenu3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
