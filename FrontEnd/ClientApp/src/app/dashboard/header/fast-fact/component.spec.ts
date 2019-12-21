import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FastFactComponent } from './component';

describe('FastFactComponent', () => {
  let component: FastFactComponent;
  let fixture: ComponentFixture<FastFactComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FastFactComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FastFactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
