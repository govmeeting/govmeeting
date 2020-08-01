import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SectionsComponent } from './sections';
import { AddtagsService } from '../addtags.service';
import { AddtagsServiceStub } from '../addtags.service-stub';

describe('SectionsComponent', () => {
  let component: SectionsComponent;
  let fixture: ComponentFixture<SectionsComponent>;
  // let addtagsService = new AddtagsServiceStub();

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SectionsComponent ],
      providers: [
        {provide: AddtagsService, useClass: AddtagsServiceStub}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
