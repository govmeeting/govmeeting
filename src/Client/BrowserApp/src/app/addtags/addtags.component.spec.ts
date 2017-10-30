import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddtagsComponent } from './addtags.component';

describe('AddtagsComponent', () => {
  let component: AddtagsComponent;
  let fixture: ComponentFixture<AddtagsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddtagsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddtagsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
