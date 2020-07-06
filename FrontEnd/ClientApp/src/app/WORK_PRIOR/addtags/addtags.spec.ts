import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { AddtagsComponent } from './addtags';
import { TalksComponent } from './talks/talks'
import { TopicsComponent } from './topics/topics'
import { SectionsComponent } from './sections/sections'

describe('AddtagsComponent', () => {
  let component: AddtagsComponent;
  let fixture: ComponentFixture<AddtagsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule ],
      declarations: [
        AddtagsComponent,
        TalksComponent,
        TopicsComponent,
        SectionsComponent
       ]
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
