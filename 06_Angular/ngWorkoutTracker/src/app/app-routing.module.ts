import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewWorkoutsComponent } from './view-workouts/view-workouts.component';
import { WorkoutDetailComponent } from './workout-detail/workout-detail.component';

const routes: Routes = [
  {
    path: 'workout/:wid',
    component: WorkoutDetailComponent
  },
  {
    path: '',
    component: ViewWorkoutsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
