import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickItemComponent } from './quick-item.component';

describe('QuickItemComponent', () => {
  let component: QuickItemComponent;
  let fixture: ComponentFixture<QuickItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
