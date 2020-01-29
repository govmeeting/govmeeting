import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewFeatureComponent } from './new-feature.component';

describe('NewFeatureComponent', () => {
  let component: NewFeatureComponent;
  let fixture: ComponentFixture<NewFeatureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewFeatureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
