import { TestBed } from '@angular/core/testing';

import { UserSettingsService } from './user-settings.service';

describe('UserSettingsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserSettingsService = TestBed.inject(UserSettingsService);
    expect(service).toBeTruthy();
  });
});
