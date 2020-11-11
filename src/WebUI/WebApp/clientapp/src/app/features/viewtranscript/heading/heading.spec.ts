import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';

import { HeadingComponent } from './heading';
import { ViewTranscriptService } from '../viewtranscript.service';
import { ViewTranscript, ViewTranscriptSample } from '../../../models/sample-data/viewtranscript-sample';

// Create a stub for ViewTranscriptService
class ServiceStub {
  public getMeeting(): Observable<ViewTranscript> {
    return of(ViewTranscriptSample);
  }
}

describe('HeadingComponent', () => {
  let component: HeadingComponent;
  let fixture: ComponentFixture<HeadingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HeadingComponent],
      providers: [{ provide: ViewTranscriptService, useClass: ServiceStub }],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
