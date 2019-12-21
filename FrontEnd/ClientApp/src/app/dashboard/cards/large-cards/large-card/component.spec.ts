import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LargeCardComponent } from './component';

describe('MainCardComponent', () => {
  let component: LargeCardComponent;
  let fixture: ComponentFixture<LargeCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LargeCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LargeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
