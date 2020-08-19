import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { LargeCardComponent } from './large-card';

describe('MainCardComponent', () => {
  let component: LargeCardComponent;
  let fixture: ComponentFixture<LargeCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LargeCardComponent],
      schemas: [NO_ERRORS_SCHEMA],
    }).compileComponents();
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
