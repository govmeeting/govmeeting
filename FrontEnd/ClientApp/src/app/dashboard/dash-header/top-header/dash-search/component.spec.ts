import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashSearchComponent } from './component';

describe('DashSearchComponent', () => {
  let component: DashSearchComponent;
  let fixture: ComponentFixture<DashSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
