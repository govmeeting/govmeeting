import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HeaderComponent } from './header';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { NavService } from '../sidenav/nav.service';

class MockNavService {
  openNav() {}
}

describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HeaderComponent],
      providers: [{ provide: NavService, useClass: MockNavService }],
      schemas: [NO_ERRORS_SCHEMA],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
