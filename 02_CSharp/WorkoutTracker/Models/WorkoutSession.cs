using Models.CustomException;
using System.Text;
using Serilog;
namespace Models;

/* MVP:
- As a user, I should be able to create new workout sessions
- As a user, I should be able to enter exercises to this workout
- As a user, I should be able to view my workout sessions
*/
public class WorkoutSession
{
    public WorkoutSession() {
        WorkoutExercises = new List<Exercise>();
    }
    public DateTime WorkoutDate { get; set; } = DateTime.Now;
    private string _workoutName = DateTime.Now.ToString();
    public string WorkoutName { 
        get
        {
            return _workoutName;
        }
        set 
        {
            if(value.Length >= 100)
            {
                // The name is longer than 100 characters
                // Throw some exception
                Log.Warning("Models: assigning name to new workout session: name length too long");
                throw new ArgumentLengthException("Name must be less than 100 characters");
            }
            if(!string.IsNullOrWhiteSpace(value))
            {
                _workoutName = value;
            }
        }
    }
    public List<Exercise> WorkoutExercises { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new();
        
        sb.Append($"Name: {this.WorkoutName}\nDate: {this.WorkoutDate}");

        foreach(Exercise e in WorkoutExercises) {
            sb.Append("\n");
            sb.Append(e.ToString());
        }

        return sb.ToString();
    }
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