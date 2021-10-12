import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VdoPlayerComponent } from './vdo-player.component';

describe('VdoPlayerComponent', () => {
  let component: VdoPlayerComponent;
  let fixture: ComponentFixture<VdoPlayerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VdoPlayerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VdoPlayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
