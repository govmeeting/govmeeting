import { TestBed } from '@angular/core/testing';

import { RegisterGovBodyService } from './register-gov-body.service';
import { GovbodyClient, GovLocationClient } from '../../apis/api.generated.clients';

class MockGovbodyClient {}
class MockGovLocationClient {}

describe('RegisterGovBodyService', () => {
  let service: RegisterGovBodyService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        { provide: GovbodyClient, useClass: MockGovbodyClient },
        { provide: GovLocationClient, useClass: MockGovLocationClient },
      ],
    });
    service = TestBed.inject(RegisterGovBodyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
