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
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString()); 

        // Click the "Connect" button
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT WorkoutSessions.Id as wID, WorkoutDate, WorkoutName, Exercises.Id as eID, ExerciseName, ExerciseNote FROM WorkoutSessions Left Join Exercises on WorkoutSessions.Id = Exercises.WorkoutId;", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        WorkoutSession workout = new();
        while(reader.Read()) {
            int wId = (int) reader["wID"];
            int? eId = reader.IsDBNull(3) ? null : (int) reader["eID"];
            if(allWorkouts.Count == 0 || wId != allWorkouts.Last().Id)
            {
                workout = new WorkoutSession {
                    Id = wId,
                    WorkoutDate = (DateTime) reader["WorkoutDate"],
                    WorkoutName = (string) reader["WorkoutName"],
                };
                allWorkouts.Add(workout);
            }
            if(eId != null) {
                workout.WorkoutExercises.Add(new Exercise {
                    Id = (int) eId,
                    Name = (string) reader["ExerciseName"],
                    Notes = (string)reader["ExerciseNote"]
                });
            }
        }

        return allWorkouts;
    }


    public List<Exercise> GetExercisesByWorkoutId(int id) {
        List<Exercise> exercises = new();
        
        // using statements automatically garbage collects the unmanaged resources like these once it goes out of scope
        // This is DIFFERENT from using Directive which is used at the top of your file to import namespaces
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());

        connection.Open();

        // Don't ever concatenate or use string interpolation for sql command, as it is vulnerable to SQL Injection
        // Instead use parameters
        using SqlCommand cmd = new SqlCommand("Select * From Exercises Where Id = @id", connection);

        // Parameterizing your variables will help protect against SQL injection 
        cmd.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = cmd.ExecuteReader();

        while(reader.read()) {
            exercises.Add(new Exercise {
                Id = reader.GetInt32(0), //(int) reader["Id"]
                Name = (string) reader["ExerciseName"],
                Notes = (string) reader["ExerciseNote"]
            });
        }

        return exercises;
    }
    /// <summary>
    /// Persists a new workout session to storage
    /// </summary>
    public void CreateNewSession(WorkoutSession sessionToCreate)
    {
        throw new NotImplementedException();
    }
}