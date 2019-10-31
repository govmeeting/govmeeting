import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutProjectComponent } from './about-project.component';

describe('AboutProjectComponent', () => {
  let component: AboutProjectComponent;
  let fixture: ComponentFixture<AboutProjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AboutProjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
