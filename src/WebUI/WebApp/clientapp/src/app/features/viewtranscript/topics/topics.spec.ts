import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';

import { TopicsComponent } from './topics';
import { ViewTranscriptServiceReal } from '../viewtranscript.service-real';
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
  setTopic(topic: string) {}
  getTopic() {}
}

describe('TopicsComponent', () => {
  let component: TopicsComponent;
  let fixture: ComponentFixture<TopicsComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [TopicsComponent],
        providers: [
          { provide: ViewTranscriptServiceReal, useClass: ServiceStub },
          { provide: UserchoiceService, useClass: UserchoiceStub },
        ],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(TopicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
