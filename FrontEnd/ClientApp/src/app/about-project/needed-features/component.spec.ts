import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NeededFeaturesComponent } from './component';

describe('NeededFeaturesComponent', () => {
  let component: NeededFeaturesComponent;
  let fixture: ComponentFixture<NeededFeaturesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NeededFeaturesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NeededFeaturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
