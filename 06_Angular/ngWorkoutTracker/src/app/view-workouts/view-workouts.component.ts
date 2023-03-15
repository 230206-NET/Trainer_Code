import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges} from '@angular/core';
import { WorkoutApiService } from '../workout-api.service';
import { Router } from '@angular/router';
import { WorkoutCacheService } from '../workout-cache.service';

@Component({
  selector: 'app-view-workouts',
  templateUrl: './view-workouts.component.html',
  styleUrls: ['./view-workouts.component.css']
})
export class ViewWorkoutsComponent implements OnInit, OnDestroy, OnChanges{
  workouts : any[] = []
  constructor(private api: WorkoutApiService, private router : Router, private wCache : WorkoutCacheService) { }

  viewDetails(id: number) {
    this.router.navigateByUrl(`workout/${id}`);
  }

  ngOnInit(): void {
      // Useful for any initial set up such as fetching data
      this.api.getAllWorkouts().subscribe(data => {
        this.wCache.workouts = data;
        this.workouts = data.sort((a, b) => new Date(a.workoutDate).getTime() - new Date(b.workoutDate).getTime());
      });
  }
  ngOnDestroy(): void {
      // Useful for any clean up work on resources angular doesn't manage for you
  }
  ngOnChanges(changes: SimpleChanges): void {
      // if you want to tap into any changes that is happening in this component class and react upon it
  }
}
