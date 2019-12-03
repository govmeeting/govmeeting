import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestmatComponent } from './testmat.component';

describe('TestmatComponent', () => {
  let component: TestmatComponent;
  let fixture: ComponentFixture<TestmatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestmatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestmatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
