import { Exercise } from './exercise'

export interface Workout {
    id? : number,
    workoutDate : Date | string,
    workoutName : string,
    workoutExercises : Array<Exercise>
}