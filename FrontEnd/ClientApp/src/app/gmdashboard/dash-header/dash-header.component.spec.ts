import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashHeaderComponent } from './dash-header.component';

describe('DashHeaderComponent', () => {
  let component: DashHeaderComponent;
  let fixture: ComponentFixture<DashHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
