import { TestBed } from '@angular/core/testing';

import { DataFactoryService } from './data-factory.service';

describe('DataFactoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DataFactoryService = TestBed.get(DataFactoryService);
    expect(service).toBeTruthy();
  });
});
