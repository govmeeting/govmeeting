import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatsampComponent } from './matsamp.component';

describe('MatsampComponent', () => {
  let component: MatsampComponent;
  let fixture: ComponentFixture<MatsampComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MatsampComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatsampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
