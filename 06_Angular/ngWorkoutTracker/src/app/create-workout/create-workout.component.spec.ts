import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { of } from 'rxjs';
import { WorkoutApiService } from '../workout-api.service';
import { CreateWorkoutComponent } from './create-workout.component';

describe('CreateWorkoutComponent', () => {
  let component: CreateWorkoutComponent;
  let fixture: ComponentFixture<CreateWorkoutComponent>;
  let service: WorkoutApiService
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateWorkoutComponent ],
      imports: [
        HttpClientTestingModule,
        FormsModule,
        ReactiveFormsModule
      ]
    })
    .compileComponents();

    service = TestBed.inject(WorkoutApiService);
    fixture = TestBed.createComponent(CreateWorkoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should process valid form', () => {
    //arrange
    const event = new SubmitEvent('submit');
    spyOn(event, 'preventDefault');
    spyOn(component.form, 'markAllAsTouched');
    spyOn(service, 'createNewWorkout').and.returnValue(of({
      id: 1,
      workoutName: 'test workout',
      workoutDate: new Date(),
      workoutExercises: []
    }))

    component.form.controls['workoutName'].setValue('test workout');
    component.form.controls['workoutDate'].setValue(new Date());

    
    //Act
    component.processForm(event);

    //Assert
    expect(event.preventDefault).toHaveBeenCalledTimes(1);
    expect(component.form.markAllAsTouched).toHaveBeenCalled();
    expect(service.createNewWorkout).toHaveBeenCalled();

  })

  it('should not process invalid form', () => {
    //arrange
    const event = new SubmitEvent('submit');
    spyOn(event, 'preventDefault');
    spyOn(component.form, 'markAllAsTouched');
    spyOn(service, 'createNewWorkout');
    
    //Act
    component.processForm(event);

    //Assert
    expect(event.preventDefault).toHaveBeenCalledTimes(1);
    expect(component.form.markAllAsTouched).toHaveBeenCalled();
    expect(component.form.valid).toBeFalse();
    expect(service.createNewWorkout).toHaveBeenCalledTimes(0);
  })
});
