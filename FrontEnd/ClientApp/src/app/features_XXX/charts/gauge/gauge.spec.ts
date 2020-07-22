import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmgaugeComponent } from './gauge';

describe('AmgaugeComponent', () => {
  let component: AmgaugeComponent;
  let fixture: ComponentFixture<AmgaugeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AmgaugeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmgaugeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
