import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SidenavHeaderComponent } from './sidenav-header.component';

describe('SidenavComponent', () => {
  let component: SidenavHeaderComponent;
  let fixture: ComponentFixture<SidenavHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidenavHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidenavHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
