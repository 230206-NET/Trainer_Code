import { TestBed } from '@angular/core/testing';

import { WorkoutCacheService } from './workout-cache.service';

describe('WorkoutCacheService', () => {
  let service: WorkoutCacheService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkoutCacheService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
