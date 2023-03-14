import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { WorkoutApiService } from '../workout-api.service';

@Component({
  selector: 'app-view-workouts',
  templateUrl: './view-workouts.component.html',
  styleUrls: ['./view-workouts.component.css']
})
export class ViewWorkoutsComponent implements OnInit, OnDestroy, OnChanges{
  workouts : any[] = []
  constructor(private api: WorkoutApiService) { }

  ngOnInit(): void {
      // Useful for any initial set up such as fetching data
      this.api.getAllWorkouts().subscribe(data => {
        console.log(data);
        this.workouts = data;
      });
  }
  ngOnDestroy(): void {
      // Useful for any clean up work on resources angular doesn't manage for you
  }
  ngOnChanges(changes: SimpleChanges): void {
      // if you want to tap into any changes that is happening in this component class and react upon it
  }
}
