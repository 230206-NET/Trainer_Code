import { TestBed } from '@angular/core/testing';

import { WorkoutApiService } from './workout-api.service';

describe('WorkoutApiService', () => {
  let service: WorkoutApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkoutApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
