import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { LargeCardsComponent } from './large-cards';

describe('MainCardsComponent', () => {
  let component: LargeCardsComponent;
  let fixture: ComponentFixture<LargeCardsComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [LargeCardsComponent],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(LargeCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
