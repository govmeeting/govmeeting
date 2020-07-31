import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoutoutsComponent } from './shoutouts';

describe('ShoutoutsComponent', () => {
  let component: ShoutoutsComponent;
  let fixture: ComponentFixture<ShoutoutsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoutoutsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoutoutsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
