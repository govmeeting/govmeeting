import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { VirtualMeetingComponent } from './virtual-meeting';

describe('VirtualMeetingComponent', () => {
  let component: VirtualMeetingComponent;
  let fixture: ComponentFixture<VirtualMeetingComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [VirtualMeetingComponent],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(VirtualMeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
