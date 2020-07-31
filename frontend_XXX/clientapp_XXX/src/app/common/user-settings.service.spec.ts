import { TestBed } from '@angular/core/testing';

import { UserSettingsService } from './common/user-settings.service';

describe('UserSettingsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserSettingsService = TestBed.get(UserSettingsService);
    expect(service).toBeTruthy();
  });
});
