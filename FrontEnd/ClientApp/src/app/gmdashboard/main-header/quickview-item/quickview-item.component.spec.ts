import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickviewItemComponent } from './quick-item.component';

describe('QuickviewItemComponent', () => {
  let component: QuickviewItemComponent;
  let fixture: ComponentFixture<QuickviewItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickviewItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickviewItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
