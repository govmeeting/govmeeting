import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { Observable, of } from 'rxjs';
import { SidenavMenuComponent } from './sidenav-menu';
import { NavService } from '../sidenav/nav.service';
import { AppData } from '../appdata';

class MockNavService {
  s = '';
  openNav() {}
  getMenuSelection() {
    return of(this.s);
  }
  openFirstMenuLevels() {}
}
class MockAppData {}

describe('SidenavMenu4Component', () => {
  let component: SidenavMenuComponent;
  let fixture: ComponentFixture<SidenavMenuComponent>;
  let router: Router;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        imports: [RouterTestingModule.withRoutes([])],
        declarations: [SidenavMenuComponent],
        providers: [
          { provide: NavService, useClass: MockNavService },
          { provide: AppData, useClass: MockAppData },
        ],
        schemas: [NO_ERRORS_SCHEMA],
      }).compileComponents();
      router = TestBed.inject(Router);
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(SidenavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
