import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { AppData } from '../../appdata';

import { VideoComponent } from './video';
import { VideoService } from './video.service';

class MockAppData {
  openNav() {}
}

class MockVideoService {
  getLocation() {}
  getFileBasename() {}
}

describe('VideoComponent', () => {
  let component: VideoComponent;
  let fixture: ComponentFixture<VideoComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [VideoComponent],
        providers: [
          { provide: AppData, useClass: MockAppData },
          { provide: VideoService, useClass: MockVideoService },
        ],
        schemas: [NO_ERRORS_SCHEMA],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
