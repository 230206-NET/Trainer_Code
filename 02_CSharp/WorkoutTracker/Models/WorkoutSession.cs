namespace Models;

/* MVP:
- As a user, I should be able to create new workout sessions
- As a user, I should be able to enter exercises to this workout
- As a user, I should be able to view my workout sessions
*/
public class WorkoutSession
{
    public DateTime WorkoutDate { get; set; } = DateTime.Now;
    private string _workoutName = DateTime.Now.ToString();
    public string WorkoutName { 
        get
        {
            return _workoutName;
        }
        set 
        {
            if(!string.IsNullOrWhiteSpace(value))
            {
                _workoutName = value;
            }
        } 
    }
    public List<Exercise> WorkoutExercises { get; set; }
}



// public class StrengthExercise : Exercise
// {
//     public int Sets { get; set; }
//     public int Reps { get; set; }
//     public string WeightType { get; set; }
//     public int Weight { get; set; }
// }

// public class CardioExercise : Exercise
// {
//     public TimeSpan Duration { get; set; }
//     public double Distance { get; set; }
//     public int CaloriesBurnt { get; set; }
// }