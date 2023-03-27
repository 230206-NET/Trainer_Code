using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class WorkoutSession
{
    public int Id { get; set; }

    public DateTime? WorkoutDate { get; set; }

    public string? WorkoutName { get; set; }

    public virtual ICollection<Exercise> Exercises { get; } = new List<Exercise>();
}
