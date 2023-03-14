import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateWorkoutComponent } from './create-workout.component';

describe('CreateWorkoutComponent', () => {
  let component: CreateWorkoutComponent;
  let fixture: ComponentFixture<CreateWorkoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateWorkoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateWorkoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
