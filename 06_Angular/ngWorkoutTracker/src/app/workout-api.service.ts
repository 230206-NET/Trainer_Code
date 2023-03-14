import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class WorkoutApiService {

  constructor(private http: HttpClient) { }

  getAllWorkouts() : Observable<any> {
    return this.http.get('https://workout-tracker-demo-api.azurewebsites.net/workout');
  }
}