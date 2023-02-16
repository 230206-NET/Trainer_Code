using DataAccess;

namespace UI;

public class MainMenu
{
    // This is just dep injection
    private readonly WorkoutService _service;
    public MainMenu(WorkoutService service) {
        _service = service;
    }
    public void Start() {

        while(true) {
            Console.WriteLine("Workout Tracker:");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[1] Create a new workout");
            Console.WriteLine("[2] Modify an existing workout");
            Console.WriteLine("[3] View all workouts");
            Console.WriteLine("[x] Exit");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    CreateNewWorkout();
                break;
                
                case "2":
                    // ToDo: Modify Existing Workout
                break;
                case "3":
                    List<WorkoutSession> sessions = _service.GetAllWorkouts();
                    foreach(WorkoutSession s in sessions) {
                        Console.WriteLine(s);
                    }
                break;

                case "x":
                    Environment.Exit(0);
                break;

                default:
                    Console.WriteLine("I don't understand your input");
                break;
            }
        }
    }
    private void CreateNewWorkout() {
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

        while(true) {
            Console.WriteLine("Name: ");

            string nameInput = Console.ReadLine();
            try {
                session.WorkoutName = nameInput;
                break;
            }
            catch(ArgumentLengthException ex) {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
        while(true) {
            Console.WriteLine("What did you do?");

            string exerciseName = Console.ReadLine();

            Console.WriteLine("Any notes?");
            string exerciseNotes = Console.ReadLine();

            Exercise ex = new Exercise {
                Name = exerciseName,
                Notes = exerciseNotes
            };

            session.WorkoutExercises.Add(ex);
            Console.WriteLine("Add more? [y/n]");
            string more = Console.ReadLine();
            if(more.ToLower()[0] == 'n') break;
        }

        _service.CreateNewSession(session);
        Console.WriteLine(session);
    }
}
