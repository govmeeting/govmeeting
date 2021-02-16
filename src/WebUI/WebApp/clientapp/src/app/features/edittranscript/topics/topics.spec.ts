import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { Observable, of } from 'rxjs';

import { TopicsComponent } from './topics';
import { EdittranscriptService } from '../edittranscript.service';
import { EditTranscript, EditTranscriptSample } from '../../../models/sample-data/edittranscript-sample';

// Create a stub for EdittranscriptService
class ServiceStub {
  public getTalks(): Observable<EditTranscript> {
    return of(EditTranscriptSample);
  }
}

describe('TopicsComponent', () => {
  let component: TopicsComponent;
  let fixture: ComponentFixture<TopicsComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        imports: [FormsModule],
        declarations: [TopicsComponent],
        providers: [{ provide: EdittranscriptService, useClass: ServiceStub }],
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
