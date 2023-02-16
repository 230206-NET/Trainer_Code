namespace Services;
public class WorkoutService
{
    // Dependency Injection: is a design pattern where the dependency of a class is injected through the constructor instead of the class itself having a specific knowledge of its dependency, or instantiating itself
    // This example here is actually a combination of dependency injection and dependency inversion
    // This allows for more flexible change in implementation, also this pattern makes unit testing much simpler
    private readonly IRepository _repo;
    public WorkoutService(IRepository repo) {
        _repo = repo;
    }

    public List<WorkoutSession> GetAllWorkouts() 
    {
        return _repo.GetAllWorkouts();
    }

    public void CreateNewSession(WorkoutSession sessionToCreate) {
        _repo.CreateNewSession(sessionToCreate);
    }
}