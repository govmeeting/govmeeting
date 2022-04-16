import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkareaComponent } from './workarea.component';

describe('WorkareaComponent', () => {
  let component: WorkareaComponent;
  let fixture: ComponentFixture<WorkareaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkareaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkareaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
