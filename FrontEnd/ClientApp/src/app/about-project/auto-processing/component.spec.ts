import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AutoProcessingComponent } from './component';

describe('AutoProcessingComponent', () => {
  let component: AutoProcessingComponent;
  let fixture: ComponentFixture<AutoProcessingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AutoProcessingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AutoProcessingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
