using Models;
namespace DataAccess;
public interface IRepository
{
    /// <summary>
    /// Retrieves all workout sessions
    /// </summary>
    /// <returns>a list of workout sessions</returns>
    List<WorkoutSession> GetAllWorkouts();

    /// <summary>
    /// Persists a new workout session to storage
    /// </summary>
    void CreateNewSession(WorkoutSession sessionToCreate);
}