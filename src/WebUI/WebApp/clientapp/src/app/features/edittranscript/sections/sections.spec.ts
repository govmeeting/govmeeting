import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';

import { SectionsComponent } from './sections';
import { EditTranscriptService } from '../edittranscript.service';
import { EditTranscript, EditTranscriptSample } from '../../../models/sample-data/edittranscript-sample';

// Create a stub for EdittranscriptService
class ServiceStub {
  public getTalks(): Observable<EditTranscript> {
    return of(EditTranscriptSample);
  }
}

describe('SectionsComponent', () => {
  let component: SectionsComponent;
  let fixture: ComponentFixture<SectionsComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [SectionsComponent],
        providers: [{ provide: EditTranscriptService, useClass: ServiceStub }],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
