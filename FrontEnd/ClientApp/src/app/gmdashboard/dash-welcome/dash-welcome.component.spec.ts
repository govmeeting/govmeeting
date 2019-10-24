import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashWelcomeComponent } from './dash-welcome.component';

describe('DashWelcomeComponent', () => {
  let component: DashWelcomeComponent;
  let fixture: ComponentFixture<DashWelcomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashWelcomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashWelcomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
