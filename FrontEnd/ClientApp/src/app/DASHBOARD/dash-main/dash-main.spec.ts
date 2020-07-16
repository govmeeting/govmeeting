import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashMainComponent } from './dash-main';

describe('GmDashMainComponent', () => {
  let component: DashMainComponent;
  let fixture: ComponentFixture<DashMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
