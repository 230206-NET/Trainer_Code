using Models;
using System.Data.SqlClient;

namespace DataAccess;

// ADO.NET
/*
ADO.NET is a collection of tools and types for accessing databases in uniform fashion
They offer different types to handle different db's but they all inherit from the same supertype, which makes the usage about the same
*/
// To set up,
// make sure you have System.Data.SqlClient package installed on DataAccess project
// and include System.Data.SqlClient namespace

/*
Reading/writing to DB
1. Connect to DB
2. Assemble/Write the query
3. Execute it
4. Process the data or check that it's been successful
*/

public class DBRepository : IRepository
{

    /// <summary>
    /// Retrieves all workout sessions
    /// </summary>
    /// <returns>a list of workout sessions</returns>
    public List<WorkoutSession> GetAllWorkouts()
    {
        List<WorkoutSession> allWorkouts = new();
        // Equivalent to opening Azure Data Studio and filling out the new connection form
        SqlConnection connection = new SqlConnection(Secrets.getConnectionString()); 

        // Click the "Connect" button
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM WorkoutSessions", connection);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read()) {
            allWorkouts.Add(new WorkoutSession {
                Id = (int) reader["Id"],
                WorkoutDate = (DateTime) reader["WorkoutDate"],
                WorkoutName = (string) reader["WorkoutName"],
            });
        }

        return allWorkouts;
    }

    /// <summary>
    /// Persists a new workout session to storage
    /// </summary>
    public void CreateNewSession(WorkoutSession sessionToCreate)
    {
        throw new NotImplementedException();
    }
}