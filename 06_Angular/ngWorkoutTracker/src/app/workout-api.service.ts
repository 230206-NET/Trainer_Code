import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Workout } from './models/workout';
@Injectable({
  providedIn: 'root'
})
export class WorkoutApiService {
  apiRoot : string = 'https://workout-tracker-demo-api.azurewebsites.net/workout';

  constructor(private http: HttpClient) { }

  getAllWorkouts() : Observable<Array<Workout>> {
    return this.http.get(this.apiRoot) as Observable<Array<Workout>>;
  }

  createNewWorkout(workoutToCreate : Workout) {
    return this.http.post(this.apiRoot, workoutToCreate);
  }
}