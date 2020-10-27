import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GovInfoComponent } from './gov-info.component';

describe('GovInfoComponent', () => {
  let component: GovInfoComponent;
  let fixture: ComponentFixture<GovInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [GovInfoComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GovInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
