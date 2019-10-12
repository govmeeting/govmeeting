import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentDocumentsComponent } from './recent-documents.component';

describe('RecentDocumentsComponent', () => {
  let component: RecentDocumentsComponent;
  let fixture: ComponentFixture<RecentDocumentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecentDocumentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecentDocumentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
