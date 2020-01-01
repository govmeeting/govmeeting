import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GmDashMainComponent } from './dash-main.dash-main';

describe('GmDashMainComponent', () => {
  let component: GmDashMainComponent;
  let fixture: ComponentFixture<GmDashMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GmDashMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GmDashMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
