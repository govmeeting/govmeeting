import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainCardsComponent } from './main-cards.component';

describe('MainCardsComponent', () => {
  let component: MainCardsComponent;
  let fixture: ComponentFixture<MainCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainCardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
