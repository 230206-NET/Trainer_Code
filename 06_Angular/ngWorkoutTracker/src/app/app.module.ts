import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CounterComponent } from './counter/counter.component';
import { ViewWorkoutsComponent } from './view-workouts/view-workouts.component';
import { CreateWorkoutComponent } from './create-workout/create-workout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WorkoutDetailComponent } from './workout-detail/workout-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CounterComponent,
    ViewWorkoutsComponent,
    CreateWorkoutComponent,
    WorkoutDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
