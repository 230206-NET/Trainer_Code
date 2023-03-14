import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray} from '@angular/forms';
import { WorkoutApiService } from '../workout-api.service';

@Component({
  selector: 'app-create-workout',
  templateUrl: './create-workout.component.html',
  styleUrls: ['./create-workout.component.css']
})
export class CreateWorkoutComponent {

  constructor(private api: WorkoutApiService) { }

  workoutForm : FormGroup = new FormGroup({
    workoutName : new FormControl('', [Validators.required, Validators.maxLength(256)]),
    workoutDate : new FormControl(new Date(), [Validators.required]),
    workoutExerciseName: new FormControl(''),
    workoutExerciseNotes: new FormControl('')
  })

  processForm(e: Event) {
    e.preventDefault();
    console.log(this.workoutForm);
    if(this.workoutForm.valid) {
      const workoutToCreate = {
        workoutName : this.workoutForm.value.workoutName,
        workoutDate : this.workoutForm.value.workoutDate,
        workoutExercises: [
          {
            name: this.workoutForm.value.workoutExerciseName,
            notes: this.workoutForm.value.workoutExerciseNotes
          }
        ]
      };

      this.api.createNewWorkout(workoutToCreate).subscribe(data => console.log(data));
    }
  }
}
