import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickviewHeaderComponent } from './quickview-header.component';

describe('QuickviewHeaderComponent', () => {
  let component: QuickviewHeaderComponent;
  let fixture: ComponentFixture<QuickviewHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickviewHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickviewHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
