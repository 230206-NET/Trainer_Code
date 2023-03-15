import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray} from '@angular/forms';
import { WorkoutApiService } from '../workout-api.service';

@Component({
  selector: 'app-create-workout',
  templateUrl: './create-workout.component.html',
  styleUrls: ['./create-workout.component.css']
})
export class CreateWorkoutComponent {

  constructor(private api: WorkoutApiService, private fb: FormBuilder) { }

  form : FormGroup = this.fb.group({
    workoutName : new FormControl('', [Validators.required, Validators.maxLength(256)]),
    workoutDate : new FormControl(new Date(), [Validators.required]),
    workoutExercises : this.fb.array([])
  })

  get exercises() : FormArray<FormGroup>{
    return this.form.controls['workoutExercises'] as FormArray<FormGroup>;
  }
  
  addExercise() : void {
    const exerciseForm  = this.fb.group({
      name: ['', Validators.required],
      notes: ['']
    })
    return this.exercises.push(exerciseForm)
  }

  deleteExercise(exIndex: number) : void {
    this.exercises.removeAt(exIndex);
  }

  processForm(e: Event) : void {
    e.preventDefault();
    this.form.markAllAsTouched();
    if(this.form.valid) {

      this.api.createNewWorkout(this.form.value).subscribe(data => console.log(data));
    }
  }
}
