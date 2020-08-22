import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmallCardsComponent } from './small-cards';

describe('SmallCardComponent', () => {
  let component: SmallCardsComponent;
  let fixture: ComponentFixture<SmallCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SmallCardsComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmallCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
