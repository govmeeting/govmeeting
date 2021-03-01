import { TestBed } from '@angular/core/testing';
import { GovbodyMapper } from './govbody-mapper';

describe('GovbodyMapper', () => {
  let service: GovbodyMapper;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GovbodyMapper);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('testGovLocationMapper should equal true', () => {
    expect(service.testGovLocationMapper()).toBeTruthy();
  });

  it('testGovbodyDetailsMapper should equal true', () => {
    expect(service.testGovbodyDetailsMapper()).toBeTruthy();
  });

  it('testGovbodyMapper should equal true', () => {
    expect(service.testGovbodyMapper()).toBeTruthy();
  });
});
