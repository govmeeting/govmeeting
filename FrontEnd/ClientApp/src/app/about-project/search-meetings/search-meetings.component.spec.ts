import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchMeetingsComponent } from './search-meetings.component';

describe('SearchMeetingsComponent', () => {
  let component: SearchMeetingsComponent;
  let fixture: ComponentFixture<SearchMeetingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchMeetingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchMeetingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
