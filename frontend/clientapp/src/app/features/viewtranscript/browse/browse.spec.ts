import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';

import { BrowseComponent } from './browse';
import { ViewTranscriptService } from '../viewtranscript.service';
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
  getTopic() {}
  getSpeaker() {}
}

describe('BrowseComponent', () => {
  let component: BrowseComponent;
  let fixture: ComponentFixture<BrowseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [BrowseComponent],
      providers: [
        { provide: ViewTranscriptService, useClass: ServiceStub },
        { provide: UserchoiceService, useClass: UserchoiceStub },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
