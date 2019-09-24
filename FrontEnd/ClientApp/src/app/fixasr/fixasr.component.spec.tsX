import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FixasrComponent } from './fixasr.component';

describe('FixasrComponent', () => {
  let component: FixasrComponent;
  let fixture: ComponentFixture<FixasrComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FixasrComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixasrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
