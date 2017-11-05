import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowsemeetingComponent } from './browsemeeting.component';

describe('BrowsemeetingComponent', () => {
  let component: BrowsemeetingComponent;
  let fixture: ComponentFixture<BrowsemeetingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrowsemeetingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowsemeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
