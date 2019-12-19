import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VolunteerComponent } from './volunteer.component';

describe('VolunteerComponent', () => {
  let component: VolunteerComponent;
  let fixture: ComponentFixture<VolunteerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VolunteerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VolunteerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
