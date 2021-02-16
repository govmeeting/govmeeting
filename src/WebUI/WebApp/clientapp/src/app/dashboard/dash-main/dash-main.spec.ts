import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { DashMainComponent } from './dash-main';
import { AppData } from '../../appdata';

class MockAppData {}

describe('GmDashMainComponent', () => {
  let component: DashMainComponent;
  let fixture: ComponentFixture<DashMainComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [DashMainComponent],
        providers: [{ provide: AppData, useClass: MockAppData }],
        schemas: [NO_ERRORS_SCHEMA],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(DashMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
