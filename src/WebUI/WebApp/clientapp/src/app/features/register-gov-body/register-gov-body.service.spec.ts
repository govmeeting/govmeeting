import { TestBed } from '@angular/core/testing';

import { RegisterGovBodyServiceReal } from './register-gov-body.service-real';
import { GovbodyClient, GovLocationClient } from '../../apis/api.generated.clients';

class MockGovbodyClient {}
class MockGovLocationClient {}

describe('RegisterGovBodyService', () => {
  let service: RegisterGovBodyServiceReal;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        { provide: GovbodyClient, useClass: MockGovbodyClient },
        { provide: GovLocationClient, useClass: MockGovLocationClient },
      ],
    });
    service = TestBed.inject(RegisterGovBodyServiceReal);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
