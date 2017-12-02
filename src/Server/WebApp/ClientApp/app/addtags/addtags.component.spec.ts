import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { AddtagsComponent } from './addtags.component';
import { TalksComponent } from './talks/talks.component'
import { TopicsComponent } from './topics/topics.component'
import { SectionsComponent } from './sections/sections.component'

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
