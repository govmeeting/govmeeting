import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideojsComponent } from './videojs';

describe('VideojsComponent', () => {
  let component: VideojsComponent;
  let fixture: ComponentFixture<VideojsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VideojsComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VideojsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
