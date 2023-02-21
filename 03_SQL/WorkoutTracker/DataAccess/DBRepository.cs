using Models;
using System.Data;

namespace DataAccess;

// ADO.NET
/*
ADO.NET is a collection of tools and types for accessing databases in uniform fashion
They offer different types to handle different db's but they all inherit from the same supertype, which makes the usage about the same
*/
// To set up,
// make sure you have Microsoft.Data.SqlClient package installed on DataAccess project
// and include System.Data namespace

/*
Reading/writing to DB
1. Connect to DB
2. Assemble/Write the query
3. Execute it
4. Process the data or check that it's been successful
*/

public class DBRepository : IRepository
{

    private string _connnectionString = "Server=tcp:workout-tracker.database.windows.net,1433;Initial Catalog=workoutDB;Persist Security Info=False;User ID=workout-admin;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    /// <summary>
    /// Retrieves all workout sessions
    /// </summary>
    /// <returns>a list of workout sessions</returns>
    public List<WorkoutSession> GetAllWorkouts()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Persists a new workout session to storage
    /// </summary>
    public void CreateNewSession(WorkoutSession sessionToCreate)
    {
        throw new NotImplementedException();
    }
}