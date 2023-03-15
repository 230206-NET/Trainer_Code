import { Injectable } from '@angular/core';
import { Workout } from './models/workout';

@Injectable({
  providedIn: 'root'
})
export class WorkoutCacheService {
  // ToDo: expire cache, update upon creation, make it actually act like a cache instead of this bandaid fix
  workouts : Array<Workout> = [];
  constructor() { }
}