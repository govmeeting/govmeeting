import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficialsComponent } from './officials.component';

describe('OfficialsComponent', () => {
  let component: OfficialsComponent;
  let fixture: ComponentFixture<OfficialsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OfficialsComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
