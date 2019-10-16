import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestgridComponent } from './testgrid.component';

describe('TestgridComponent', () => {
  let component: TestgridComponent;
  let fixture: ComponentFixture<TestgridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestgridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
