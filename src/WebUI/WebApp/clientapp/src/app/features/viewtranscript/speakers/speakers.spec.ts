import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';

import { SpeakersComponent } from './speakers';

import { ViewTranscriptServiceReal } from '../viewtranscript.service';
import { ViewTranscript, ViewTranscriptSample } from '../../../models/sample-data/viewtranscript-sample';
import { UserchoiceService } from '../userchoice.service';

// Create a stub for ViewTranscriptService
class ServiceStub {
  public getMeeting(): Observable<ViewTranscript> {
    return of(ViewTranscriptSample);
  }
}

// Create a stub for UserChoiceService
class UserchoiceStub {
  Names: string[];
  setSpeaker(topic: string) {}
  getSpeaker() {}
}

describe('SpeakersComponent', () => {
  let component: SpeakersComponent;
  let fixture: ComponentFixture<SpeakersComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [SpeakersComponent],
        providers: [
          { provide: ViewTranscriptServiceReal, useClass: ServiceStub },
          { provide: UserchoiceService, useClass: UserchoiceStub },
        ],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(SpeakersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
