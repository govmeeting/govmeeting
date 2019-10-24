import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickviewIntroComponent } from './quickview-intro.component';

describe('QuickviewIntroComponent', () => {
  let component: QuickviewIntroComponent;
  let fixture: ComponentFixture<QuickviewIntroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickviewIntroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickviewIntroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
