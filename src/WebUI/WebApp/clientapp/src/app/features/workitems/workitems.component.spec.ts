import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkitemsComponent } from './workitems.component';

describe('WorkitemsComponent', () => {
  let component: WorkitemsComponent;
  let fixture: ComponentFixture<WorkitemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WorkitemsComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkitemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
