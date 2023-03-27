using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Exercise
{
    public int Id { get; set; }

    public string ExerciseName { get; set; } = null!;

    public string? ExerciseNote { get; set; }

    public int? WorkoutId { get; set; }

    public virtual WorkoutSession? Workout { get; set; }
}
