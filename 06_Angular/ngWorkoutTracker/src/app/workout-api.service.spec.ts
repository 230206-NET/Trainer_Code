import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { WorkoutApiService } from './workout-api.service';

describe('WorkoutApiService', () => {
  let service: WorkoutApiService;
  let httpMock: HttpTestingController;
  const apiRoot = 'https://workout-tracker-demo-api.azurewebsites.net/workout';
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    httpMock = TestBed.inject(HttpTestingController);
    service = TestBed.inject(WorkoutApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get all workouts', () => {
    service.getAllWorkouts().subscribe((data) => {
      expect(data).toBeTruthy();
      expect(data.length).toEqual(3);
    });

    //Verify that the http request has been sent to the url i'm expecting, and the request method to be GET
    const req = httpMock.expectOne('https://workout-tracker-demo-api.azurewebsites.net/workout');
    expect(req.request.method).toBe('GET');

    //respond with fake response
    req.flush([
      {
        id: 1,
        workoutDate: new Date(),
        workoutName: 'test',
        workoutExercises: []
      },
      {
        id: 2,
        workoutDate: new Date(),
        workoutName: 'test 2',
        workoutExercises: []
      },
      {
        id: 3,
        workoutDate: new Date(),
        workoutName: 'test 3',
        workoutExercises: []
      }
    ])

    //after everything is over, make sure there is no other http requests it's still waiting for
    httpMock.verify();
  })

  it('should create workout', () => {
    const testDate = new Date();
    const workoutToCreate = {
      workoutDate: testDate,
      workoutName: 'testName',
      workoutExercises: []
    }
    //Act and Verify the response
    service.createNewWorkout(workoutToCreate).subscribe((data : any) => {
      expect(data).toBeTruthy();
      expect(data.id).toBe(123);
    })

    //Verify that our requests are going out correctly with the right body and method type
    const req = httpMock.expectOne(apiRoot);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(workoutToCreate);

    req.flush({
      id: 123,
      workoutDate: testDate,
      workoutName: 'testName',
      workoutExercises: []
    });

    httpMock.verify();
  })
});
