import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutTemplateComponent } from './component';

describe('AboutTemplateComponent', () => {
  let component: AboutTemplateComponent;
  let fixture: ComponentFixture<AboutTemplateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AboutTemplateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
