using Models;

namespace UI;

public class MainMenu
{
    public void Start() {
        List<WorkoutSession> workouts = new();

        while(true) {
            Console.WriteLine("Workout Tracker:");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[1] Create a new workout");
            Console.WriteLine("[2] Modify an existing workout");
            Console.WriteLine("[3] View all workouts");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    WorkoutSession session = new WorkoutSession();
                    Console.WriteLine("Creating new workout: ");
                    Console.WriteLine("Date: ");
                    string? workoutDate = Console.ReadLine();

                    DateTime parsed;
                    bool parseSuccess = DateTime.TryParse(workoutDate, out parsed);

                    if(parseSuccess)
                    {
                        session.WorkoutDate = parsed;
                    }

                    Console.WriteLine("Name: ");

                    string nameInput = Console.ReadLine();
                    session.WorkoutName = nameInput;

                    Console.WriteLine("Name: {0}", session.WorkoutName);

                    Console.WriteLine($"Date: {session.WorkoutDate}");
                break;
                
                case "2":

                break;
                case "3":

                break;
                default:
                    Console.WriteLine("I don't understand your input");
                break;
            }
        }
    }
}