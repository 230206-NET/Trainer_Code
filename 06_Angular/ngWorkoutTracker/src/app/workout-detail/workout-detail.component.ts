import { Component, OnInit } from '@angular/core';
import { WorkoutApiService } from '../workout-api.service';
import { WorkoutCacheService } from '../workout-cache.service';
import { Workout } from '../models/workout';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-workout-detail',
  templateUrl: './workout-detail.component.html',
  styleUrls: ['./workout-detail.component.css']
})
export class WorkoutDetailComponent implements OnInit{
  constructor(private wCache : WorkoutCacheService, private api : WorkoutApiService, private activatedRoute: ActivatedRoute) { }
  workoutSession? : Workout = undefined;
  ngOnInit(): void {
    // to get access to route params
      this.activatedRoute.params.subscribe(params => {
        console.log('params', params)
        if(this.wCache.workouts.length === 0) {
          this.api.getAllWorkouts().subscribe((data) => {
            this.wCache.workouts = data;
            this.workoutSession = data.find(w => w.id === parseInt(params['wid']));
            console.log(this.workoutSession);
          })
        }
        else {
          console.log('workout', this.wCache.workouts)
          this.workoutSession = this.wCache.workouts.find(w => w.id === parseInt(params['wid']));
          console.log('found', this.workoutSession)
        }
      })
  }
}
